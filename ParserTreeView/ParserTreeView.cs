using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Antlr4.Runtime.Tree;
using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing
{
   public partial class ParserTreeView : TreeView
   {
      public GrammarReference Grammar { get; private set; }
      public ITree ParseTree { get; private set; }
      private Dictionary<string, TreeNode> ActiveNodes { get; } = new Dictionary<string, TreeNode>();

      /// <summary>
      /// Initializes a new instance of the <see cref="ParserTreeView"/> class.
      /// </summary>
      public ParserTreeView()
      {
         InitializeComponent();
         BeforeSelect += ParserTreeView_BeforeSelect;
         BeforeExpand += ParserTreeView_BeforeExpand;
      }

      private void ParserTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
      {
         if (e.Node.Tag is ITree tree)
         {
            for (var i = 0; i < tree.ChildCount; i++)
            {
               var child = tree.GetChild(i);
               AddChildNodeAndLeaves(e.Node, child);
            }
         }
      }

      /// <summary>
      /// Handles the BeforeSelect event of the ParserTreeView control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
      private void ParserTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
      {
         // execute lazy loading of all children for the node being selected
         if (e.Node.Tag is ITree tree)
         {
            for (var i = 0; i < tree.ChildCount; i++)
            {
               var child = tree.GetChild(i);
               AddChildNodeAndLeaves(e.Node, child);
            }
         }
      }

      /// <summary>
      /// Loads the specified ANTLR4 parse tree into this control.
      /// </summary>
      /// <param name="parseTree">The <see cref="ITree"/> instance to load.</param>
      /// <param name="grammar">The <see cref="GrammarReference"/> instance to use.</param>
      /// <exception cref="ArgumentNullException">tree or grammar were null.</exception>
      public void LoadParseTree(ITree parseTree, GrammarReference grammar)
      {
         if (parseTree == null) throw new ArgumentNullException(nameof(parseTree));
         if (grammar == null) throw new ArgumentNullException(nameof(grammar));

         ActiveNodes.Clear();
         Nodes.Clear();
         ParseTree = parseTree;
         Grammar = grammar;
         AddChildNodeAndLeaves(null, parseTree);
      }

      /// <summary>
      /// Selects the tree node corresponding to the specified <see cref="ITree"/> instance.
      /// </summary>
      /// <param name="tree">The <see cref="ITree"/> instance to use.</param>
      /// <returns>The selected <see cref="TreeNode"/> or null if not found.</returns>
      /// <exception cref="ArgumentNullException">tree was null.</exception>
      public TreeNode SelectTreeNode(ITree tree)
      {
         if (tree == null) throw new ArgumentNullException(nameof(tree));

         var treeNode = AddBranchesTillLeaf(tree);
         if (treeNode != null)
         {
            SelectedNode = treeNode;
            TopNode = treeNode;
            treeNode.EnsureVisible();
         }
         return treeNode;
      }

      /// <summary>
      /// Displays the tree node that corresponds to the specified <see cref="ITree"/> instance.
      /// </summary>
      /// <param name="tree">The <see cref="ITree"/> to use.</param>
      /// <returns>The displayed <see cref="TreeNode"/> or null if one was not found.</returns>
      /// <exception cref="ArgumentNullException">tree was null.</exception>
      public TreeNode DisplayTreeNode(ITree tree)
      {
         if (tree == null) throw new ArgumentNullException(nameof(tree));

         var treeNode = AddBranchesTillLeaf(tree);
         if (treeNode != null)
         {
            TopNode = treeNode;
            treeNode.EnsureVisible();
         }
         return treeNode;
      }

      /// <summary>
      /// Finds the tree node corresponding to the specified <see cref="ITree"/> instance.
      /// </summary>
      /// <param name="tree">The <see cref="ITree"/> node to use.</param>
      /// <returns>The corresponding <see cref="TreeNode"/> instance or null if not found.</returns>
      /// <exception cref="ArgumentNullException">tree was null.</exception>
      public TreeNode FindTreeNode(ITree tree)
      {
         if (tree == null) throw new ArgumentNullException(nameof(tree));

         return AddBranchesTillLeaf(tree);
      }

      /// <summary>
      /// Adds all branch nodes till we reach the desired leaf.
      /// </summary>
      /// <param name="tree">The tree instance to create a branch for.</param>
      /// <returns>The final leaf <see cref="TreeNode"/> instance that was created.</returns>
      /// <exception cref="ArgumentNullException">tree was null.</exception>
      private TreeNode AddBranchesTillLeaf(ITree tree)
      {
         if (tree == null) throw new ArgumentNullException(nameof(tree));

         // fetch our unique ID for the tree instance and then check if it already exists in active nodes
         // if so, we return the existing tree node since nothing more needs to be done
         var nodeName = tree.GetHashCode().ToString();
         if (ActiveNodes.TryGetValue(nodeName, out var treeNode))
            return treeNode;

         // Now we create a stack of ITree instances and begin walking our way up the parentage and pushing them onto the stack
         var stack = new Stack<ITree>();
         
         if (!BuildBranchStackFromTreeNode(tree, stack, out var parentTree)) 
            return null;
         
         // Now that we built our stack of nodes that need to be created, and we have our starting parent TreeNode
         // We begin popping off ITree instances and creating the nodes.
         parentTree = CreateBranchNodesAndLeavesFromStack(stack, parentTree);

         // Now we return the final leaf that was created on the branch
         return parentTree;
      }

      /// <summary>
      /// Builds the branch stack from specified tree node.
      /// </summary>
      /// <param name="tree">The destination node we wish to build the intervening branch and leaves for.</param>
      /// <param name="stack">The stack to add prospective nodes to.</param>
      /// <param name="parentTree">The parent tree node to build the branch and leaves off of.</param>
      /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
      private bool BuildBranchStackFromTreeNode(ITree tree, Stack<ITree> stack, out TreeNode parentTree)
      {
         stack.Push(tree);
         var work = tree.Parent;
         var nodeName = work.GetHashCode().ToString();
         while (!ActiveNodes.ContainsKey(nodeName))
         {
            stack.Push(work);
            if (work.Parent == null)
               break;
            work = work.Parent;
            nodeName = work.GetHashCode().ToString();
         }

         if (work.Parent == null)
         {
            if (this.Nodes.Count == 0)
            {
               parentTree = null;
               return false;
            }

            parentTree = this.Nodes[0];
         }
         else
            parentTree = ActiveNodes[nodeName];

         return true;
      }

      /// <summary>
      /// Creates the branch nodes and leaves from stack.
      /// </summary>
      /// <param name="stack">The stack to use.</param>
      /// <param name="parentTree">The parent tree node to build on.</param>
      /// <returns>Returns a <see cref="TreeNode"/> representing our final leaf.</returns>
      private TreeNode CreateBranchNodesAndLeavesFromStack(Stack<ITree> stack, TreeNode parentTree)
      {
         var workingChildren = new List<ITree>();
         while (stack.Count > 0)
         {
            // pop our first work item
            var work = stack.Pop();
            // clear our working children list
            workingChildren.Clear();
            // our working parent should never be null and if it is, something has gone HORRIBLY wrong, we will leave it to error in that case
            for (var i = 0; i < work.Parent.ChildCount; i++)
            {
               // We add all children to the working children list that IS NOT the branch node we will be building off of
               var child = work.Parent.GetChild(i);
               if (child != work)
                  workingChildren.Add(child);
            }

            // now we add our extra working children from our list
            foreach (var child in workingChildren) 
               AddChildNodeAndLeaves(parentTree, child);

            // now we add the child that is part of our branch being traversed and set it as the new parent for the branch we are building
            parentTree = AddChildNodeAndLeaves(parentTree, work);
         }

         return parentTree;
      }

      private TreeNode AddChildNodeAndLeaves(TreeNode root, ITree tree)
      {
         // Add the child node
         var nodeName = tree.GetHashCode().ToString();
         if (!ActiveNodes.TryGetValue(nodeName, out var treeNode))
         {
            treeNode = new TreeNode(Trees.GetNodeText(tree, Grammar.ParserRules))
            {
               Tag = tree,
               Name = nodeName
            };
            if (root == null)
               this.Nodes.Add(treeNode);
            else
               root.Nodes.Add(treeNode);
            ActiveNodes[nodeName] = treeNode;
         }

         // Now we also add any children of that child node to prepopulate the tree enough to show nodes with children
         for (var i = 0; i < tree.ChildCount; i++)
         {
            Application.DoEvents();
            var child = tree.GetChild(i);
            nodeName = child.GetHashCode().ToString();
            if (ActiveNodes.ContainsKey(nodeName))
               continue;
            var newChild = new TreeNode(Trees.GetNodeText(child, Grammar.ParserRules))
            {
               Tag = child,
               Name = nodeName
            };
            treeNode.Nodes.Add(newChild);
            ActiveNodes[nodeName] = newChild;
         }

         return treeNode;
      }
   }
}
