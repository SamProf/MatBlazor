using System.Collections.Generic;

namespace ITMS.External.MatBlazor
{
    public interface IBaseMatPaginator
    {
        int PageSize { get; set; }

        IReadOnlyList<MatPageSizeOption> PageSizeOptions { get; set; }
    }
}