using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.MatAutocompleteList;
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
        private AutocompleteListSearchResult<TItem> searchResult;
        public MatList ListRef;

        protected IEnumerable<MatAutocompleteListItem<TItem>> GetFilteredCollection(string searchText)
        {
            if (searchResult == null || searchResult.SearchText != searchText)
            {
                searchResult = new AutocompleteListSearchResult<TItem>()
                {
                    SearchText = searchText,
                    ListResult = Items.Select(x => new MatAutocompleteListItem<TItem>()
                    {
                        StringValue = ComputeStringValue(x),
                        Item = x
                    })
                                       .Where
                                       (
                                            x => x != null
                                                 && (string.IsNullOrEmpty(searchText)
                                                     || x.StringValue.ToLowerInvariant().Contains(searchText.ToLowerInvariant())
                                                    )
                                        )
                                       .Take(NumberOfElementsInPopup ?? DefaultsElementsInPopup)
                                       .ToList()
                };
            }
            return searchResult.ListResult;
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
                if (!EqualValues(value, default))
                {
                    var newValue = ComputeStringValue(value);
                    if (newValue != StringValue)
                    {
                        StringValue = newValue;
                    }
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
                ValueChanged.InvokeAsync(_value);
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
            if (ev.Key == null ||   // google autofill sends null key
                ev.Key == "Tab")    // user navigates to next field
            {
                return;
            }
            var currentIndex = await ListRef.GetSelectedIndex();
            var wasCurrentIndexChanged = false;

            if (currentIndex < 0)
            {
                currentIndex = 0;
                wasCurrentIndexChanged = true;
            }

            if (searchResult != null && searchResult.ListResult.Count > 0 && currentIndex > searchResult.ListResult.Count)
            {
                currentIndex = searchResult.ListResult.Count - 1;
                wasCurrentIndexChanged = true;
            }

            if (ev.Key == "ArrowDown")
            {
                currentIndex++;
                wasCurrentIndexChanged = true;
            }
            else if (ev.Key == "ArrowUp")
            {
                currentIndex--;
                wasCurrentIndexChanged = true;
            }

            if (wasCurrentIndexChanged)
            {
                await ListRef.SetSelectedIndex(currentIndex);
            }

            if (ev.Key == "Enter" && searchResult != null && currentIndex >= 0 && currentIndex < searchResult.ListResult.Count)
            {
                ItemSelected(searchResult.ListResult[currentIndex].Item);
            }
        }

        public void ItemSelected(TItem selectedObject)
        {
            Value = selectedObject;
            StateHasChanged();
        }

        /// <summary>
        /// Clears current value of the autocomplete text
        /// </summary>
        /// <param name="e"></param>
        public void ClearText(EventArgs e)
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
    }
}
