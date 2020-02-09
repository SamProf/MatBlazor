using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatPaginator : BaseMatDomComponent
    {
        public string Label { get; set; } = "Items per Page:";

        [Parameter]
        public IReadOnlyList<MatPageSize> PageSizes { get; set; } = new[]
        {
            new MatPageSize(5),
            new MatPageSize(10),
            new MatPageSize(25),
            new MatPageSize(50),
            new MatPageSize(100),
            new MatPageSize(-1, "*"),
        };
    }
}