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
    /// <typeparam name="TItem">Type of element type.</typeparam>
    public class BaseMatAutocompleteList<TItem> : BaseMatDomComponent
    {
        protected const int DefaultsElementsInPopup = 10;
        private bool isOpened;
        private string stringValue;
        private TItem _value;

        public MatList ListRef;

        protected IEnumerable<MatAutocompleteListItem<TItem>> GetFilteredCollection(string searchText)
        {
            return Items.Select(x => new MatAutocompleteListItem<TItem>()
            {
                StringValue = ComputeStringValue(x),
                Item = x
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
        /// The value to be used to pre-select an item from the list
        /// </summary>
        [Parameter]
        public TItem Value
        {
            get { return _value; }
            set
            {
                var newerStringValue = EqualValues(value, default) ? string.Empty : ComputeStringValue(value);
                if(newerStringValue != StringValue)
                {
                    StringValue = newerStringValue;
                }

                if (EqualValues(value, _value))
                {
                    return;
                }

                _value = value;
                ValueChanged.InvokeAsync(_value);
            }
        }

        private static bool EqualValues(TItem a1, TItem a2)
        {
            return EqualityComparer<TItem>.Default.Equals(a1, a2);
        }

        /// <summary>
        /// ValueChanged is fired when the value is selected(by clicking on an element in the popup)
        /// </summary>
        [Parameter]
        public EventCallback<TItem> ValueChanged { get; set; }

        /// <summary>
        /// ItemTemplate is used to render the elements in the popup if no template is given then the string value of the objects is displayed..
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        /// <summary>
        /// This function is used to select the string part from the item, used both for filtering and displaying if no ItemTemplate is defined.
        /// </summary>
        [Parameter]
        public Func<TItem, string> CustomStringSelector { get; set; }

        /// <summary>
        /// The collection which should be rendered and filtered
        /// </summary>
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

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
            if (StringValue != ComputeStringValue(Value))
            {
                _value = default;
            }
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

        public void ItemClicked(TItem selectedObject)
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

        public BaseMatAutocompleteList()
        {
            WrapperClassMapper
                .Add("mat-autocomplete-list")
                .Add("mat-autocomplete-list-wrapper")
                .If("mat-autocomplete-list-wrapper-fullwidth", () => FullWidth);
        }

        private string ComputeStringValue(TItem obj)
        {
            return CustomStringSelector?.Invoke(obj) ?? obj?.ToString();
        }

        //        protected async override Task OnFirstAfterRenderAsync()
        //        {
        //            await base.OnFirstAfterRenderAsync();
        //            await JsInvokeAsync<object>("matBlazor.matAutocomplete.init", Ref);
        //        }
    }
}
