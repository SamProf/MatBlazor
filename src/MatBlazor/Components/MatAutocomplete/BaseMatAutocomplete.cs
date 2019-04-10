using MatBlazor.Components.Base;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Components.MatAutocomplete
{
    /// <summary>
    /// The autocomplete is a normal text input enhanced by a panel of suggested options.
    /// </summary>
    /// <typeparam name="ItemType">Type of element type.</typeparam>
    public class BaseMatAutocomplete<ItemType> : BaseMatComponent
    {
        protected const int DefaultsElementsInPopup = 10;
        private bool isOpened;
        private string stringValue;
        private ItemType _value;

        protected IEnumerable<AutocompleteElementWrapper<ItemType>> GetFilteredCollection(string searchText)
        {
            return Collection.Select(x => new AutocompleteElementWrapper<ItemType>()
            {
                StringValue = ComputeStringValue(x),
                Element = x
            })
            .Where(x => x != null &&
            (string.IsNullOrEmpty(searchText) || x.StringValue.ToLowerInvariant().Contains(searchText.ToLowerInvariant())))
            .Take(NumberOfElementsInPopup ?? DefaultsElementsInPopup);
        }

        protected bool IsShowingClearButton
        {
            get => ShowClearButton && !string.IsNullOrEmpty(this.StringValue);
        }

        public bool IsOpened
        {
            get
            {
                return isOpened;
            }
            set
            {
                isOpened = value;
                OnOpenedChanged.InvokeAsync(value);
                this.StateHasChanged();
            }
        }

        /// <summary>
        /// Maximum number of elements displayed in the popup
        /// </summary>
        [Parameter]
        protected int? NumberOfElementsInPopup { get; set; }

        /// <summary>
        /// The label of the TextField
        /// </summary>
        [Parameter]
        protected string Label { get; set; }

        /// <summary>
        /// The Icon displayed as the leading icon for the TextField
        /// </summary>
        [Parameter]
        protected string Icon { get; set; }

        /// <summary>
        /// The StringValue displayed in the TextField
        /// </summary>
        [Parameter]
        protected string StringValue
        {
            get
            {
                return stringValue;
            }
            set
            {
                stringValue = value;
                OnTextChanged.InvokeAsync(value);
            }
        }
       
        /// <summary>
        /// The value to be used to pre-select an item from the list
        /// </summary>
        [Parameter]
        protected ItemType Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                StringValue = Value == default ? string.Empty : ComputeStringValue(Value);
                ValueChanged.InvokeAsync(_value);
            }
        }

        /// <summary>
        /// ValueChanged is fired when the value is selected(by clicking on an element in the popup)
        /// </summary>
        [Parameter]
        protected EventCallback<object> ValueChanged { get; set; }

        /// <summary>
        /// ItemTemplate is used to render the elements in the popup if no template is given then the string value of the objects is displayed..
        /// </summary>
        [Parameter]
        protected RenderFragment<ItemType> ItemTemplate { get; set; }

        /// <summary>
        /// This function is used to select the string part from the item, used both for filtering and displaying if no ItemTemplate is defined.
        /// </summary>
        [Parameter]
        protected Func<ItemType, string> CustomStringSelector { get; set; }

        /// <summary>
        /// The collection which should be rendered and filtered
        /// </summary>
        [Parameter]
        protected IEnumerable<ItemType> Collection { get; set; }

        /// <summary>
        /// If this parameter is true then the style of the textbox is outlined see `MatTextfield`
        /// </summary>
        [Parameter]
        protected bool Outlined { get; set; }

        /// <summary>
        /// OnOpenedChanged is fired when the popup dialog is opened or close and the parameter indicates whenever is it open, the default value is false
        /// </summary>
        [Parameter]
        protected EventCallback<bool> OnOpenedChanged { get; set; }

        /// <summary>
        /// OnTextChanged is fired when the string value is changed(when an input occurs in the textfield or when an item is selected)
        /// </summary>
        [Parameter]
        protected EventCallback<string> OnTextChanged { get; set; }

        /// <summary>
        /// This value indicates if the clear button(using a trailing icon) should be displayed, which can clear the entire text and the selected value), the default value is false
        /// </summary>
        [Parameter]
        protected bool ShowClearButton { get; set; }

        /// <summary>
        /// This value indicates if the textfield and the dialog will be or not displayed in the full screen, the default value is false
        /// </summary>
        [Parameter]
        protected bool FullWidth { get; set; }

        protected void OpenPopup()
        {
            IsOpened = true;
        }

        protected void ClosePopup()
        {
            IsOpened = false;
        }

        public void OnValueChanged(UIChangeEventArgs ev)
        {
            StringValue = (string)ev.Value;
            StateHasChanged();
        }

        public void ItemClicked(ItemType selectedObject)
        {
            Value = selectedObject;
            StateHasChanged();
        }

        public void ClearText(UIMouseEventArgs e)
        {
            Value = default;
            StateHasChanged();
        }

        protected ClassMapper WrapperClassMapper = new ClassMapper();

        public BaseMatAutocomplete()
        {
            WrapperClassMapper.Add("mat-autocomplete-wrapper")
                              .If("mat-autocomplete-wrapper-fullwidth", () => FullWidth);
        }

        private string ComputeStringValue(ItemType obj)
        {
            return CustomStringSelector?.Invoke(obj) ?? obj?.ToString();
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matAutocomplete.init", Ref);
        }
    }
}
