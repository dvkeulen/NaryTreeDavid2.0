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
        static void Main(string[] args)
        {
            Tree<int> boom = new Tree<int>(5);
            boom.addChildNode(4, boom.root);
            Console.Write(boom.root.value);
            Console.Write(boom.root.children);
            Console.Read();
        }
    }
}
