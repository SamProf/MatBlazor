using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Text fields allow users to input, edit, and select text.
    /// </summary>
    public class BaseMatNumericUpDownField : BaseMatDomComponent
    {
        public ElementRef InputRef { get; set; }

        bool firstSet = true;
        protected bool InvalidInput { get; private set; }

        [Parameter]
        public decimal? Value  // obj-type
        {
            get => _value;
            set
            {
                // if is the same value
                if (value == _value)
                {
                    return;
                }

                ReduxSetValue(value);
            }
        }

        protected async void ReduxSetValue(decimal? value, bool isInvalid = false)
        {
            // update ui as usual.
            var _newUiBindedValue = (value?.ToString() ?? "").Trim();
            ChecIsValid(_newUiBindedValue);
            InvalidInput = InvalidInput || isInvalid;

            // if value is the same force update ui.
            // because virtual dom don't realize about change.
            if (_uiBindedValue == _newUiBindedValue)
            {
                // option JS:
                await Js.InvokeAsync<object>("matBlazor.matNumericUpDownField.setValue", Ref, _newUiBindedValue);
                return;
                // option Blazor:
                // _bindedValue = "                                       ";
                // await Task.Delay(1);
                // _bindedValue = _newbindedValue;
                // await Task.Delay(1);
                // StateHasChanged();
                // return;
            }

            _uiBindedValue = _newUiBindedValue;

            // set new value.
            _value = value;

            // set mappers.
            LabelClassMapper.MakeDirty();
            InputClassMapper.MakeDirty();

            if (!firstSet)
            {
                // don't say to user value changed on first set.
                await ValueChanged.InvokeAsync(value);
            }

            firstSet = false;
        }

        protected string UiBindedValue  // obj-type
        {
            get => _uiBindedValue;
            set
            {

                bool isDecimal = decimal.TryParse(value, out decimal valueAux);

                if (String.IsNullOrWhiteSpace(value))
                {
                    ReduxSetValue(null);
                }

                else if (!isDecimal)
                {
                    ReduxSetValue(null, true);
                    InvalidInput = true;
                }

                else
                {
                    valueAux = Sanitize(valueAux).Value;
                    ReduxSetValue(valueAux);
                }

            }
        }

        private void ChecIsValid(string value)
        {
            bool isDecimal = decimal.TryParse(value, out decimal valueAux);
            var isOk = isDecimal || String.IsNullOrWhiteSpace(value);
            InvalidInput = !isOk;
        }

        private decimal? Sanitize(decimal? value)
        {
            if (!value.HasValue)
            {
                return null;
            }

            else if (Minimum.HasValue && value.Value < Minimum.Value)
            {
                return Math.Round(Minimum.Value, DecimalPlaces);
            }

            else if (Maximum.HasValue && value.Value > Maximum)
            {
                return Math.Round(Maximum.Value, DecimalPlaces);
            }

            return Math.Round(value.Value, DecimalPlaces);

        }

        protected async void Increase()
        {
            decimal? value = (Value ?? -this.Step) + this.Step;
            value = Sanitize(value);
            ReduxSetValue(value);
        }

        protected async void Decrease()
        {
            decimal? value = (Value ?? +this.Step) - this.Step;
            value = Sanitize(value);
            ReduxSetValue(value);
        }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public EventCallback<UIMouseEventArgs> IconOnClick { get; set; }

        [Parameter]
        public decimal? Maximum { get; set; } = 100;

        [Parameter]
        public decimal? Minimum { get; set; } = 0;

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

        public string PlusIcon { get; set; } = "keyboard_arrow_down";

        public string MinusIcon { get; set; } = "keyboard_arrow_up";

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

        protected ClassMapper LabelClassMapper { set; get; } = new ClassMapper();
        protected ClassMapper InputClassMapper = new ClassMapper();

        //
        private decimal? _value; // obj-type
        private string _uiBindedValue;
        private string _inputClass;

        public BaseMatNumericUpDownField()
        {
            ClassMapper
                .Add("mat-numericUpDownField")
                .Add("mdc-text-field")
                .Add("_mdc-text-field--upgraded")
                .If("mdc-text-field--with-leading-icon", () => this.Icon != null )
                .If("mdc-text-field--with-trailing-icon", () => true)
                .If("mdc-text-field--invalid", () => this.InvalidInput )
                .If("mdc-text-field--box", () => !this.FullWidth && this.Box)
                .If("mdc-text-field--dense", () => Dense)
                .If("mdc-text-field--outlined", () => !this.FullWidth && this.Outlined)
                .If("mdc-text-field--disabled", () => this.Disabled)
                .If("mdc-text-field--fullwidth", () => this.FullWidth)
                .If("mdc-text-field--fullwidth-with-leading-icon",
                    () => this.FullWidth && this.Icon != null )
                .If("mdc-text-field--fullwidth-with-trailing-icon",
                    () => false);

            LabelClassMapper
                .Add("mdc-floating-label")
                .If("mat-floating-label--float-above-outlined", () => Outlined && !string.IsNullOrEmpty(UiBindedValue) )
                .If("mdc-floating-label--float-above", () => !string.IsNullOrEmpty(UiBindedValue));

            InputClassMapper
                .Get(() => this.InputClass)
                .Add("mdc-text-field__input")
                .If("_mdc-text-field--upgraded", () => !string.IsNullOrEmpty(UiBindedValue) )
                .If("mat-hide-clearbutton", () => this.HideClearButton);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matNumericUpDownField.init", Ref);
        }

    }
}
