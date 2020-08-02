using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public partial class MatDataTableColumn
    {
        [Parameter]
        public object Value { get; set; }
        
        // [Parameter]
        // public Expression<Func<object>> ValueExpression { get; set; }
        //
        // [Parameter]
        // public EventCallback<object> ValueChanged { get; set; }

        [Parameter]
        public string Header { get; set; }

        [CascadingParameter]
        public MatDataTableColumnRenderMode RenderMode { get; set; }
    }


    public enum MatDataTableColumnRenderMode
    {
        RowCell,
        HeaderCell
    }
}