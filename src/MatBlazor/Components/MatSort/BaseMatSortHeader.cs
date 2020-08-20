using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    
    /// <summary>
    /// The MatSortHeader and MatSortHeaderRow are used, respectively, to add sorting state and display to tabular data.
    /// </summary>
    public class BaseMatSortHeader : BaseMatDomComponent
    {
        public BaseMatSortHeader()
        {
            ClassMapper.Add("mat-sort-header");
        }


        public async Task HeaderClickHandler()
        {
            var sortId = Parent.SortId;
            var direction = Parent.Direction;

            if (!string.IsNullOrEmpty(SortId))
            {
                if (string.Equals(sortId, SortId))
                {
                    direction = direction switch
                    {
                        MatSortDirection.None => MatSortDirection.Asc,
                        MatSortDirection.Asc => MatSortDirection.Desc,
                        MatSortDirection.Desc => MatSortDirection.None,
                        _ => throw new ArgumentOutOfRangeException(),
                    };
                }
                else
                {
                    sortId = SortId;
                    direction = MatSortDirection.Asc;
                }

                await Parent.SetNewSortAsync(sortId, direction);
            }
        }


        [Parameter]
        public string SortId { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public BaseMatSortHeaderRow Parent { get; set; }


        protected string GetIcon()
        {
            if (string.IsNullOrEmpty(SortId))
            {
                return null;
            }

            if (string.IsNullOrEmpty(Parent.SortId))
            {
                return null;
            }

            if (!string.Equals(Parent.SortId, SortId))
            {
                return null;
            }

            return Parent.Direction switch
            {
                MatSortDirection.None => null,
                MatSortDirection.Asc => MatIconNames.Arrow_downward,
                MatSortDirection.Desc => MatIconNames.Arrow_upward,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}