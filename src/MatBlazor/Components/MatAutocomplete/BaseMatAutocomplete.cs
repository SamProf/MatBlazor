using MatBlazor.Components.Base;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Components.MatAutocomplete
{
    //TODO: Modify to generic class when generic components will be available in blazor
    public class BaseMatAutocomplete : BaseMatComponent
    {

        protected const int DefaultsElementsInPopup = 10;
        private bool isOpened;
        private string stringValue;

        protected IEnumerable FilteredCollection
        {
            get
            {
                return Collection.Cast<object>()
                      .Select(x => x.ToString())
                      .Where(x => x != null &&
                      (string.IsNullOrEmpty(StringValue) || x.ToLowerInvariant().Contains(StringValue.ToLowerInvariant())))
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
                OnOpenedChanged?.Invoke(value);
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
                OnStringValueChanged?.Invoke(value);
            }
        }

        [Parameter]
        protected object Value { get; set; }

        [Parameter]
        protected Action<object> OnChange { get; set; }

        [Parameter]
        protected IEnumerable Collection { get; set; }

        [Parameter]
        protected bool Outlined { get; set; }

        [Parameter]
        protected Action<bool> OnOpenedChanged { get; set; }

        [Parameter]
        protected Action<string> OnStringValueChanged { get; set; }

        [Parameter]
        protected Action<string> OnTextChanged { get; set; }

        [Parameter]
        protected bool ShowClearButton { get; set; }

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

        public void ItemClicked(object selectedObject)
        {
            Console.WriteLine("An item is clicked: " + selectedObject);
            Value = selectedObject;
            StringValue = Value.ToString();
            OnChange.Invoke(selectedObject);
            StateHasChanged();
        }

        public void ClearText(UIMouseEventArgs e)
        {
            Console.WriteLine("Clear text started");
            StringValue = "";
            Value = null;
            StateHasChanged();
        }


        public BaseMatAutocomplete()
        {

        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matAutocomplete.init", Ref);
        }
    }
}
