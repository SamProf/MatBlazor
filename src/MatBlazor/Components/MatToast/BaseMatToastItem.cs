using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;


namespace MatBlazor
{
    /// <summary>
    /// Toasts provide brief notifications or messages about app processes
    /// </summary>
    public class BaseMatToastItem : BaseMatDomComponent, IDisposable
    {
        [Parameter]
        public MatToast Toast { get; set; }

        protected RenderFragment Css;

        public string Title => Toast.Title;

        public string Message => Toast.Message;

        public void Clicked(MouseEventArgs args) => Clicked(false);
        public void CloseIconClicked(EventArgs args) => Clicked(true);


        protected ClassMapper ContainerClassMapper = new ClassMapper();


        public MatToastState State { get; set; }


        public void MouseEnter() => TransitionTo(MatToastState.MouseOver);

        private bool UserHasInteracted { get; set; }

        public void MouseLeave()
        {
            if (State == MatToastState.Hiding)
            {
                return;
            }
            if (Toast.Options.RequireInteraction && !UserHasInteracted)
            {
                return;
            }
            TransitionTo(MatToastState.Hiding);
        }

        public void Clicked(bool fromCloseIcon)
        {
            Toast.Options.Onclick?.Invoke(Toast);

            if (fromCloseIcon || !Toast.Options.ShowCloseButton)
            {
                UserHasInteracted = true;
                TransitionTo(MatToastState.Hiding);
            }
        }

        public void EnsureInitialized()
        {
            if (State == MatToastState.Init)
            {
                TransitionTo(MatToastState.Showing);
            }
            else
            {
                UpdateTransitionState();
            }
        }


        public override async Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var p in parameters)
            {
                switch (p.Name)
                {
                    case nameof(Toast):
                    {
                        if (Toast != null)
                        {
                            Toast.OnUpdate -= ToastUpdated;
                        }

                        Toast = (MatToast) p.Value;
                        Toast.OnUpdate += ToastUpdated;
                        EnsureInitialized();

                        Css = builder =>
                        {
                            var transitionClass = TransitionClass;
                            if (string.IsNullOrEmpty(transitionClass))
                            {
                                return;
                            }

                            builder.OpenElement(1, "style");
                            builder.AddContent(2, transitionClass);
                            builder.CloseElement();
                        };
                        break;
                    }
                }
            }

            await base.SetParametersAsync(parameters);
        }


        private void ToastUpdated()
        {
            InvokeAsync(StateHasChanged);
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Toast != null)
            {
                Toast.OnUpdate -= ToastUpdated;
            }

            Timer.Dispose();
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public MatToastType Type { get; set; }

        readonly string AnimationId = IdGeneratorHelper.Generate("mat_toaster_animation_");

        private MatToastTransitionState TransitionState { get; set; }

        public string AnimationStyle
        {
            get
            {
                switch (State)
                {
                    case MatToastState.Showing:
                        var opacity = Toast.Options.MaximumOpacity;
                        var showDuration = Toast.Options.ShowTransitionDuration;
                        return $"opacity: {opacity}; animation: {showDuration}ms linear {AnimationId};";
                    case MatToastState.Visible:
                        return $"opacity: {TransitionState.Opacity};";
                    case MatToastState.Hiding:
                        var hideDuration = Toast.Options.HideTransitionDuration;
                        return $"opacity: 0; animation: {hideDuration}ms linear {AnimationId};";
                    default:
                        return string.Empty;
                }
            }
        }


        public string ProgressBarStyle
        {
            get
            {
                var percentage = TransitionState.ProgressPercentage;
                var milliseconds = TransitionState.RemainingMilliseconds;
                return $"width: {percentage}; animation: {AnimationId} {milliseconds}ms;";
            }
        }


        private MatToastTransitionTimer Timer { get; }


        public bool ShowProgressBar => Toast.Options.ShowProgressBar && State == MatToastState.Visible;


        public string TransitionClass
        {
            get
            {
                var template = "@keyframes " + AnimationId + " {{from{{ {0}: {1}; }} to{{ {0}: {2}; }}}}";

                return State switch
                {
                    MatToastState.Showing => string.Format(template, "opacity", 0, TransitionState.Opacity),
                    MatToastState.Hiding => string.Format(template, "opacity", TransitionState.Opacity, 0),
                    MatToastState.Visible => string.Format(template, "width", $"{TransitionState.ProgressPercentage}%", "0%"),
                    _ => string.Empty,
                };
            }
        }


        public BaseMatToastItem()
        {
            State = MatToastState.Init;
            ContainerClassMapper
                .Add("mat-toast")
                .Get(() => Toast.Options.Class)
                .Get(() => MatToastConfiguration.ToastTypeClass(Toast.Options.Type));
            Timer = new MatToastTransitionTimer(TimerElapsed);
        }


        private void TransitionTo(MatToastState state)
        {
            Timer.Stop();
            State = state;

            switch (state)
            {
                case MatToastState.Showing:
                    if (Toast.Options.ShowTransitionDuration <= 0)
                    {
                        TransitionTo(MatToastState.Visible);
                    }
                    else
                    {
                        Timer.Start(Toast.Options.ShowTransitionDuration);
                    }
                    break;
                case MatToastState.Visible:
                    if (Toast.Options.RequireInteraction)
                    {
                        TransitionState = MatToastTransitionState.ForRequiredInteraction(Toast.Options.MaximumOpacity);
                        Toast.InvokeOnUpdate();
                        return;
                    }
                    else if (Toast.Options.VisibleStateDuration < 0)
                    {
                        TransitionTo(MatToastState.Hiding);
                    }
                    else
                    {
                        Timer.Start(Toast.Options.VisibleStateDuration);
                    }

                    break;
                case MatToastState.Hiding:
                    if (Toast.Options.HideTransitionDuration <= 0)
                    {
                        Toast.InvokeOnClose();
                        return;
                    }
                    else
                    {
                        Timer.Start(Toast.Options.HideTransitionDuration);
                    }

                    break;
                case MatToastState.MouseOver:
                    break;
            }

            UpdateTransitionState();
            Toast.InvokeOnUpdate();
        }

        private void UpdateTransitionState()
        {
            TransitionState = State == MatToastState.Visible && Toast.Options.RequireInteraction
                ? MatToastTransitionState.ForRequiredInteraction(Toast.Options.MaximumOpacity)
                : new MatToastTransitionState(Timer, Toast.Options.MaximumOpacity);
        }


        private void TimerElapsed()
        {
            switch (State)
            {
                case MatToastState.Showing:
                    TransitionTo(MatToastState.Visible);
                    break;
                case MatToastState.Visible:
                    TransitionTo(MatToastState.Hiding);
                    break;
                case MatToastState.Hiding:
                    Toast.InvokeOnClose();
                    break;
            }
        }
    }
}