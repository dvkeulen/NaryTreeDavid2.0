using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NaryTreeDavid;

namespace NaryTreeTest
{
    [TestFixture]
    public class Test
    {
        // Test add child integer
        [TestCase]
        public void addChildNodeTestInt()
        {
            // Arrange
            Tree<int> Tree = new Tree<int>(3);

            // Act
            TreeNode<int> node1 = Tree.addChildNode(1, Tree.root);
            TreeNode<int> node2 = Tree.addChildNode(4, node1);
            TreeNode<int> node3 = Tree.addChildNode(1, Tree.root);
            TreeNode<int> node4 = Tree.addChildNode(5, node3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(Tree.root.children.Contains(node1));
                Assert.That(Tree.root.children.Contains(node3));
                Assert.That(node1.children.Contains(node2));
                Assert.That(node3.children.Contains(node4));
            });
        }

        // test add child string
        [TestCase]
        public void addChildNodeTestStr()
        {
            // Arrange
            Tree<string> Tree = new Tree<string>("bomen");

            // Act
            TreeNode<string> node1 = new TreeNode<string>("zijn", Tree.root);
            TreeNode<string> node2 = new TreeNode<string>("relax", node1);
            TreeNode<string> node3 = new TreeNode<string>("vet", Tree.root);
            TreeNode<string> node4 = new TreeNode<string>("relax", node3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(Tree.root.children.Contains(node1));
                Assert.That(Tree.root.children.Contains(node3));
                Assert.That(node1.children.Contains(node2));
                Assert.That(node3.children.Contains(node4));
            });
        }

        // test removeNode on childless node
        [TestCase]
        public void removeNodeTest1()
        {
            // Arrange
            Tree<string> Tree = new Tree<string>("bomen");
            TreeNode<string> node1 = new TreeNode<string>("zijn", Tree.root);
            TreeNode<string> node2 = new TreeNode<string>("relax", node1);
            TreeNode<string> node3 = new TreeNode<string>("vet", Tree.root);
            TreeNode<string> node4 = new TreeNode<string>("relax", node3);

            // Act
            Tree.removeNode(node4);

            // Assert
            Assert.That(!node3.children.Contains(node4));
        }

        // test removeNode on perental node
        [TestCase]
        public void removeNodeTest2()
        {
            // Arrange
            Tree<string> Tree = new Tree<string>("bomen");
            TreeNode<string> node1 = new TreeNode<string>("zijn", Tree.root);
            TreeNode<string> node2 = new TreeNode<string>("relax", node1);
            TreeNode<string> node3 = new TreeNode<string>("vet", Tree.root);
            TreeNode<string> node4 = new TreeNode<string>("relax", node3);

            // Act
            Tree.removeNode(node3);

            // Assert
            Assert.That(!Tree.root.children.Contains(node3));
        }

        // test sumtoleafs with integers
        [TestCase]
        public void sumToLeafsTestInt()
        {
            // Arrange
            Tree<int> Tree = new Tree<int>(1);
            TreeNode<int> node1 = Tree.addChildNode(2, Tree.root);
            TreeNode<int> node2 = Tree.addChildNode(4, node1);
            TreeNode<int> node3 = Tree.addChildNode(3, Tree.root);
            TreeNode<int> node4 = Tree.addChildNode(5, node3);
            TreeNode<int> node5 = Tree.addChildNode(6, node3);

            // Act
            List<int> leafSums = Tree.sumToLeafs(Tree.leafList);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(leafSums[0] == 7);
                Assert.That(leafSums[1] == 9);
                Assert.That(leafSums[2] == 10);
            });
        }


        // test sumtoleafs with strings
        [TestCase]
        public void sumToLeafsTestStr()
        {
            // Arrange
            Tree<string> Tree = new Tree<string>("A");
            TreeNode<string> node1 = Tree.addChildNode("B", Tree.root);
            TreeNode<string> node2 = Tree.addChildNode("D", node1);
            TreeNode<string> node3 = Tree.addChildNode("E", node1);
            TreeNode<string> node4 = Tree.addChildNode("F", node3);
            TreeNode<string> node5 = Tree.addChildNode("C", Tree.root);

            // Act
            List<string> leafSums = Tree.sumToLeafs(Tree.leafList);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(leafSums[0] == "DBA");
                Assert.That(leafSums[1] == "FEBA");
                Assert.That(leafSums[2] == "CA");
            });
        }

        // test traversenodes
        [TestCase]
        public void traverseNodes()
        {
            // Arrange
            Tree<string> Boom = new Tree<string>("A");
            TreeNode<string> node1 = Boom.addChildNode("B", Boom.root);
            TreeNode<string> node2 = Boom.addChildNode("C", node1);
            TreeNode<string> node3 = Boom.addChildNode("E", node1);
            TreeNode<string> node4 = Boom.addChildNode("F", node3);
            TreeNode<string> node5 = Boom.addChildNode("C", Boom.root);

            // Act
            List<string> travList = Boom.traverseNodes(Boom);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(travList.Contains("B"));
                Assert.That(travList.Contains("C"));
                Assert.That(travList.Contains("E"));
                Assert.That(travList.Contains("F"));
                Assert.That(travList.Contains("C"));
            });
        }
    }
}
