using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDataTableItems<TItem> : BaseMatDomComponent, IMatDataTableItems
    {
    
    
    
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment<TItem> Columns { get; set; }

        [CascadingParameter]
        public BaseMatDataTable ParentDataTable { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ParentDataTable.ItemsComponent = this;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            this.ParentDataTable?.PaginatorComponent?.Update();
        }

        protected IEnumerable<TItem> PreparedItems()
        {
            var e = Items ?? Enumerable.Empty<TItem>();

            var pageSize = ParentDataTable?.PaginatorComponent?.PageSize ?? 0;
            var pageIndex = ParentDataTable?.PaginatorComponent?.PageIndex ?? 0;
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

        public int Length()
        {
            return Items?.Count() ?? 0;
        }

        public void MarkStateHasChanged()
        {
            StateHasChanged();
        }
    }
}