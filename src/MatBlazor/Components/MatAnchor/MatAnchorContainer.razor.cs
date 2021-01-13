using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace MatBlazor
{
    partial class MatAnchorContainer : BaseMatDomComponent
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

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
