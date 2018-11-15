using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;

namespace MatBlazor.Components.MatDrawer
{
    public class BaseMatDrawer : BaseMatComponent
    {
        public BaseMatDrawer()
        {
            ClassMapper
                .Add("mdc-drawer");
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matDrawer.init", Ref, new { });
        }
    }
}