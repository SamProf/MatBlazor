using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Text fields allow users to input, edit, and select text.
    /// </summary>
    public class BaseMatNumericUpDownField : BaseMatComponent
    {
        public ElementRef InputRef { get; set; }

        bool shortCut;

        [Parameter]
        public decimal? Value  // obj-type
        {
            get => _value;
            set
            {
                shortCut = true;
                UpdateValue(value);
            }
        }

        protected async void UpdateValue( decimal? value)
        {
            // update ui as usual.
            var _newbindedValue = value?.ToString() ?? "";
            _bindedValue = _newbindedValue;

            // if value is the same force update ui.
            if (_value == value)
            {
                //work around to refresh out of range values for twice.
                _bindedValue = "                                       ";
                await Task.Delay(1);
                _bindedValue = _newbindedValue;
                await Task.Delay(1);
                StateHasChanged();
                return;
            }

            // set mappers.
            LabelClassMapper.MakeDirty();
            InputClassMapper.MakeDirty();

            // paranoia. If value is changed from outside of control don't raise ValueChanged
            if (_value == value && shortCut)
            {
                shortCut = false;
                return;
            }

            // set new value.
            _value = value;
            await ValueChanged.InvokeAsync(value);
        }

        protected bool InvalidInput { get; private set; }

        protected string VisibleValue  // obj-type
        {
            get => _bindedValue;
            set
            {

                InvalidInput = false;
                bool isDecimal = decimal.TryParse(value, out decimal valueAux);

                if (String.IsNullOrWhiteSpace(value) )
                {
                    UpdateValue(null);
                }

                else if (!isDecimal ) 
                {
                    UpdateValue(null);
                    InvalidInput = true;
                }

                else if( Minimum.HasValue && isDecimal && valueAux < Minimum.Value)
                {
                    var v = Math.Round(Minimum.Value, DecimalPlaces);
                    UpdateValue(v);
                }

                else if( Maximum.HasValue && isDecimal && valueAux > Maximum)
                {
                    var v = Math.Round(Maximum.Value, DecimalPlaces);
                    UpdateValue(v);
                }

                else
                {
                    var v = Math.Round(valueAux, DecimalPlaces);
                    UpdateValue(v);
                }

            }
        }

        [Parameter]
        public decimal? Maximum { get; set; }  = 100;

        [Parameter]
        public decimal? Minimum { get; set; }  = 0;

        [Parameter]
        public int DecimalPlaces { get; set; } = 0;

        [Parameter]
        protected Decimal Step { get; set; } = 1m;

        [Parameter]
        public EventCallback<decimal?> ValueChanged { get; set; }   

        [Parameter]
        public EventCallback<UIFocusEventArgs> OnFocus { get; set; }

        [Parameter]
        public EventCallback<UIFocusEventArgs> OnFocusOut { get; set; }

        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyPress { get; set; }

        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyDown { get; set; }

        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyUp { get; set; }

        [Parameter]
        public EventCallback<UIChangeEventArgs> OnInput { get; set; }

        [Parameter]
        public string Label { get; set; }

        public string PlusIcon { get; set; } = "add";

        public string MinusIcon { get; set; } = "remove";

        [Parameter]
        public bool Box { get; set; }

        [Parameter]
        public bool Dense { get; set; }

        [Parameter]
        public bool Outlined { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// When true, it specifies that an input field is read-only.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool FullWidth { get; set; }

        [Parameter]
        public bool Required { get; set; }

        [Parameter]
        public string HelperText { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; }

        [Parameter]
        public bool HideClearButton { get; set; }

        [Parameter]
        public string Type { get; set; } = "number";


        /// <summary>
        /// Css class of input element
        /// </summary>
        [Parameter]
        public string InputClass     
        {
            get => _inputClass;
            set
            {
                _inputClass = value;
                InputClassMapper.MakeDirty();
            }
        }
        /// <summary>
        /// Style attribute of input element
        /// </summary>

        [Parameter]
        public string InputStyle { get; set; }

        protected ClassMapper LabelClassMapper = new ClassMapper();
        protected ClassMapper InputClassMapper = new ClassMapper();

        private decimal? _value; // obj-type
        private string _bindedValue;
        private string _inputClass;

        public BaseMatNumericUpDownField()
        {
            ClassMapper
                .Add("mat-numericUpDownField")
                .Add("mdc-text-field")
                .Add("_mdc-text-field--upgraded")
                .If("mdc-text-field--with-leading-icon", ()=>true)
                .If("mdc-text-field--with-trailing-icon", () => true)
                .If("mdc-text-field--invalid", () => this.InvalidInput )
                .If("mdc-text-field--box", () => !this.FullWidth && this.Box)
                .If("mdc-text-field--dense", () => Dense)
                .If("mdc-text-field--outlined", () => !this.FullWidth && this.Outlined)
                .If("mdc-text-field--disabled", () => this.Disabled)
                .If("mdc-text-field--fullwidth", () => this.FullWidth)
                .If("mdc-text-field--fullwidth-with-leading-icon",
                    () => true)
                .If("mdc-text-field--fullwidth-with-trailing-icon",
                    () => true);

            LabelClassMapper
                .Add("mdc-floating-label")
                .If("mdc-floating-label--float-above", () => true); // obj-type: !string.IsNullOrEmpty(Value)

            InputClassMapper
                .Get(() => this.InputClass)
                .Add("mdc-text-field__input")
                .If("_mdc-text-field--upgraded", () => true) // obj-type: !string.IsNullOrEmpty(Value)
                .If("mat-hide-clearbutton", () => this.HideClearButton);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matNumericUpDownField.init", Ref);
        }

        private void Sanitize()
        {
            if (!Value.HasValue)
            {
                Value = 0m;
                return;
            }

            if (Value.Value > (Maximum ?? Decimal.MaxValue))
            {
                Value = (Maximum ?? Decimal.MaxValue);
                return;
            }

            if (Value.Value < (Minimum ?? Decimal.MinValue))
            {
                Value = (Minimum ?? Decimal.MinValue);
            }

        }

        protected void Increase()
        {
            Value = (Value ?? -this.Step ) + this.Step;
            Sanitize();
        }

        protected void Decrease()
        {
            Value = (Value ?? +this.Step ) - this.Step;
            Sanitize();
        }
    }
}