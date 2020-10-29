using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatBlazor
{
    /// <summary>
    /// Basic component where the physical properties of paper are translated to the screen.
    /// Used for creating sections and giving more focus to some parts of the application.
    /// </summary>
    public class BaseMatPaper : BaseMatDomComponent
    {
        public BaseMatPaper()
        {
            ClassMapper
                .Add("mat-paper")
                .GetIf(() => $"mat-elevation-z{Math.Clamp(Elevation, 0, 24)}", () => !Outlined)
                .If("mat-paper--outlined", () => Outlined)
                .If("mat-paper--rounded", () => Rounded);            
                
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Level of the Elevation. 
        /// From 0 to 24.
        /// </summary>
        [Parameter]
        public int Elevation { get; set; } = 1;

        /// <summary>
        /// Uses outlined surface. If true, removes Elevation.
        /// </summary>
        [Parameter]
        public bool Outlined { get; set; }

        /// <summary>
        /// Uses round border.
        /// </summary>
        [Parameter]
        public bool Rounded { get; set; }
    }
}
