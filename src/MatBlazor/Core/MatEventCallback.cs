using Microsoft.AspNetCore.Components;
using System;

namespace MatBlazor
{
    public class MatEventCallback<T>
    {
        private bool isInitialized = false;
        private bool isIntercept = false;
        private readonly IHandleEvent _receiver;
        private readonly Func<EventCallback<T>> _sourceEventCallbackFunc;
        private EventCallback<T> interceptEventCallback;
        public event EventHandler<T> Event;


        private void Init()
        {
            if (isInitialized)
            {
                return;
            }

            isInitialized = true;

            if (Event != null)
            {
                isIntercept = true;
                interceptEventCallback = EventCallback.Factory.Create<T>(_receiver, async (e) =>
                {
                    Event?.Invoke(_receiver, e);
                    await _sourceEventCallbackFunc.Invoke().InvokeAsync(e);
                });
            }
        }


        public EventCallback<T> Value
        {
            get
            {
                Init();
                if (isIntercept)
                {
                    return interceptEventCallback;
                }

                return _sourceEventCallbackFunc();
            }
        }

        public MatEventCallback(IHandleEvent receiver, Func<EventCallback<T>> sourceEventCallbackFunc)
        {
            _receiver = receiver;
            _sourceEventCallbackFunc = sourceEventCallbackFunc;
        }
    }
}