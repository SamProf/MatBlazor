using Microsoft.AspNetCore.Components;

namespace ITMS.External.MatBlazor
{
    /// <summary>
    /// Makes it easier to use vector-based icons in your app.
    /// </summary>
    public class BaseMatIcon : BaseMatDomComponent
    {
        [Parameter]
        public string Icon { get; set; }


        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public BaseMatIcon()
        {
            ClassMapper.Add("material-icons");
        }
    }
}