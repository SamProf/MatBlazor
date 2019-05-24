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

        [Parameter]
        public decimal Value  // obj-type
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    LabelClassMapper.MakeDirty();
                    InputClassMapper.MakeDirty();
                    ValueChanged.InvokeAsync(value);
                }
            }
        }

        protected string BindedValue  // obj-type
        {
            get => Value.ToString();
            set
            {
                bool hasChanged = value != Value.ToString();
                if (!hasChanged) return;

                bool isDecimal = decimal.TryParse( value, out decimal valueAux );
                if (!isDecimal && MatchToBetterValue ) 
                {
                    Value = 0;
                    return;
                }

                if ( isDecimal && valueAux < Minimum && MatchToBetterValue)
                {
                    Value = Math.Round(Minimum, DecimalPlaces);
                    return;
                }

                if ( isDecimal && valueAux > Maximum && MatchToBetterValue)
                {
                    Value = Math.Round(Maximum, DecimalPlaces);
                    return;
                }

                if (valueAux != Math.Round(valueAux, DecimalPlaces) && MatchToBetterValue)
                {
                    Value = Math.Round(valueAux, DecimalPlaces);
                    return;
                }
                Value = valueAux;                
            }
        }

        [Parameter]
        public decimal Maximum { get; set; }  = 100;

        [Parameter]
        public decimal Minimum { get; set; }  = 0;

        [Parameter]
        public int DecimalPlaces { get; set; } = 0;
        protected string Step => DecimalPlaces<=0?"1": $"0.{new String('0', DecimalPlaces-1 )}1";

        [Parameter]
        public bool MatchToBetterValue { get; set; } = false; // Move value to closed valid value. Dangerous because UI doesn't refresh.

        [Parameter]
        public EventCallback<decimal> ValueChanged { get; set; }   
  
        [Parameter]
        public EventCallback<UIMouseEventArgs> IconOnClick { get; set; }

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

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public bool IconTrailing { get; set; }

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

        private decimal _value; // obj-type
        private string _inputClass;

        public BaseMatNumericUpDownField()
        {
            ClassMapper
                .Add("mdc-text-field")
                .Add("_mdc-text-field--upgraded")
                .If("mdc-text-field--with-leading-icon", () => this.Icon != null && !this.IconTrailing)
                .If("mdc-text-field--with-trailing-icon", () => this.Icon != null && this.IconTrailing)
                .If("mdc-text-field--box", () => !this.FullWidth && this.Box)
                .If("mdc-text-field--dense", () => Dense)
                .If("mdc-text-field--outlined", () => !this.FullWidth && this.Outlined)
                .If("mdc-text-field--disabled", () => this.Disabled)
                .If("mdc-text-field--fullwidth", () => this.FullWidth)
                .If("mdc-text-field--fullwidth-with-leading-icon",
                    () => this.FullWidth && this.Icon != null && !this.IconTrailing)
                .If("mdc-text-field--fullwidth-with-trailing-icon",
                    () => this.FullWidth && this.Icon != null && this.IconTrailing);

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
            await Js.InvokeAsync<object>("matBlazor.matTextField.init", Ref);
        }
    }
}