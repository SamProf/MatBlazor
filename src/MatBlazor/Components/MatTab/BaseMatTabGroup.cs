using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// MatTabGroup organize content into separate views where only one view can be visible at a time. Each tab's label is shown in the tab header and the active tab's label is designated with the animated ink bar.
    /// </summary>
    public class BaseMatTabGroup : BaseMatDomComponent
    {
        public BaseMatTabGroup()
        {
            ClassMapper.Add("mat-tab-group");
        }

        private BaseMatTabLabel _active;
        private int _activeIndex;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public int ActiveIndex {   
            get => _activeIndex;
            set
            {
                if (_activeIndex == value) {
                    return;
                }
                _activeIndex = value;
                this.ActiveIndexChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<int> ActiveIndexChanged { get; set; }
        public BaseMatTabLabel Active
        {
            get => _active;
            set
            {
                _active = value;
                this.InvokeStateHasChanged();
            }
        }
    }
}