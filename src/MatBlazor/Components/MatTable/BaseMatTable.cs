using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Mat Table display a table data.
    /// </summary>
    public class BaseMatTable : BaseMatDomComponent
    {
        private string _searchTermFieldPlaceHolder = null;
        private string _searchTermFieldLabel = null;
        public BaseTableRow Current { get; private set; }
        #region Private Fields

        protected int TotalPages { get; set; }
        protected int RecordsFrom { get; set; }
        protected int RecordsTo { get; set; }
        protected int RecordsCount { get; set; }
        protected int RecordsFilteredCount { get; set; }

        protected int CurrentPage;

        protected int StartPage { get; set; }
        protected int EndPage { get; set; }
        protected string SearchTerm { get; set; }
        protected string ErrorMessage { get; set; }
        Timer DebounceTimerInterval { get; set; }
        Action<object> DebounceAction { get; set; }
        object LastObjectDebounced { get; set; }

        #endregion

        #region Future Parameters  / Currently untested

        [Parameter]
        public string PageParamName { get; set; }

        [Parameter]
        public string PageSizeParamName { get; set; }

        [Parameter]
        public bool Descending { get; set; }

        [Parameter]
        public string DescendingParamName { get; set; }

        [Parameter]
        public string SortBy { get; set; }

        [Parameter]
        public string SortByParamName { get; set; }

        [Parameter]
        public string PageLabel { get; set; } = "Page";

        [Parameter]
        public string PageRecordCountLabel { get; set; } = "Items per Page:";

        [Parameter]
        public string PagingDataPropertyName { get; set; }

        [Parameter]
        public string PagingRecordsCountPropertyName { get; set; }

        [Parameter]
        public string SearchTermParamName { get; set; }

        #endregion

        [Parameter]
        public Action<object> SelectionChanged { get; set; }

        /// <summary>
        /// Specifies a custom class for the MatTableHeader row
        /// </summary>
        [Parameter]
        public string HeaderRowClass { get; set; }

        /// <summary>
        /// Specifies a custom class for the MatTableRow
        /// </summary>
        [Parameter]
        public string RowClass { get; set; }

        /// <summary>
        /// Specifies weather you can select a single row.
        /// </summary>
        [Parameter]
        public bool AllowSelection { get; set; }

        /// <summary>
        /// Specifies whether to Request the API only once.
        /// </summary>
        [Parameter]
        public bool RequestApiOnlyOnce { get; set; }

        /// <summary>
        /// Specifies the delay duration between user input on the Search Term Field. Default 800
        /// </summary>
        [Parameter]
        public int DebounceMilliseconds { get; set; }

        /// <summary>
        /// Specifies which column is used for the filter / search term. If this is populated the Search Textbox will be visible.
        /// </summary>
        [Parameter]
        public string FilterByColumnName { get; set; }

        /// <summary>
        /// Specifies the Label for the Filter / Search Term  Textbox
        /// </summary>
        [Parameter]
        public string SearchTermFieldLabel
        {
            get { return _searchTermFieldLabel ?? "Filter"; }
            set { _searchTermFieldLabel = value; }
        }

        /// <summary>
        /// Specifies the Placeholder for the Filter / Search Term  Textbox
        /// </summary>
        [Parameter]
        public string SearchTermFieldPlaceHolder
        {
            get { return _searchTermFieldPlaceHolder ?? FilterByColumnName; }
            set { _searchTermFieldPlaceHolder = value; }
        }

        /// <summary>
        /// Specifies where to Load the Initial Table Data
        /// </summary>
        [Parameter]
        public bool LoadInitialData { get; set; }

        /// <summary>
        /// Specifies the API Url form for the table data
        /// </summary>
        [Parameter]
        public string ApiUrl { get; set; }

        /// <summary>
        /// Specifies the Paging visibility
        /// </summary>
        [Parameter]
        public bool ShowPaging { get; set; } = true;

        /// <summary>
        /// Specifies the Table Footer visibility.
        /// </summary>
        [Parameter]
        public bool ShowFooter { get; set; } = false;

        /// <summary>
        /// Determines if table has alternating color rows.
        /// </summary>
        [Parameter]
        public bool Striped { get; set; }

        /// <summary>
        /// The number of rows per page.
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = 5;

        public BaseMatTable()
        {
            ClassMapper
                .Add("mdc-table")
                .If("mdc-table--striped", () => this.Striped);
        }

        /// <summary>
        /// Action to execute on row item
        /// </summary>
        [Parameter]
        public EventCallback<object> OnRowDbClick { get; set; }

        #region Helpers
        public async Task ToggleSelectedAsync(BaseTableRow row)
        {
            if (row.Selected)
            {
                var current = Current;
                Current = row;

                if (current != null && current != row && current.Selected)
                {
                    await current.ToggleSelectedAsync();
                }
                SelectionChanged?.Invoke(Current.RowItem);
            }
            else
            {
                SelectionChanged?.Invoke(null);
            }   
        }

        protected string SearchTermParam(string SearchTerm)
        {
            var SearchTermParam = (string.IsNullOrWhiteSpace(SearchTermParamName)
                ? "SearchTerm=" + SearchTerm
                : SearchTermParamName + "=" + SearchTerm);
            var DescendingParam = (string.IsNullOrWhiteSpace(DescendingParamName)
                ? "Descending=" + Descending
                : DescendingParamName + "=" + Descending);
            var SortByParam = (string.IsNullOrWhiteSpace(SortByParamName)
                ? "SortBy=" + SortBy
                : SortByParamName + "=" + SortBy);
            var PageParam = (string.IsNullOrWhiteSpace(PageParamName)
                ? "Page=" + CurrentPage
                : PageParamName + "=" + CurrentPage);
            var PageSizeParam = (string.IsNullOrWhiteSpace(PageSizeParamName)
                ? "PageSize=" + PageSize
                : PageSizeParamName + "=" + PageSize);
            return "?" +
                   SearchTermParam + "&" +
                   DescendingParam + "&" +
                   SortByParam + "&" +
                   PageParam + "&" +
                   PageSizeParam;
        }

        protected void Debounce(object obj, int interval, Action<object> debounceAction)
        {
            LastObjectDebounced = obj;
            DebounceAction = debounceAction;

            DebounceTimerInterval?.Dispose();

            DebounceTimerInterval = new Timer(DebounceTimerIntervalOnTick, obj, interval, interval);
        }

        protected void DebounceTimerIntervalOnTick(object state)
        {
            DebounceTimerInterval?.Dispose();

            if (DebounceTimerInterval != null)
            {
                DebounceAction?.Invoke(LastObjectDebounced);
            }

            DebounceTimerInterval = null;
        }

        #endregion

        #region Struct and Enums

        public enum PageDirection
        {
            First,
            Previous,
            Next,
            Last,
        }

        public class PageSizeStructure
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }

        #endregion

        #region events

        protected void OnRowDbClickHandler(object item)
        {
            if (OnRowDbClick.HasDelegate)
            {
                OnRowDbClick.InvokeAsync(item);
            }
        }

        #endregion events
    }
}
