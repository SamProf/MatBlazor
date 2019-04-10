using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatTable
{
    /// <summary>
    /// Mat Table display a table data.
    /// </summary>
    public class BaseMatTable : BaseMatComponent
    {
        private bool _showPaging = true;
        private bool _showFooter = false;
        private int _pageSize = 5;

        protected int TotalPages;
        protected int CurrentPage;
        protected int StartPage;
        protected int EndPage;

        /// <summary>
        /// Specifies the Paging visibility
        /// </summary>
        [Parameter]
        public bool ShowPaging
        {
            get => _showPaging;
            set
            {
                _showPaging = value;
                ClassMapper.MakeDirty();
            }
        }


        /// <summary>
        /// Specifies the Footer visibility.
        /// </summary>
        [Parameter]
        public bool ShowFooter {
            get => _showFooter;
            set
            {
                _showFooter = value;
                ClassMapper.MakeDirty();
            }
        }

        /// <summary>
        /// Determines if table has alternating color rows.
        /// </summary>
        [Parameter]
        public bool Striped { get; set; }

        /// <summary>
        /// The number of rows per page.
        /// </summary>
        [Parameter]
        protected int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value;
                ClassMapper.MakeDirty();
            }
        }

        public BaseMatTable()
        {
            ClassMapper
                .Add("mdc-table")
                .If("mdc-table--striped", () => this.Striped);
        }
    }
}
