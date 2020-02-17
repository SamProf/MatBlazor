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
                    switch (direction)
                    {
                        case MatSortDirection.None:
                            direction = MatSortDirection.Asc;
                            break;
                        case MatSortDirection.Asc:
                            direction = MatSortDirection.Desc;
                            break;
                        case MatSortDirection.Desc:
                            direction = MatSortDirection.None;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
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

            switch (Parent.Direction)
            {
                case MatSortDirection.None:
                    return null;

                case MatSortDirection.Asc:
                    return MatIconNames.Arrow_downward;
                case MatSortDirection.Desc:
                    return MatIconNames.Arrow_upward;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}