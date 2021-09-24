using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.MatAutocomplete;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    /// <summary>
    /// The autocomplete is a normal text input enhanced by a panel of suggested options.
    /// </summary>
    /// <typeparam name="TItem">Type of items.</typeparam>
    public class BaseMatAutocomplete<TItem> : MatInputTextComponent<string>
    {
        protected const int DefaultsElementsInPopup = 10;
        private bool isOpened;
        private TItem _value;
        protected AutocompleteSearchResult<TItem> SearchResult;
        protected MatList ListRef;
        protected ClassMapper WrapperClassMapper = new ClassMapper();

        protected BaseMatAutocomplete()
        {
            OnFocusEvent.Event += (sender, e) => OpenPopup();
            OnFocusOutEvent.Event += (sender, e) => ClosePopup();
            OnInputEvent.Event += (sender, e) => OnInputDetected(e);
            OnKeyDownEvent.Event += OnKeyDownHandler;

            WrapperClassMapper
                .Add("mat-autocomplete")
                .If("mat-autocomplete-fullwidth", () => FullWidth);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await CacheFilteredItemsAsync(Value);
        }

        protected async Task CacheFilteredItemsAsync(string searchText)
        {
            if (SearchResult == null || SearchResult.SearchText != searchText)
            {
                SearchResult = new AutocompleteSearchResult<TItem>()
                {
                    SearchText = searchText,
                    ListResult = ItemsSource != null
                        ? (await ItemsSource.GetFilteredItemsAsync(searchText))
                            .Select(item => new MatAutocompleteItem<TItem>() 
                            { 
                                Item = item,
                                Value = ComputeStringValue(item)
                            }).ToList()
                        : Items.Select(x => new MatAutocompleteItem<TItem>()
                        {
                            Value = ComputeStringValue(x),
                            Item = x
                        })
                                       .Where
                                       (
                                            x => x != null
                                                 && (string.IsNullOrEmpty(searchText)
                                                     || x.Value.ToLowerInvariant().Contains(searchText.ToLowerInvariant())
                                                    )
                                        )
                                       .Take(NumberOfElementsInPopup ?? DefaultsElementsInPopup)
                                       .ToList()
                };
                StateHasChanged();
            }
        }

        protected bool IsShowingClearButton
        {
            get => ShowClearButton && !string.IsNullOrEmpty(this.CurrentValueAsString);
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
        /// Gets or sets the maximum number of elements displayed in the dropdown list.
        /// </summary>
        [Parameter]
        public int? NumberOfElementsInPopup { get; set; }

        /// <summary>
        /// Gets or sets the selected item from the dropdown list.
        /// </summary>
        [Parameter]
        public TItem SelectedItem
        {
            get { return _value; }
            set
            {
                if (!EqualValues(value, default))
                {
                    var newValue = ComputeStringValue(value);
                    if (newValue != Value)
                    {
                        Value = newValue;
                    }
                }

                if (EqualValues(value, _value))
                {
                    return;
                }

                _value = value;
                SelectedItemChanged.InvokeAsync(_value);
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
        public EventCallback<TItem> SelectedItemChanged { get; set; }

        /// <summary>
        /// Gets or sets the template used to render the elements in the popup, if no template is given then the string value of the objects is displayed.
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets the function used to select the string part from the item, used both for filtering and displaying if no <seealse cref="ItemTemplate" /> is given.
        /// </summary>
        [Parameter]
        public Func<TItem, string> CustomStringSelector { get; set; }

        /// <summary>
        /// Gets or sets the items source which will be filtered and displayed in the dropdown list.
        /// </summary>
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the event callback which is invoked when the dialog is opened or closed. The parameter will be "true" if the dialog was opened, "false" otherwise.
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnOpenedChanged { get; set; }

        /// <summary>
        /// Gets or sets the visibility of the clear button. The default value is "false". If the clear button is displayed and pressed, the text and selected value will be cleared.
        /// </summary>
        [Parameter]
        public bool ShowClearButton { get; set; }

        /// <summary>
        /// Gets or sets the items source for autocomplete items. If provided, <seealso cref="Items"/> is ignored and everytime the user is typing something, this source will be used to populate the items in the dropdown list.
        /// </summary>
        [Parameter]
        public IAutocompleteItemsSource<TItem> ItemsSource { get; set; }

        protected void OpenPopup()
        {
            if (Disabled)
            {
                return;
            }
            IsOpened = true;
        }

        protected async void OnInputDetected(ChangeEventArgs ev)
        {
            Value = (string)ev.Value;
            if (SearchResult != null)
            {
                SearchResult = null;
            }
            // In case the filtering is switching on other thread, we want to update the dropdown with a progress bar until the filtering is done
            // so we're calling StateHasChanged.
            StateHasChanged();
            await CacheFilteredItemsAsync(Value);
        }

        protected async void ClosePopup()
        {
            if (!EqualValues(SelectedItem, default) && Value != ComputeStringValue(SelectedItem))
            {
                _value = default;
                await SelectedItemChanged.InvokeAsync(_value);
            }
            IsOpened = false;
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            ValueExpression = () => Value;
            return base.SetParametersAsync(parameters);
        }

        protected async void OnKeyDownHandler(object sender, KeyboardEventArgs ev)
        {
            var currentIndex = await ListRef.GetSelectedIndex();
            var wasCurrentIndexChanged = false;
            if (currentIndex < 0)
            {
                currentIndex = 0;
                wasCurrentIndexChanged = true;
            }
            if (SearchResult != null && SearchResult.ListResult.Count > 0 && currentIndex > SearchResult.ListResult.Count)
            {
                currentIndex = SearchResult.ListResult.Count - 1;
                wasCurrentIndexChanged = true;
            }
            if (ev.Key == "ArrowDown")
            {
                currentIndex++;
                wasCurrentIndexChanged = true;
            }
            if (ev.Key == "ArrowUp")
            {
                currentIndex--;
                wasCurrentIndexChanged = true;
            }
            if (ev.Key == "Backspace")
            {
                currentIndex = 0;
                wasCurrentIndexChanged = true;
            }
            if (ev.Key == "Tab")
            {
                return;
            }
            if (wasCurrentIndexChanged)
            {
                await ListRef.SetSelectedIndex(currentIndex);
            }

            if (ev.Key == "Enter" && SearchResult != null && currentIndex >= 0 && currentIndex < SearchResult.ListResult.Count)
            {
                ItemSelected(SearchResult.ListResult[currentIndex].Item);
            }
        }

        public void ItemSelected(TItem selectedObject)
        {
            SelectedItem = selectedObject;
            StateHasChanged();
        }

        /// <summary>
        /// Clears current value of the autocomplete text
        /// </summary>
        /// <param name="e"></param>
        public void ClearText(EventArgs e)
        {
            Value = default;
            SelectedItem = default;
            StateHasChanged();
        }

        private string ComputeStringValue(TItem obj)
        {
            return CustomStringSelector?.Invoke(obj) ?? obj?.ToString();
        }
    }
}
