using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Callback used to Lazy Load child nodes
    /// </summary>
    /// <typeparam name="TNode">The node type</typeparam>
    /// <param name="parentNode">The node to load the child nodes for</param>
    /// <returns>All the child nodes (should not return null)</returns>
    /// <exception cref="Exception">Throws if the data could not be loaded - the exceptions message will be displayed to the user</exception>
    public delegate Task<IEnumerable<TNode>> LoadChildNodesDelegate<TNode>(TNode parentNode);

    /// <summary>
    /// A Callback used to get the child nodes for a given node
    /// </summary>
    /// <typeparam name="TNode">The node type</typeparam>
    /// <param name="parentNode">The node to get the child nodes for</param>
    /// <returns>The child nodes (if they are loaded) or null if they are not loaded and lazy loading is being used.</returns>
    public delegate IEnumerable<TNode> GetChildNodesDelegate<TNode>(TNode parentNode);

    /// <summary>
    /// A Callback used to determine if a node should be expanded or collapsed
    /// </summary>
    /// <typeparam name="TNode">The node type</typeparam>
    /// <param name="parentNode">The node we want to know the expanded state for</param>
    /// <returns>The expanded state of the node</returns>
    public delegate bool IsNodeExpandedDelegate<TNode>(TNode parentNode);

    /// <summary>
    /// Event arguments passed when a node expanded state changes
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    public class ExpandedStateChangedArgs<TNode>
    {
        internal ExpandedStateChangedArgs(TNode node, bool newState)
        {
            this.Node = node;
            this.NewState = newState;
        }
        /// <summary>
        /// The node that's expanded state has changed
        /// </summary>
        public TNode Node { get; }
        /// <summary>
        /// the new expanded state
        /// </summary>
        public bool NewState { get; }
    }
}
