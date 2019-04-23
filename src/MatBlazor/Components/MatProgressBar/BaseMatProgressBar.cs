using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Progress indicators display the length of a process or express an unspecified wait time.
    /// </summary>
    public class BaseMatProgressBar : BaseMatComponent
    {
        private double _progress;
        private double _buffer;

        [Parameter]
        protected bool Indeterminate { get; set; }

        [Parameter]
        protected bool Reversed { get; set; }

        [Parameter]
        protected bool Closed { get; set; }

        [Parameter]
        protected double Progress
        {
            get => _progress;
            set
            {
                if (Math.Abs(value - _progress) > double.Epsilon)
                {
                    _progress = value;
                    CallAfterRender(async () =>
                    {
                        await Js.InvokeAsync<object>("matBlazor.matProgressBar.setProgress", Ref, value);
                    });
                }
            }
        }

        [Parameter]
        protected double Buffer
        {
            get => _buffer;
            set
            {
                if (Math.Abs(value - _buffer) > double.Epsilon)
                {
                    _buffer = value;

                    CallAfterRender(async () =>
                    {
                        await Js.InvokeAsync<object>("matBlazor.matProgressBar.setBuffer", Ref, value);
                    });
                }
            }
        }


        public BaseMatProgressBar()
        {
            ClassMapper
                .Add("mdc-linear-progress")
                .If("mdc-linear-progress--indeterminate", () => this.Indeterminate)
                .If("mdc-linear-progress--reversed", () => this.Reversed)
                .If("mdc-linear-progress--closed", () => Closed);
            CallAfterRender(async () => { await Js.InvokeAsync<object>("matBlazor.matProgressBar.init", Ref); });
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }
    }
}