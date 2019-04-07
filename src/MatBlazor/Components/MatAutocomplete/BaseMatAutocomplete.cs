using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Components.MatAutocomplete
{
    public class BaseMatAutocomplete<ItemType> : BaseMatComponent
    {
        protected const int DefaultsElementsInPopup = 10;
        private bool isOpened;
        private string stringValue;
        private ItemType _value;

        protected IEnumerable<AutocompleteElementWrapper<ItemType>> FilteredCollection
        {
            get
            {
                return Collection.Select(x => new AutocompleteElementWrapper<ItemType>()
                {
                    StringValue = ComputeStringValue(x),
                    Element = x
                })
                .Where(x => x != null &&
                (string.IsNullOrEmpty(StringValue) || x.StringValue.ToLowerInvariant().Contains(StringValue.ToLowerInvariant())))
                .Take(NumberOfElementsInPopup ?? DefaultsElementsInPopup);
            }
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

        [Parameter]
        protected int? NumberOfElementsInPopup { get; set; }

        [Parameter]
        protected string Label { get; set; }

        [Parameter]
        protected string Icon { get; set; }

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
                OnStringValueChanged.InvokeAsync(value);
            }
        }

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
                ValueChanged.InvokeAsync(_value);
            }
        }

        [Parameter]
        protected EventCallback<object> ValueChanged { get; set; }

        [Parameter]
        protected RenderFragment<ItemType> ItemTemplate { get; set; }

        [Parameter]
        protected Func<ItemType, string> CustomStringSelector { get; set; }

        [Parameter]
        protected IEnumerable<ItemType> Collection { get; set; }

        [Parameter]
        protected bool Outlined { get; set; }

        [Parameter]
        protected EventCallback<bool> OnOpenedChanged { get; set; }

        [Parameter]
        protected EventCallback<string> OnStringValueChanged { get; set; }

        [Parameter]
        protected EventCallback<string> OnTextChanged { get; set; }

        [Parameter]
        protected bool ShowClearButton { get; set; }

        [Parameter]
        protected bool FullWidth { get; set; }

        [Parameter]
        public bool AllowFreeText { get; protected set; }

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
            var filteredWrapper = FilteredCollection.FirstOrDefault();
            Value = filteredWrapper != null ? filteredWrapper.Element : (default);
            if (Value == null && !AllowFreeText)
            {
                StringValue = string.Empty;
            }
            StateHasChanged();
        }

        public void ItemClicked(ItemType selectedObject)
        {
            Value = selectedObject;
            StringValue = ComputeStringValue(Value);
            StateHasChanged();
        }

        public void ClearText(UIMouseEventArgs e)
        {
            StringValue = "";
            Value = default;
            StateHasChanged();
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
