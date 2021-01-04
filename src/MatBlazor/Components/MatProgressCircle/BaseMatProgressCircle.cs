using Microsoft.AspNetCore.Components;
using System;

namespace MatBlazor
{
    /// <summary>
    /// Circular Progress indicator displays the length of a process or express an unspecified wait time.
    /// </summary>
    public class BaseMatProgressCircle : BaseMatDomComponent
    {
        private double _progress;
        private MatProgressCircleSize _size = MatProgressCircleSize.Large;

        /// <summary>
        /// Toggles the component between the determinate and indeterminate state.
        /// </summary>
        [Parameter]
        public bool Indeterminate { get; set; } = true;

        /// <summary>
        ///If true, Puts the component in the closed state.
        /// </summary>
        [Parameter]
        public bool Closed { get; set; }

        /// <summary>
        /// Sets the size of the circular progress bar.
        /// </summary>
        [Parameter]
        public MatProgressCircleSize Size
        {
            get => _size;
            set
            {
                _size = value;

                switch (_size)
                {
                    case MatProgressCircleSize.Small:
                        SvgSize = MatProgressCircleSvgSize.Small;
                        break;
                    case MatProgressCircleSize.Medium:
                        SvgSize = MatProgressCircleSvgSize.Medium;
                        break;
                    case MatProgressCircleSize.Large:
                    default:
                        SvgSize = MatProgressCircleSvgSize.Large;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the progress bar to this value. Value should be between [0, 1].
        /// </summary>
        [Parameter]
        public double Progress
        {
            get => _progress;
            set
            {
                if (Math.Abs(value - _progress) > double.Epsilon)
                {
                    _progress = value;
                    CallAfterRender(async () => await JsInvokeAsync<object>("matBlazor.matProgressCircle.setProgress", Ref, value));
                }
            }
        }

        /// <summary>
        /// IF true, Applies four animated stroke-colors to the indeterminate indicator. Applicable to the indeterminate variant only and overrides any single color currently set.
        /// </summary>
        [Parameter]
        public bool FourColored { get; set; }

        protected int SpinnerLayerCount { get; private set; }

        protected MatProgressCircleSvgSize SvgSize { get; private set; } = MatProgressCircleSvgSize.Large;

        //https://github.com/material-components/material-components-web/tree/v7.0.0/packages/mdc-circular-progress
        public BaseMatProgressCircle()
        {
            ClassMapper
                .Add("mat-progress-circle")
                .Add("mdc-circular-progress")
                .If("mdc-circular-progress--large", () => Size == MatProgressCircleSize.Large)
                .If("mdc-circular-progress--medium", () => Size == MatProgressCircleSize.Medium)
                .If("mdc-circular-progress--small", () => Size == MatProgressCircleSize.Small)
                .If("mdc-circular-progress--indeterminate", () => this.Indeterminate)
                .If("mdc-circular-progress--determinate", () => !this.Indeterminate)
                .If("mdc-circular-progress--closed", () => this.Closed);

            CallAfterRender(async () => { await JsInvokeAsync<object>("matBlazor.matProgressCircle.init", Ref); });
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            // https://github.com/material-components/material-components-web/tree/v7.0.0/packages/mdc-circular-progress#four-colored
            SpinnerLayerCount = (Indeterminate && FourColored) ? 4 : 1;
        }
    }
}
