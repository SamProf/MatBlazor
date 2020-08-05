using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Renders the data as a tree.
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    public partial class MatTreeView<TNode>
        where TNode : class
    {
        private readonly Dictionary<TNode, bool> _expandedNodes = new Dictionary<TNode, bool>();
        private IEnumerable<TNode> _rootNodes = null;

        /// <summary>
        /// The root node to be displayed in the tree
        /// One of the following must be supplied <see cref="RootNode"/> or <see cref="RootNodes"/> (but NOT BOTH)
        /// </summary>
        [Parameter]
        public TNode RootNode
        {
            get { return RootNodes?.FirstOrDefault(); }
            set
            {
                if (value != null)
                {
                    _rootNodes = new TNode[] { value };
                }
                else
                {
                    _rootNodes = new TNode[0]; 
                }
            }
        }
        /// <summary>
        /// All the root nodes displayed in the tree
        /// One of the following must be supplied <see cref="RootNode"/> or <see cref="RootNodes"/> (but NOT BOTH)
        /// </summary>
        [Parameter]
        public IEnumerable<TNode> RootNodes
        {
            get { return _rootNodes; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(RootNodes));
                }
                _rootNodes = value.ToArray();
            }
        }

        /// <summary>
        /// The selected item in the tree
        /// (Optional - default null)
        /// </summary>
        [Parameter]
        public TNode SelectedNode { get; set; }
        /// <summary>
        /// The template used to render the Node
        /// (Required)
        /// </summary>
        [Parameter]
        public RenderFragment<TNode> NodeTemplate { get; set; }
        /// <summary>
        /// A function that gets all the child nodes for a given parentNode.
        /// If lazy loading is supported and the child nodes have not yet been 
        /// loaded then it should return null.
        /// (Required)
        /// </summary>
        /// <remarks>
        /// The function should return a collection of child nodes.
        ///    
        /// This function maybe called many times for a given node.
        /// 
        /// Loading on Demand
        /// If Lazy loading is supported and the child nodes have not been loaded
        /// then it should return null. 
        /// If null is returned then <see cref="LoadChildNodesCallback"/> will be called to 
        /// get the child nodes, to it must have been set.
        /// </remarks>
        /// <example><![CDATA[
        /// <MatTreeView TNode="MyTreeNode"
        ///             GetChildNodesCallback="@GetChildNodes" />
        /// ...
        /// @code {
        ///     private IEnumerable<MyTreeNode> GetChildNodes(MyTreeNode parentNode)
        ///     {
        ///         if (parentNode.AreChildrenLoaded == false)
        ///             return null; // LoadChildrenCallbackAsync will be called to load the child nodes
        ///             
        ///         return parentNode.Nodes;
        ///     }
        /// }        
        /// ]]></example>
        [Parameter]
        public GetChildNodesDelegate<TNode> GetChildNodesCallback { get; set; }
        /// <summary>
        /// A function to lazy load child nodes. Only required if lazy loading / load on demand
        /// is used. 
        /// (Optional - unless <see cref="GetChildNodesCallback"/> returns null)
        /// </summary>
        /// <remarks>
        /// This function is called when <see cref="GetChildNodesCallback"/> returns null. 
        /// This causes this function to be called which should load all the child nodes.
        /// The callback is asynchronous and should return when the values have been loaded.
        /// 
        /// If an error occurs during the loading, then throw an exception (the exceptions message
        /// will be shown in the UI). The function many be called again for the same node in order
        /// to re-try.
        /// </remarks>
        /// <example><![CDATA[
        /// <MatTreeView TNode="MyTreeNode"
        ///             GetChildNodesCallback="@GetChildNodes" 
        ///             LoadChildNodesCallback="@LoadChildNodesAsync" />
        /// ...
        /// @code {
        ///     private IEnumerable<MyTreeNode> GetChildNodes(MyTreeNode parentNode)
        ///     {
        ///         if (parentNode.AreChildrenLoaded == false)
        ///             return null; // LoadChildrenCallbackAsync will be called to load the child nodes
        ///             
        ///         return parentNode.Nodes;
        ///     }
        ///     
        ///     private Task<IEnumerable<MyTreeNode>> LoadChildNodesAsync(MyTreeNode parentNode)
        ///     {
        ///         if (parentNode.AreChildrenLoaded == false)
        ///         {
        ///             await parentNode.Nodes = MyWebApi.GetChildNodes(parentNode.ID);
        ///         }
        ///             
        ///         return parentNode.Nodes;
        ///     }        
        /// }        
        /// ]]></example>        
        [Parameter]
        public LoadChildNodesDelegate<TNode> LoadChildNodesCallback { get; set; }
        /// <summary>
        /// A function that indicates if the given node is expanded or collapsed.
        /// (Optional - if null then the expanded/collapsed state is managed by the <see cref="MatTreeView{TNode}"/>)
        /// </summary>
        /// <example><![CDATA[
        /// <MatTreeView TNode="MyTreeNode"
        ///             IsNodeExpandedCallback="@((myTreeNode)=>myTreeNode.IsExpanded)" />
        /// 
        /// or 
        /// 
        /// <MatTreeView TNode="MyTreeNode"
        ///             IsNodeExpandedCallback="@IsExpanded" />
        /// ...
        /// @code {
        ///     private bool IsExpanded(MyTreeNode myTreeNode)
        ///     {
        ///         return myTreeNode.IsExpanded;
        ///     }
        /// }
        /// ]]></example>
        [Parameter]
        public IsNodeExpandedDelegate<TNode> IsNodeExpandedCallback { get; set; }

        /// <summary>
        /// An event raised when the expanded state of a node changes
        /// </summary>
        [Parameter]
        public EventCallback<ExpandedStateChangedArgs<TNode>> ExpandStateChanged { get; set; }
        /// <summary>
        /// An event raised when the selected node changes
        /// </summary>
        [Parameter]
        public EventCallback<TNode> SelectedNodeChanged { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (_rootNodes == null)
            {
                throw new ArgumentException($"One of the following must be supplied {nameof(RootNode)} or {nameof(RootNodes)} (but NOT BOTH)");
            }
            if (NodeTemplate == null)
            {
                throw new ArgumentException($"The parameter {nameof(NodeTemplate)} has not been set");
            }
            if (GetChildNodesCallback == null)
            {
                throw new ArgumentException($"The parameter {nameof(GetChildNodesCallback)} has not been set");
            }

            // ensure everything is expanded up to the selected node
            var pathToSelected = new List<TNode>();
            BuildPathToSelected(this.RootNodes, pathToSelected);
            //if (pathToSelected.Count > 0) pathToSelected.RemoveAt(0); // don't expand the selected node
            foreach (var pathNode in pathToSelected)
            {
                if (this.IsNodeExpanded(pathNode) == false)
                {
                    this._expandedNodes[pathNode] = true;
                    await ExpandStateChanged.InvokeAsync(new ExpandedStateChangedArgs<TNode>(pathNode, true));
                }
            }

            await base.OnParametersSetAsync();
        }

        protected async override Task OnInitializedAsync()
        {            

            await base.OnInitializedAsync();
        }

        internal bool IsNodeSelected(TNode node)
        {
            return node == this.SelectedNode;
        }
        internal bool IsNodeExpanded(TNode node)
        {
            // if we have a callback then expanded state is managed via that
            if (IsNodeExpandedCallback != null)
            {
                return IsNodeExpandedCallback(node);
            }

            // not call back, so manage the state ourselves
            return _expandedNodes.TryGetValue(node, out bool state) && state;
        }

        internal async Task SetExpandedNodeAsync(TNode node, bool expanded)
        {
            this._expandedNodes[node] = expanded;
            await ExpandStateChanged.InvokeAsync(new ExpandedStateChangedArgs<TNode>(node, expanded));
            await EnsureSelectedNodeIsVisible();
            StateHasChanged();
        }

        /// <summary>
        /// Ensures that the selected node is visible, if its not then the
        /// selection is moved to the first visible ancestor.
        /// If no ancestors exist then its set to null
        /// </summary>
        /// <returns></returns>
        private Task EnsureSelectedNodeIsVisible()
        {
            var pathToSelected = new List<TNode>();
            if (BuildPathToSelected(this.RootNodes, pathToSelected))
            {
                foreach (var node in pathToSelected)
                {
                    if (IsNodeExpanded(node) == false)
                    {
                        return SetSelectedNodeAsync(node);
                    }
                }
                return Task.CompletedTask;
            }
            else
            {
                return SetSelectedNodeAsync(null);
            }
        }


        // spider this nodes building a path to the selected node
        private bool BuildPathToSelected(IEnumerable<TNode> nodes, List<TNode> path)
        {
            if (nodes == null)
            {
                return false;
            }

            foreach (var node in nodes)
            {
                if (node == this.SelectedNode)
                {
                    return true;
                }
                else
                {
                    if (BuildPathToSelected(GetChildNodesCallback(node), path))
                    {
                        path.Insert(0, node);
                        return true;
                    }
                }
            }
            return false;
        }

        internal async Task SetSelectedNodeAsync(TNode node)
        {
            this.SelectedNode = node;
            await SelectedNodeChanged.InvokeAsync(node);
            StateHasChanged();
        }

    }
}
