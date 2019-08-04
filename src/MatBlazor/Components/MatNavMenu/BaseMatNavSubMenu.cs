﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// MatNavSubMenu provides an expandable panel for child navigation lists.
    /// </summary>
    public class BaseMatNavSubMenu : BaseMatDomComponent
    {
        [CascadingParameter]
        public BaseMatNavMenu MatNavMenu { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Expanded { get; set; }

        [Parameter]
        public bool Selected { get; set; }

        [Parameter]
        public EventCallback<bool> SelectedChanged { get; set; }

        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }

        public async Task ToggleAsync()
        {
            this.Expanded = !this.Expanded;
            await ExpandedChanged.InvokeAsync(this.Expanded);
            await this.MatNavMenu.ToggleAsync(this);
            this.StateHasChanged();
        }

        public async Task ToggleSelectedAsync()
        {
            this.Selected = !this.Selected;
            ClassMapper.MakeDirty();
            await SelectedChanged.InvokeAsync(this.Selected);
            this.StateHasChanged();
        }

        public BaseMatNavSubMenu()
        {
            ClassMapper
                .Add("mat-expansion-panel")
                .If("mat-expansion-panel--expanded", () => Expanded)
                .If("mdc-expansion-panel--selected", () => Selected);
        }
    }
}