using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace MatBlazor
{
    public class BaseMatDataTableOld<TItem> : BaseMatDomComponent, IMatVirtualScrollHelperTarget, IBaseMatPaginator
    {
        protected MatVirtualScrollHelper VirtualScrollHelper { get; set; } = null;

        public BaseMatDataTableOld()
        {
            VirtualScrollHelper = new MatVirtualScrollHelper(this);

            ClassMapper
                .Add("mat-data-table")
                .Add("mdc-data-table")
                .If("mat-data-table__sticky-header", () => StickyHeader)
                .Get(() => VirtualScrollHelper.GetClass());


            CallAfterRender(async () => { await VirtualScrollHelper.InitAsync(Js, Ref, this.VirtualScroll); });
        }

        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment Columns { get; set; }

        [Parameter]
        public bool StickyHeader { get; set; }

        [Parameter]
        public bool VirtualScroll { get; set; } = false;


        [Parameter]
        public bool Paginator { get; set; } = false;

        [Parameter]
        public IReadOnlyList<MatPageSizeOption> PageSizeOptions { get; set; } =
            BaseMatPaginator.DefaultPageSizeOptions;

        [Parameter]
        public int PageSize { get; set; }

        [Parameter]
        public int PageIndex { get; set; }

        [Parameter]
        public string PageLabel { get; set; } = BaseMatPaginator.PageLabelDefault;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            BaseMatPaginator.OnInitializedStatic(this);
        }


        protected IEnumerable<TItem> GetVisibleItems()
        {
            var e = Items ?? Enumerable.Empty<TItem>();


            return e;
        }


        protected void OnPageHandler(MatPaginatorPageEvent e)
        {
            PageSize = e.PageSize;
            PageIndex = e.PageIndex;
            this.StateHasChanged();
        }

        protected IEnumerable<TItem> GetRenderedItems(IEnumerable<TItem> visibleItems)
        {
            var e = visibleItems;

            if (Paginator)
            {
                var pageSize = PageSize;
                var pageIndex = PageIndex;
                var skipItems = pageSize > 0 && pageIndex > 0 ? pageSize * pageIndex : 0;
                var takeItems = pageSize > 0 ? pageSize : 0;


                if (e is IQueryable<TItem> q)
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
            }

            return e;
        }

        public void StateHasChangedFromVirtualScrollHelper()
        {
            this.InvokeStateHasChanged();
        }

        public override void Dispose()
        {
            base.Dispose();
            VirtualScrollHelper?.Dispose();
        }


        protected List<BaseMatDataTableColumnOld<TItem>> columnItems = new List<BaseMatDataTableColumnOld<TItem>>();

        public void AddColumn(BaseMatDataTableColumnOld<TItem> column)
        {
            columnItems.Add(column);
            this.InvokeStateHasChanged();
        }
    }
}