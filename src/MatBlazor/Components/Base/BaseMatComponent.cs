using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.MatButton;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor.Components.Base
{
    public abstract class BaseMatComponent : ComponentBase
    {
        public ElementRef Ref { get; set; }

        protected string MatBlazorId = "matBlazorId_" + Guid.NewGuid();

        protected ClassMapper ClassMapper { get; } = new ClassMapper();

        [Inject]
        protected IJSRuntime Js { get; set; }

        private bool isRendered = false;

        protected async override Task OnAfterRenderAsync()
        {
            if (!isRendered)
            {
                await OnFirstAfterRenderAsync();
                isRendered = true;
            }
//            await base.OnAfterRenderAsync();
        }

        protected async virtual Task OnFirstAfterRenderAsync()
        {
        }

        protected BaseMatComponent()
        {
            ClassMapper.Get(() => this.Class);
        }

        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassMapper.MakeDirty();
            }
        }

        private string _class;
    }
}