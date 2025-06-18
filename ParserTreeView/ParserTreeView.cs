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
               AddChildNode(e.Node, child);
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
               AddChildNode(e.Node, child);
            }
         }
      }

      /// <summary>
      /// Loads the specified ANTLR4 parse tree into this control.
      /// </summary>
      /// <param name="parseTree">The <see cref="ITree"/> instance to load.</param>
      /// <param name="grammar">The <see cref="GrammarReference"/> instance to use.</param>
      public void LoadParseTree(ITree parseTree, GrammarReference grammar)
      {
         ActiveNodes.Clear();
         Nodes.Clear();
         ParseTree = parseTree;
         Grammar = grammar;
         AddChildNode(null, parseTree);
      }

      /// <summary>
      /// Selects the tree node corresponding to the specified <see cref="ITree"/> instance.
      /// </summary>
      /// <param name="tree">The <see cref="ITree"/> instance.</param>
      public void SelectTreeNode(ITree tree)
      {
         var treeNode = AddBranchesTillLeaf(tree);
         SelectedNode = treeNode;
         TopNode = treeNode;
         treeNode.EnsureVisible();
      }

      /// <summary>
      /// Adds all branch nodes till we reach the desired leaf.
      /// </summary>
      /// <param name="tree">The tree instance to create a branch for.</param>
      /// <returns>The final leaf <see cref="TreeNode"/> instance that was created.</returns>
      private TreeNode AddBranchesTillLeaf(ITree tree)
      {
         // TODO: Find and fix the bug in this method's logic

         // fetch our unique ID for the tree instance and then check if it already exists in active nodes
         // if so, we return the existing tree node since nothing more needs to be done
         var nodeName = tree.GetHashCode().ToString();
         if (ActiveNodes.TryGetValue(nodeName, out var treeNode))
            return treeNode;

         // Now we create a stack of ITree instances and begin walking our way up the parentage and pushing them onto the stack
         var stack = new Stack<ITree>();
         var workingChildren = new List<ITree>();
         stack.Push(tree);
         var work = tree.Parent;
         nodeName = work.GetHashCode().ToString();
         while (!ActiveNodes.ContainsKey(nodeName))
         {
            stack.Push(work);
            if (work.Parent == null)
               break;
            work = work.Parent;
            nodeName = work.GetHashCode().ToString();
         }

         TreeNode parentTree;
         if (work.Parent == null)
         {
            if (this.Nodes.Count == 0)
               return null;

            parentTree = this.Nodes[0];
         }
         else
            parentTree = ActiveNodes[nodeName];

         // Now that we built our stack of nodes that need to be created, and we have our starting parent TreeNode
         // We begin popping off ITree instances and creating the nodes.
         while (stack.Count > 0)
         {
            // pop our first work item
            work = stack.Pop();
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
               AddChildNode(parentTree, child);

            // now we add the child that is part of our branch being traversed and set it as the new parent for the branch we are building
            parentTree = AddChildNode(parentTree, work);
         }

         // Now we return the final leaf that was created on the branch
         return parentTree;
      }

      private TreeNode AddChildNode(TreeNode root, ITree tree)
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
