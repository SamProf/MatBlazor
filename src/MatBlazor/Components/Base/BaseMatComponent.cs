using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public abstract class BaseMatComponent : ComponentBase
    {
        /// <summary>
        /// Returned ElementRef reference for DOM element.
        /// </summary>
        public ElementRef Ref { get; set; }

        public string MatBlazorId = "matBlazorId_" + Guid.NewGuid();

        protected ClassMapper ClassMapper { get; } = new ClassMapper();

        [Inject]
        protected IJSRuntime Js { get; set; }

        private Queue<Func<Task>> afterRenderCallQuene = new Queue<Func<Task>>();

        private bool isRendered = false;


       protected void CallAfterRender(Func<Task> action)
        {
            afterRenderCallQuene.Enqueue(action);
        }

        protected async override Task OnAfterRenderAsync()
        {
            if (!isRendered)
            {
                await OnFirstAfterRenderAsync();
                isRendered = true;
            }

            Func<Task> action;
            while (afterRenderCallQuene.Count > 0)
            {
                action = afterRenderCallQuene.Dequeue();
                await action();
            }
        }

        protected async virtual Task OnFirstAfterRenderAsync()
        {
        }

        protected BaseMatComponent()
        {
            ClassMapper.Get(() => this.Class);
        }

        /// <summary>
        /// Specifies one or more classnames for an DOM element.
        /// </summary>
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


        /// <summary>
        /// Specifies an inline style for an DOM element.
        /// </summary>
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