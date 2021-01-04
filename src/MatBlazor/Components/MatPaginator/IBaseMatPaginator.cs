using System.Collections.Generic;

namespace MatBlazor
{
    public interface IBaseMatPaginator
    {
        int PageSize { get; set; }

        IReadOnlyList<MatPageSizeOption> PageSizeOptions { get; set; }
    }
}