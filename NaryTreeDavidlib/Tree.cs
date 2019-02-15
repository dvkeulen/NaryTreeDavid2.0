using System;
using System.Collections.Generic;
using System.Linq;

namespace NaryTreeDavid
{
    public class Tree<T>
    {
        public int nodeCount;
        public int leafCount;
        public TreeNode<T> root;
        public List<TreeNode<T>> leafList = new List<TreeNode<T>>();
        public List<TreeNode<T>> nodeList = new List<TreeNode<T>>();

        public Tree(T ivalue)
        {
            root = new TreeNode<T>(ivalue, null);
            leafList.Add(root);
            nodeList.Add(root);
        }

        public TreeNode<T> addChildNode(T ivalue,TreeNode<T> iparent)
        {
            nodeCount = nodeCount + 1;

            // count another leaf if new node has any siblings
            if(iparent.children.Count > 0)
            {
                leafCount = leafCount + 1;
            }

            // Declare the new node the root or the child of it's parent
            TreeNode<T> newNode = new TreeNode<T>(ivalue, iparent);
            if (iparent == null)
            {
                root = newNode;
            }
            else
            {
                iparent.children.Add(newNode);
            }

            // put new leaf in leafList and remove it's parent
            leafList.Add(newNode);
            leafList.Remove(newNode.parent);
            nodeList.Add(newNode);
            return newNode;
        }

        public void removeNode(TreeNode<T> delNode)
        {
            // remove the node from the leafList and add it's parent
            leafList.Add(delNode.parent);
            leafList.Remove(delNode);
            nodeList.Remove(delNode);
            // remove the node from the childlist of the parent and vice versa
            delNode.parent.children.Remove(delNode);
            delNode.parent = null;

            // update the # of nodes and leafs
            nodeCount = nodeCount - 1;
            if(delNode.children.Count > 0 && delNode.parent.children.Count > 0)
            {
                leafCount = leafCount - 1;
            }

            // Delete children (wow) of node
            if(delNode.children.Count > 0)
            {
                for(int i = 0; i < delNode.children.Count; i++)
                {
                    removeNode(delNode.children[i]);
                }
            }
        }

        public List<T> traverseNodes(Tree<T> tree)
        {
            List<T> values = new List<T>();
            foreach(TreeNode<T> node in tree.nodeList)
            {
                values.Add(node.value);
            }
            return values;
        }

        public List<T> sumToLeafs(List<TreeNode<T>> leafList)
        {
            List<T> leafSums = new List<T>();
            TreeNode<T> noot;

            for(int i = 0; i < leafList.Count; i++)
            {
                noot = leafList[i];
                dynamic tempValue = 0;
                while(noot.parent != null)
                {
                    tempValue = tempValue + noot.value;
                    noot = noot.parent;
                }
                tempValue = tempValue + noot.value;
                leafSums.Add(tempValue);
            }

            return leafSums;
        }

    }
}
