using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public abstract class BaseMatField<T> : BaseMatDomComponent
    {
        [Parameter]
        public string Type { get; set; } = "text";

        public ElementRef InputRef { get; set; }

        private T _value;

        [Parameter]
        public T Value
        {
            get => _value;
            set
            {
                if (!EqualityComparer<T>.Default.Equals(value, _value))
                {
                    _value = value;
                    _valueAsString = ConvertFromValue(value);
                    ValueChanged.InvokeAsync(value);
                }
            }
        }


        private string _valueAsString;

        protected string ValueAsString
        {
            get => _valueAsString;
            set
            {
                _valueAsString = value;
                Value = ConvertToValue(value);
            }
        }


        protected virtual T ConvertToValue(string value)
        {
            throw new NotImplementedException();
        }


        protected virtual string ConvertFromValue(T value)
        {
            throw new NotImplementedException();
        }
        
        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }

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
        public bool TextArea { get; set; }

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


        /// <summary>
        /// Css class of input element
        /// </summary>
        [Parameter]
        public string InputClass { get; set; }

        /// <summary>
        /// Style attribute of input element
        /// </summary>

        [Parameter]
        public string InputStyle { get; set; }

        protected ClassMapper LabelClassMapper = new ClassMapper();
        protected ClassMapper InputClassMapper = new ClassMapper();


        public BaseMatField()
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
                    () => this.FullWidth && this.Icon != null && this.IconTrailing)
                .If("mdc-text-field--textarea", () => this.TextArea);

            LabelClassMapper
                .Add("mdc-floating-label")
                .If("mdc-floating-label--float-above", () => !string.IsNullOrEmpty(Value?.ToString()));

            InputClassMapper
                .Get(() => this.InputClass)
                .Add("mdc-text-field__input")
                .If("_mdc-text-field--upgraded", () => !string.IsNullOrEmpty(Value?.ToString()))
                .If("mat-hide-clearbutton", () => this.HideClearButton);
        }
    }
}