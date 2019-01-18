using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_ary_Tree;
using NUnit.Framework;

namespace N_ary_Tree_lib_test
{   
    [TestFixture]
    public class TreeNodeTest
    {
        [TestCase]
        public void TestTree_AddChildNode(){
            // Arrange
            Tree<string> Tree = new Tree<string>();

            // Act
            var Root = Tree.AddChildNode(null, "Root");
            var Node1 = Tree.AddChildNode(Root, "Node1");

            // Assert
            Assert.True(Root.Value == "Root" && Root.Children[0] == Node1);
        }

        [TestCase]
        public void TestTreeRemoveNode()
        {   
            // Arrange
            Tree<int> Tree = new Tree<int>();
            var Root = Tree.AddChildNode(null, 4);
            var Node1 = Tree.AddChildNode(Root, 2);
            var Node2 = Tree.AddChildNode(Root, 24);
            var Node3 = Tree.AddChildNode(Node2, 8);
            var Node4 = Tree.AddChildNode(Node2, 6);

            // Act
            Tree.RemoveNode(Node2);

            // Assert
            Assert.True(Root.Children.Count == 1 );
        }


        [TestCase]
        public void TestTreeTraverse()
        {
            // Arrange
            Tree<int> Tree = new Tree<int>();
            var Root = Tree.AddChildNode(null, 6);
            var Node1 = Tree.AddChildNode(Root, 27);
            var Node2 = Tree.AddChildNode(Node1, 7);
            var Node3 = Tree.AddChildNode(Root, 32);
            var Node4 = Tree.AddChildNode(Node3, 0);
            var Node5 = Tree.AddChildNode(Node3, 5);

            List<int> SoL = new List<int> { 6, 27, 32, 7, 0, 5 };

            // Act
            var Nodes = Tree.TraverseNodes();

            // Assert
            Assert.True(Nodes.SequenceEqual(SoL));
        }
        [TestCase]
        public void TestTreeSumOfLeafs()
        {
            // Arrange
            Tree<double> Tree = new Tree<double>();
            var Root = Tree.AddChildNode(null, 4.5);
            var Node1 = Tree.AddChildNode(Root, 2.2);
            var Node2 = Tree.AddChildNode(Root, 24.0);
            var Node3 = Tree.AddChildNode(Node2, 8.6);
            var Node4 = Tree.AddChildNode(Node2, 6.12);

            List<double> SoL = new List<double>{6.7, 37.1, 34.62};

            // Act
            var SumOfLeafs = Tree.SumOfLeafs();

            // Assert
            Assert.True(SumOfLeafs[1] == SoL[1]);
        }

        [TestCase]
        public void TestTreeSumOfLeafs2()
        {
            // Arrange
            Tree<string> Tree = new Tree<string>();
            var Root = Tree.AddChildNode(null, "4");
            var Node1 = Tree.AddChildNode(Root, "2");
            var Node2 = Tree.AddChildNode(Root, "24");
            var Node3 = Tree.AddChildNode(Node2, "86");
            var Node4 = Tree.AddChildNode(Node2, "6");

            List<string> SoL = new List<string> { "24", "86244", "6244"};

            // Act
            var SumOfLeafs = Tree.SumOfLeafs();

            // Assert
            Assert.True(SumOfLeafs[2] == SoL[2]);
        }
    }
}
