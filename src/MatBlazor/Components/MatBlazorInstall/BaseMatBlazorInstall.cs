using System.Linq;
using System.Reflection;
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

        [Parameter]
        protected Assembly[] Assemblies { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
            if (!(Js is MonoWebAssemblyJSRuntime))
            {
                var assemblies = new[] {this.GetType().Assembly}.Union(Assemblies ?? new Assembly[0]);

                Items = assemblies.SelectMany(i => EmbeddedContentManager.Instance.GetItems(i)).ToArray();
            }
            else
            {
                Items = new EmbeddedContentItem[0];
            }
        }
    }
}