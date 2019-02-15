using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaryTreeDavid;

namespace NaryTreeProgram
{
    class Program
    {
        static void Main()
        {
            Tree<string> Boom = new Tree<string>("A");
            TreeNode<string> node1 = Boom.addChildNode("B", Boom.root);
            TreeNode<string> node2 = Boom.addChildNode("C", node1);
            TreeNode<string> node3 = Boom.addChildNode("E", node1);
            TreeNode<string> node4 = Boom.addChildNode("F", node3);
            TreeNode<string> node5 = Boom.addChildNode("C", Boom.root);

            // Act
            List<string> travList = Boom.traverseNodes(Boom);

            //foreach (string tempString in travList)
            //Console.WriteLine(tempString);
            Console.Read();
        }
    }
}
