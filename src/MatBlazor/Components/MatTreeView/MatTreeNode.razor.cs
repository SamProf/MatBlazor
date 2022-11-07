using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Missing XML comment for publicly visible type or member
// Not used directly so no need to for comments
#pragma warning disable CS1591 
namespace ITMS.External.MatBlazor
{
    public partial class MatTreeNode<TNode>
        where TNode : class
    {
        [CascadingParameter]
        public MatTreeView<TNode> Tree { get; set; }

        [Parameter]
        public TNode Node { get; set; }

        [Parameter]
        public bool IsSelected { get; set; }


        private string LoadErrorMessage = null;
        private bool loadingNodes = true;

        private bool IsExpanded
        {
            get { return this.Tree.IsNodeExpanded(this.Node); }
        }
        private Task SetExpanded(bool isExpanded)
        {
            return this.Tree.SetExpandedNodeAsync(this.Node, isExpanded);
        }

        private IEnumerable<TNode> ChildNodes
        {
            get
            {
                return this.Tree.GetChildNodesCallback(this.Node);
            }
        }


        protected override async Task OnInitializedAsync()
        {
            var childItems = this.ChildNodes;
            if (childItems == null && this.Tree.LoadChildNodesCallback != null)
            {
                try
                {
                    LoadErrorMessage = null;
                    await this.Tree.LoadChildNodesCallback(this.Node);
                    loadingNodes = false;
                }
                catch (Exception ex)
                {
                    LoadErrorMessage = ex.Message;
                }
            }
            else
            {
                loadingNodes = false;
            }
            await base.OnInitializedAsync();
            return;
        }

        private async Task OnExpandCollapse_Clicked()
        {
            var childItems = this.ChildNodes;

            // can't expand one that still loading, or is empty
            if (childItems == null || childItems.Any() == false)
            {
                return;
            }

            await this.SetExpanded(!IsExpanded);
        }

        private Task OnSelected_Clicked(MouseEventArgs args)
        {
            return this.Tree.SetSelectedNodeAsync(this.Node);
        }

        private string MinHeightStyle => Tree.MinItemHeight.HasValue ? $"min-height: {Tree.MinItemHeight}px;" : "";

        protected string ToggleIconStyle => IsExpanded ? "" : "transform: none !important";
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
