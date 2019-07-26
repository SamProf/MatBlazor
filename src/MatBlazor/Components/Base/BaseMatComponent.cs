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

        public virtual void Dispose()
        {
            Disposed = true;
        }

        protected bool Disposed { get; private set; }


        protected void InvokeStateHasChanged()
        {
            Invoke(StateHasChanged);
        }


        [Inject]
        protected IJSRuntime Js { get; set; }

        #region Hack to fix https://github.com/aspnet/AspNetCore/issues/11159

        public static object CreateDotNetObjectRefSyncObj = new object();

        protected DotNetObjectRef<T> CreateDotNetObjectRef<T>(T value) where T : class
        {
            lock (CreateDotNetObjectRefSyncObj)
            {
                JSRuntime.SetCurrentJSRuntime(Js);
                return DotNetObjectRef.Create(value);
            }
        }

        protected void DisposeDotNetObjectRef<T>(DotNetObjectRef<T> value) where T : class
        {
            if (value != null)
            {
                lock (CreateDotNetObjectRefSyncObj)
                {
                    JSRuntime.SetCurrentJSRuntime(Js);
                    value.Dispose();
                }
            }
        }

        #endregion
    }
}