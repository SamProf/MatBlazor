using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public string MatBlazorId = "matBlazorId_" + Guid.NewGuid();

        protected ClassMapper ClassMapper { get; } = new ClassMapper();

        [Inject]
        protected IJSRuntime Js { get; set; }

        private List<Func<Task>> afterRenderCallStack = new List<Func<Task>>();

        private bool isRendered = false;


        protected void CallAfterRender(Action action)
        {
            afterRenderCallStack.Add(() => { return Task.Run(action); });
        }

        protected void CallAfterRender(Func<Task> action)
        {
            afterRenderCallStack.Add(action);
        }

        protected async override Task OnAfterRenderAsync()
        {
            if (!isRendered)
            {
                await OnFirstAfterRenderAsync();
                isRendered = true;
            }

            foreach (var action in afterRenderCallStack)
            {
                await action();
            }

            afterRenderCallStack.Clear();
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


        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                this.StateHasChanged();
            }
        }

        private string _class;
        private string _style;
    }
}