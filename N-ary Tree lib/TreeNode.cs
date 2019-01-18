using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(TreeNode<T> parent, T value)
        {
            this.Children = new List<TreeNode<T>>();
            this.Value = value;
            this.Parent = parent;

        }
    }
}
