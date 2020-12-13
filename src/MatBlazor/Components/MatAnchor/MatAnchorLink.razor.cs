using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace MatBlazor
{
    partial class MatAnchorLink : BaseMatDomComponent
    {
        [Inject] 
        protected NavigationManager NavigationManager { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        string GetHref()
        {
            var hrefValue = Attributes["href"].ToString();
            if (hrefValue.StartsWith("#"))
            {
                hrefValue = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).GetLeftPart(UriPartial.Path) + hrefValue;
            }
            return hrefValue;
        }
    }
}
