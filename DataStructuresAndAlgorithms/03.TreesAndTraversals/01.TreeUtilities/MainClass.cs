using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TreeUtilities
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, TreeNode<int>> nodes = new Dictionary<int, TreeNode<int>>();
            ParseTree(n, nodes);

            TreeNode<int> rootNode = GetRootNode(nodes);
            HashSet<TreeNode<int>> leafNodes = GetLeafNodes(nodes);
            HashSet<TreeNode<int>> middleNodes = GetMiddleNodes(nodes);            
            Console.Write("Leaf nodes: ");
            PrintNodes(leafNodes);

            Console.Write("Middle nodes: ");
            PrintNodes(middleNodes);
            int maxStepsCount = 0;
            Stack<int> nodeValues = new Stack<int>();
            FindLongestPath(rootNode, ref nodeValues, ref maxStepsCount);
            Console.WriteLine("Longest path has: {0} steps", maxStepsCount);
        }

        private static void PrintNodes(HashSet<TreeNode<int>> treeNodes)
        {
            foreach (var node in treeNodes)
            {
                Console.Write("{0} ", node.Value);
            }
            Console.WriteLine();
        }

        private static void ParseTree(int n, Dictionary<int, TreeNode<int>> nodes)
        {
            for (int i = 0; i < n - 1; i++)
            {
                string nodesAsString = Console.ReadLine();
                string[] splitNodes = nodesAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int parentValue = int.Parse(splitNodes[0]);
                int childValue = int.Parse(splitNodes[1]);

                TreeNode<int> parentNode;
                TreeNode<int> childNode;

                if (nodes.ContainsKey(parentValue))
                {
                    parentNode = nodes[parentValue];
                }
                else
                {
                    parentNode = new TreeNode<int>(parentValue);
                    nodes.Add(parentValue, parentNode);
                }

                if (nodes.ContainsKey(childValue))
                {
                    childNode = nodes[childValue];
                }
                else
                {
                    childNode = new TreeNode<int>(childValue);
                    nodes.Add(childValue, childNode);
                }

                parentNode.AddChild(childNode);
            }
        }

        private static TreeNode<int> GetRootNode(IDictionary<int, TreeNode<int>> treeNodes)
        {
            TreeNode<int> root;
            foreach (var item in treeNodes)
            {
                if (!item.Value.HasParent)
                {
                    root = item.Value;
                    return root;
                }
            }

            return null;
        }

        private static HashSet<TreeNode<int>> GetLeafNodes(IDictionary<int, TreeNode<int>> treeNodes)
        {
            HashSet<TreeNode<int>> leafNodes = new HashSet<TreeNode<int>>();

            foreach (var node in treeNodes)
            {
                bool hasParent = node.Value.HasParent;
                bool hasZeroChildren = node.Value.Children.Count == 0;

                if (hasParent && hasZeroChildren)
                {
                    leafNodes.Add(node.Value);
                }
            }

            return leafNodes;
        }

        private static HashSet<TreeNode<int>> GetMiddleNodes(Dictionary<int, TreeNode<int>> treeNodes)
        {
            HashSet<TreeNode<int>> middleNodes = new HashSet<TreeNode<int>>();

            foreach (var node in treeNodes)
            {
                bool hasParent = node.Value.HasParent;
                bool hasChildren = node.Value.Children.Count > 0;

                if (hasParent && hasChildren)
                {
                    middleNodes.Add(node.Value);
                }
            }

            return middleNodes;
        }

        private static void FindLongestPath(TreeNode<int> startNode, ref Stack<int> nodeValues, ref int maxStepsCount)
        {
            nodeValues.Push(startNode.Value);
            foreach (var child in startNode.Children)
            {
                FindLongestPath(child, ref nodeValues, ref maxStepsCount);
            }

            int currentStepsCount = nodeValues.Count;
            if (currentStepsCount > maxStepsCount)
            {
                maxStepsCount = currentStepsCount;
            }

            nodeValues.Pop();
        }
    }
}
