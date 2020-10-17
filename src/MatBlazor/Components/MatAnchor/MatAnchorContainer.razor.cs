using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatBlazor
{
    partial class MatAnchorContainer
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Anchor { get; set; }

        string GetHref()
        {
            return NavigationManager.ToAbsoluteUri(NavigationManager.Uri).GetLeftPart(UriPartial.Path) + "#" + Anchor;
        }
    }
}
