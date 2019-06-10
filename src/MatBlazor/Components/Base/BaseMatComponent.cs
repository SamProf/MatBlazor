using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public abstract class BaseMatComponent : ComponentBase, IBaseMatComponent, IDisposable
    {
        [Parameter]
        public ForwardRef RefBack { get; set; }

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

            if (afterRenderCallQuene.Count > 0)
            {
                var actions = afterRenderCallQuene.ToArray();
                afterRenderCallQuene.Clear();

                foreach (var action in actions)
                {
                    if (Disposed)
                    {
                        return;
                    }
                    await action();
                }
            }
        }

        protected async virtual Task OnFirstAfterRenderAsync()
        {
        }

        protected BaseMatComponent()
        {
        }

        public void Dispose()
        {
            Disposed = true;
        }

        protected bool Disposed { get; private set; }
    }
}