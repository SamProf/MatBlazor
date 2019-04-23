using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mono.WebAssembly.Interop;

namespace MatBlazor
{
    public class BaseMatBlazorInstall : ComponentBase
    {
        protected EmbeddedContentItem[] Items;

        [Inject]
        protected IJSRuntime Js { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
            if (!(Js is MonoWebAssemblyJSRuntime))
            {
                var assemblies = new[] {this.GetType().Assembly};
                Items = assemblies.SelectMany(i => EmbeddedContentManager.Instance.GetItems(i)).ToArray();
            }
            else
            {
                Items = new EmbeddedContentItem[0];
            }
        }
    }
}