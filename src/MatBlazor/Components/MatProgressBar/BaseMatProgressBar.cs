using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Progress indicators display the length of a process or express an unspecified wait time.
    /// </summary>
    public class BaseMatProgressBar : BaseMatDomComponent
    {
        private double _progress;
        private double _buffer;

        [Parameter]
        public bool Indeterminate { get; set; }

        [Parameter]
        public bool Reversed { get; set; }

        [Parameter]
        public bool Closed { get; set; }

        [Parameter]
        public double Progress
        {
            get => _progress;
            set
            {
                if (Math.Abs(value - _progress) > double.Epsilon)
                {
                    _progress = value;
                    CallAfterRender(async () =>
                    {
                        await JsInvokeAsync<object>("matBlazor.matProgressBar.setProgress", Ref, value);
                    });
                }
            }
        }

        [Parameter]
        public double Buffer
        {
            get => _buffer;
            set
            {
                if (Math.Abs(value - _buffer) > double.Epsilon)
                {
                    _buffer = value;

                    CallAfterRender(async () =>
                    {
                        await JsInvokeAsync<object>("matBlazor.matProgressBar.setBuffer", Ref, value);
                    });
                }
            }
        }


        public BaseMatProgressBar()
        {
            ClassMapper
                .Add("mat-progress-bar")
                .Add("mdc-linear-progress")
                .If("mdc-linear-progress--indeterminate", () => this.Indeterminate)
                .If("mdc-linear-progress--reversed", () => this.Reversed)
                .If("mdc-linear-progress--closed", () => Closed);
            CallAfterRender(async () => { await JsInvokeAsync<object>("matBlazor.matProgressBar.init", Ref); });
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }
    }
}