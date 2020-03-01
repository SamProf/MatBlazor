using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDataTable<TItem> : BaseMatDomComponent, IMatVirtualScrollHelperTarget
    {
        internal BaseMatPaginator PaginatorComponent { get; set; } = null;

        MatVirtualScrollHelper VirtualScrollHelper { get; set; } = null;

        public BaseMatDataTable()
        {
            VirtualScrollHelper = new MatVirtualScrollHelper(this);

            ClassMapper
                .Add("mat-data-table")
                .Add("mdc-data-table")
                .If("mat-data-table__sticky-header", () => StickyHeader)
                .Get(() => VirtualScrollHelper.GetClass());
        }

        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment<TItem> Columns { get; set; }

        [Parameter]
        public bool StickyHeader { get; set; }

        [Parameter]
        public bool VirtualScroll { get; set; } = false;

        protected IEnumerable<TItem> PreparedItems()
        {
            var e = Items ?? Enumerable.Empty<TItem>();

            var pageSize = PaginatorComponent?.PageSize ?? 0;
            var pageIndex = PaginatorComponent?.PageIndex ?? 0;
            var skipItems = pageSize > 0 && pageIndex > 0 ? pageSize * pageIndex : 0;
            var takeItems = pageSize > 0 ? pageSize : 0;


            var q = e as IQueryable<TItem>;
            if (q != null)
            {
                if (skipItems > 0)
                {
                    q = q.Skip(skipItems);
                }

                if (takeItems > 0)
                {
                    q = q.Take(takeItems);
                }

                e = q.AsEnumerable();
            }
            else
            {
                if (skipItems > 0)
                {
                    e = e.Skip(skipItems);
                }

                if (takeItems > 0)
                {
                    e = e.Take(takeItems);
                }
            }

            // ParentDataTable.Paginator
            return e;
        }

        public bool VirtualScrollIsEnabled()
        {
            return VirtualScroll;
        }
    }
}