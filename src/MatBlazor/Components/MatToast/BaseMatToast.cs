using System;
using Microsoft.AspNetCore.Components;
using MatBlazor.Components.MatToast;
using MatBlazor.MatToaster.Helpers;


namespace MatBlazor
{
    /// <summary>
    /// Toasts provide brief notifications or messages about app processes
    /// </summary>
    public class BaseMatToast : BaseMatDomComponent, IDisposable
    {
        [Parameter]
        protected IBaseMatToast Toast { get; set; }

        protected RenderFragment Css;

        public string Title => Toast.Title;

        public string Message => Toast.Message;

        public void Clicked(UIEventArgs args) => Toast.Clicked(false);
        public void CloseIconClicked(UIEventArgs args) => Toast.Clicked(true);
        public void MouseEnter(UIEventArgs args) => Toast.MouseEnter();
        public void MouseLeave(UIEventArgs args) => Toast.MouseLeave();

        protected override void OnParametersSet()
        {
            Toast.OnUpdate += ToastUpdated;
            Toast.EnsureInitialized();

            Css = builder =>
            {
                var transitionClass = Toast.TransitionClass;
                if (string.IsNullOrEmpty(transitionClass)) return;

                builder.OpenElement(1, "style");
                builder.AddContent(2, transitionClass);
                builder.CloseElement();
            };
        }

        private void ToastUpdated()
        {
            Invoke(StateHasChanged);
        }

        public void Dispose()
        {
            if (Toast != null)
            {
                Toast.OnUpdate -= ToastUpdated;
            }
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }
                       
        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public ToastType Type { get; set; }
                     
        public BaseMatToast()
        {

        }
    }
}
