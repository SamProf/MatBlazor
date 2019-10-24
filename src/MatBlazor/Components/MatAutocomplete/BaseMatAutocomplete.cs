using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    /// <summary>
    /// The autocomplete is a normal text input enhanced by a panel of suggested options.
    /// </summary>
    /// <typeparam name="ItemType">Type of element type.</typeparam>
    public class BaseMatAutocomplete<ItemType> : BaseMatDomComponent
    {
        protected const int DefaultsElementsInPopup = 10;
        private bool isOpened;
        private string stringValue;
        private ItemType _value;

        public MatList ListRef;

        protected IEnumerable<AutocompleteElementWrapper<ItemType>> GetFilteredCollection(string searchText)
        {
            return Collection.Select(x => new AutocompleteElementWrapper<ItemType>()
            {
                StringValue = ComputeStringValue(x),
                Element = x
            })
                .Where(x => x != null &&
                            (string.IsNullOrEmpty(searchText) || x.StringValue.ToLowerInvariant()
                                 .Contains(searchText.ToLowerInvariant())))
                .Take(NumberOfElementsInPopup ?? DefaultsElementsInPopup);
        }

        protected bool IsShowingClearButton
        {
            get => ShowClearButton && !string.IsNullOrEmpty(this.StringValue);
        }

        public bool IsOpened
        {
            get { return isOpened; }
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
        public int? NumberOfElementsInPopup { get; set; }

        /// <summary>
        /// The label of the TextField
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// The Icon displayed as the leading icon for the TextField
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// The StringValue displayed in the TextField
        /// </summary>
        [Parameter]
        public string StringValue
        {
            get { return stringValue; }
            set
            {
                stringValue = value;
                OnTextChanged.InvokeAsync(value);
            }
        }

        /// <summary>
        /// This value is only returned for use in ValueExpression (required to make MatAutocomplete work inside EditForms).
        /// </summary>
        protected string DummyValue
        {
            get
            {
                return " ";
            }
            set { }
        }

        /// <summary>
        /// The value to be used to pre-select an item from the list
        /// </summary>
        [Parameter]
        public ItemType Value
        {
            get { return _value; }
            set
            {
                if (EqualValues(value, _value))
                {
                    return;
                }

                _value = value;
                StringValue = EqualValues(Value, default(ItemType)) ? string.Empty : ComputeStringValue(Value);
                ValueChanged.InvokeAsync(_value);
            }
        }

        private static bool EqualValues(ItemType a1, ItemType a2)
        {
            return EqualityComparer<ItemType>.Default.Equals(a1, a2);
        }

        /// <summary>
        /// ValueChanged is fired when the value is selected(by clicking on an element in the popup)
        /// </summary>
        [Parameter]
        public EventCallback<ItemType> ValueChanged { get; set; }

        /// <summary>
        /// ItemTemplate is used to render the elements in the popup if no template is given then the string value of the objects is displayed..
        /// </summary>
        [Parameter]
        public RenderFragment<ItemType> ItemTemplate { get; set; }

        /// <summary>
        /// This function is used to select the string part from the item, used both for filtering and displaying if no ItemTemplate is defined.
        /// </summary>
        [Parameter]
        public Func<ItemType, string> CustomStringSelector { get; set; }

        /// <summary>
        /// The collection which should be rendered and filtered
        /// </summary>
        [Parameter]
        public IEnumerable<ItemType> Collection { get; set; }

        /// <summary>
        /// If this parameter is true then the style of the textbox is outlined see `MatTextfield`
        /// </summary>
        [Parameter]
        public bool Outlined { get; set; }

        /// <summary>
        /// OnOpenedChanged is fired when the popup dialog is opened or close and the parameter indicates whenever is it open, the default value is false
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnOpenedChanged { get; set; }

        /// <summary>
        /// OnTextChanged is fired when the string value is changed(when an input occurs in the textfield or when an item is selected)
        /// </summary>
        [Parameter]
        public EventCallback<string> OnTextChanged { get; set; }

        /// <summary>
        /// This value indicates if the clear button(using a trailing icon) should be displayed, which can clear the entire text and the selected value), the default value is false
        /// </summary>
        [Parameter]
        public bool ShowClearButton { get; set; }

        /// <summary>
        /// This value indicates if the textfield and the dialog will be or not displayed in the full screen, the default value is false
        /// </summary>
        [Parameter]
        public bool FullWidth { get; set; }

        protected void OpenPopup()
        {
            IsOpened = true;
        }

        protected void ClosePopup()
        {
            IsOpened = false;
        }

        public void OnValueChanged(ChangeEventArgs ev)
        {
            StringValue = (string)ev.Value;
            StateHasChanged();
        }

        public async void OnKeyDown(KeyboardEventArgs ev)
        {
            if (ev.Key == "ArrowDown" || ev.Key == "ArrowUp")
            {
                int currentIndex = await ListRef.GetSelectedIndex();
                int nextIndex = (ev.Key == "ArrowDown") ? currentIndex++ : currentIndex--;
                await ListRef.SetSelectedIndex(currentIndex);
            }
            else if (ev.Key == "Enter")
            {
                await JsInvokeAsync<object>("matBlazor.matList.confirmSelection", ListRef.Ref);
            }
        }

        public void ItemClicked(ItemType selectedObject)
        {
            Value = selectedObject;
            StateHasChanged();
        }

        public void ClearText(MouseEventArgs e)
        {
            Value = default;
            StringValue = string.Empty;
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
            await JsInvokeAsync<object>("matBlazor.matAutocomplete.init", Ref);
        }
    }
}
