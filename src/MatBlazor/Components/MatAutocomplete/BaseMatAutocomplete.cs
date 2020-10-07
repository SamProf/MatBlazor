using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatBlazor
{
    public class BaseMatAutocomplete<TValue, TItem> : MatInputTextComponent<TValue>
    {
        protected BaseMatMenu MenuRef;

        protected const int DefaultsElementsInPopup = 10;

        protected BaseMatList ListRef;

        [Parameter]
        public IEnumerable<TItem> Items { get; set; }
        
        public bool IsOpened { get; set; }


        public BaseMatAutocomplete()
        {
            OnFocusEvent.Event += OnFocusEvent_Event;
            OnFocusOutEvent.Event += OnFocusOutEvent_Event;
//            ClassMapper.Add("mat-autocomplete");
        }

        private void OnFocusEvent_Event(object sender, Microsoft.AspNetCore.Components.Web.FocusEventArgs e)
        {
            IsOpened = true;
            CallAfterRender(async () =>
            {
                await MenuRef.OpenAsync(InputRef);
            });
        }
        
        private void OnFocusOutEvent_Event(object sender, Microsoft.AspNetCore.Components.Web.FocusEventArgs e)
        {
//            IsOpened = false;
        }


        /// <summary>
        /// This function is used to select the string part from the item, used both for filtering and displaying if no ItemTemplate is defined.
        /// </summary>
        [Parameter]
        public Func<TItem, TValue> ItemValueSelector { get; set; }

        private TValue ComputeItemValue(TItem obj)
        {
            if (ItemValueSelector != null)
            {
                return ItemValueSelector.Invoke(obj);
            }
            return SwitchT.ParseFromString(obj?.ToString(), Format);
        }

        /// <summary>
        /// Maximum number of elements displayed in the popup
        /// </summary>
        [Parameter]
        public int? NumberOfElementsInPopup { get; set; }

        public void ItemClicked(MatAutocompleteItem<TValue, TItem> selectedObject)
        {
//            todo: Value = selectedObject.Item;
            StateHasChanged();
        }


        /// <summary>
        /// ItemTemplate is used to render the elements in the popup if no template is given then the string value of the objects is displayed..
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        protected IEnumerable<MatAutocompleteItem<TValue, TItem>> GetFilteredCollection(string searchText)
        {
            return Items.Select(x => new MatAutocompleteItem<TValue, TItem>()
                {
                    Value = ComputeItemValue(x),
                    Item = x
                })
                .Where(x => string.IsNullOrEmpty(searchText) 
                            || (SwitchT.FormatValueAsString(x.Value, Format)?.ToLowerInvariant().Contains(searchText?.ToLowerInvariant()) == true))
                .Take(NumberOfElementsInPopup ?? DefaultsElementsInPopup);
        }
    }
}
