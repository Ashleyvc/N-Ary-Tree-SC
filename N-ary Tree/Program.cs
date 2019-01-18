using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Maak een Tree met Nodes
            Tree<string> NaryTree = new Tree<string>();

            var Root = NaryTree.AddChildNode(null, "0");
            var Node1 = NaryTree.AddChildNode(Root, "1");
            var Node2 = NaryTree.AddChildNode(Root, "2");
            var Node3 = NaryTree.AddChildNode(Node2, "3");
            var Node4 = NaryTree.AddChildNode(Node2, "4");
            var Node5 = NaryTree.AddChildNode(Node1, "5");
            var Node6 = NaryTree.AddChildNode(Node3, "6");
            var Node7 = NaryTree.AddChildNode(Node3, "7");
            var Node8 = NaryTree.AddChildNode(Node3, "8");
            var Node9 = NaryTree.AddChildNode(Node3, "9");
            var Node10 = NaryTree.AddChildNode(Node7, "10");
            var Node11 = NaryTree.AddChildNode(Node7, "11");
            var Node12 = NaryTree.AddChildNode(Node4, "12");
            var Node13 = NaryTree.AddChildNode(Node4, "13");

            // Bekijk alle values van de Nodes in de tree
            var AllNodes = NaryTree.TraverseNodes();
            Console.WriteLine("Alle values van de nodes uit de Tree");
            AllNodes.ForEach(x => Console.Write("{0}  ", x));
            Console.WriteLine("\n");

            // Bereken per LeafNode de sum van alle parents op het pad t/m de root
            var Sums = NaryTree.SumOfLeafs();
            Console.WriteLine("SumOfLeafs");
            Sums.ForEach(x => Console.WriteLine("{0}", x));
            Console.Write("\n");

            // Toon de Tree
            Console.WriteLine("N-ary Tree");
            NaryTree.ShowTree();

            // Toon de Tree na het verwijderen van node3
            Console.WriteLine("N-ary Tree");
            NaryTree.RemoveNode(Node3);
            NaryTree.ShowTree();

            Console.ReadKey();
        }
    }
}
