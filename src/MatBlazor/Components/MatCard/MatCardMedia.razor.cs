using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    partial class MatCardMedia
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public bool Square { get; set; }
        [Parameter]
        public bool Wide { get; set; }
        [Parameter]
        public string ContentClass { get; set; }
        [Parameter]
        public string ImageUrl { get; set; }

        ClassMapper ContentClassMapper = new ClassMapper();
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ClassMapper
                .Add("mat-card-media")
                .Add("mdc-card__media")
                .If("mdc-card__media--16-9", () => Wide)
                .If("mdc-card__media--square", () => Square);

            ContentClassMapper
                .Add("mat-card-media-content")
                .Add("mdc-card__media-content")
                .Get(() => ContentClass);

            StyleMapper.GetIf(() => $"background-image: url(\"{ImageUrl}\")", () => ImageUrl != null);
        }
    }
}
