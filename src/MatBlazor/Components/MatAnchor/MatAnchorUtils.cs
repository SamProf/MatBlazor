using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class MatAnchorUtils : ComponentBase, IDisposable
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        string Anchor { get; set; }

        bool ForceScroll { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            NavigationManager.LocationChanged += OnLocationChanged;
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ScrollToAnchor(forceScroll: true);
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            ScrollToAnchor(NavigationManager.ToAbsoluteUri(args.Location).Fragment);
        }

        void ScrollToAnchor(string anchor = "", bool forceScroll = false)
        {
            if (!string.IsNullOrEmpty(anchor) || forceScroll)
            {
                JSRuntime.InvokeAsync<string>("matBlazor.matAnchor.scrollToAnchor", anchor);
            }
        }

        void IDisposable.Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}