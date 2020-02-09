using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatPaginator : BaseMatDomComponent
    {
        public string Label { get; set; } = "Items per Page:";


        [Parameter]
        public int PageSize { get; set; }

        [Parameter]
        public EventCallback<int> PageSizeChanged { get; set; }


        [Parameter]
        public int PageIndex { get; set; }

        [Parameter]
        public EventCallback<int> PageIndexChanged { get; set; }

        [Parameter]
        public int Length { get; set; }

        [Parameter]
        public IReadOnlyList<MatPageSizeOption> PageSizeOptions { get; set; } = new[]
        {
            new MatPageSizeOption(5),
            new MatPageSizeOption(10),
            new MatPageSizeOption(25),
            new MatPageSizeOption(50),
            new MatPageSizeOption(100),
            new MatPageSizeOption(-1, "*"),
        };


        protected async Task PageSizeChangedHandler(int value)
        {
            this.PageSize = value;
            await this.PageSizeChanged.InvokeAsync(value);
        }
    }
}