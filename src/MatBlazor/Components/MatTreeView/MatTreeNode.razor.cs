using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Missing XML comment for publicly visible type or member
// Not used directly so no need to for comments
#pragma warning disable CS1591 
namespace MatBlazor
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

        // TODO NOTE : this works fine when OpenIconic is available
        private string GlyphStyle
        {
            get
            {
                var childItems = this.ChildNodes;
                if (childItems == null)                                 // Loading
                {
                    return "oi oi-reload spinner";
                }
                else if (!string.IsNullOrWhiteSpace(LoadErrorMessage))  // Error
                {
                    return "oi oi-warning";
                }
                else if (!childItems.Any())                             // TODO no children - may need spacer
                {
                    return "oi empty";
                }
                else if (this.IsExpanded)                               // expanded
                {
                    return "oi oi-caret-bottom";
                }
                else                                                    // collapsed
                {
                    return "oi oi-caret-right";
                }
            }
        }
        // TODO clugde as OpenIconic not installed - and not sure of your thinking on resources s
        private string TempGlyphName
        {
            get
            {
                var childItems = this.ChildNodes;
                if (childItems == null)                                 // Loading
                {
                    return "Loading";
                }
                else if (!string.IsNullOrWhiteSpace(LoadErrorMessage))  // Error
                {
                    return "Error";
                }
                else if (!childItems.Any())                             // TODO no children - may need spacer
                {
                    return "Leaf";
                }
                else if (this.IsExpanded)                               // expanded
                {
                    return "Expanded";
                }
                else                                                    // collapsed
                {
                    return "Collapsed";
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var childItems = this.ChildNodes;
            if (childItems == null)
            {
                try
                {
                    LoadErrorMessage = null;
                    childItems = await this.Tree.LoadChildNodesCallback(this.Node);
                }
                catch (Exception ex)
                {
                    LoadErrorMessage = ex.Message;
                }
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
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
