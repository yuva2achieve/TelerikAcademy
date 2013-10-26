using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TreeUtilities
{
    public class TreeNode<T>
    {
        private readonly T value;
        private readonly List<TreeNode<T>> children;
        private bool hasParent;

        public TreeNode(T value)
        {
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public List<TreeNode<T>> Children
        {
            get
            {
                return this.children;
            }
        }

        public T Value
        {
            get
            {
                return this.value;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
            set
            {
                this.hasParent = value;
            }
        }

        public void AddChild(TreeNode<T> childNode)
        {
            childNode.HasParent = true;
            this.children.Add(childNode);
        }

        public TreeNode<T> GetChildByIndex(int index)
        {
            return this.Children[index];
        }
    }
}
