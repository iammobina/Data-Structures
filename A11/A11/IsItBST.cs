using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class IsItBST : Processor
    {
        public IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            //postorderr+max o min nodes
            Node[] root = LoadTree(nodes);
            Stack<Node> s = new Stack<Node>();
            Node node = root[0];
            s.Push(node);
            //while (s.Count > 0)
            //{
            //    Node current = s.Pop();
            //}
            return true;
        }
        public Node[] LoadTree(long[][] nodes)
        {
            Node[] root = new Node[nodes.Length];
            for(int i=0;i<nodes.Length;i++)
            {
                root[i] = new Node(nodes[i][0]);
            }
            for(int i=0;i<nodes.Length;i++)
            {
                if(nodes[i][1] !=-1)
                {
                    root[i].left = root[nodes[i][1]];
                }

                if(nodes[i][2] !=-1)
                {
                    root[i].right=root[nodes[i][2]];
                }
            }
            return root;
        }
        //public long[] PostOrder(Node[] binaryTree)
        //{//left,right,root
        //    Stack<Node> stack = new Stack<Node>();
        //    List<long> Answer = new List<long>();
        //    Node root = binaryTree[0];
        //    while (root != null || stack.Count > 0)
        //    {
        //        while (root != null)
        //        {
        //            if (root.right != null)
        //                stack.Push(root.right);
        //            stack.Push(root);
        //            root = root.left;
        //        }

        //        root = stack.Pop();
        //        if (root.right != null && stack.Count > 0 && stack.Peek() == root.right)
        //        {
        //            stack.Pop();
        //            stack.Push(root);
        //            root = root.right;
        //        }
        //        else
        //        {
        //            Answer.Add(root.Data);
        //            root = null;
        //        }
        //    }
        //    return Answer.ToArray();
        //}
    }    
}
