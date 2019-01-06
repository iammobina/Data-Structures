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
            //inorder traversal +check it
            Node[] root = LoadTree(nodes);
            
            //List<long> Inorder = new List<long>();
            long[] Answer = new long[nodes.Length];
            Answer =InOrder(root);

           
            Node node = root[0];
            //s.Push(node);
            //while (s.Count > 0)
            //{
            //    Node current = s.Pop();
            //}
            //if (Checked(Answer))
            //    return true;

            //return false;
            Stack<Node> s = new Stack<Node>();
            s.Push(node);
            while (s.Count > 0)
            {
                Node current = s.Pop();
                if (current != null)
                {
                    if (current == current.root.left)
                    {
                        current.max = current.root.Data;
                        current.min = current.root.min;
                    }
                    else
                    {
                        current.max = current.root.max;
                        current.min = current.root.min;
                    }
                }
                if (current.Data > current.max || current.Data < current.min)
                    return false;
                if (current.right != null)
                    s.Push(current.right);
                if (current.left != null)
                    s.Push(current.left);
            }

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
        public long[] InOrder(Node[] root)
        {//left root right
            if (root == null)
                return new long[] { 0 };

            List<long> Answer = new List<long>();
            Stack<Node> s = new Stack<Node>();
            Node current = root[0];

            while (current != null || s.Count > 0)
            {
                while (current != null)
                {
                    s.Push(current);
                    current = current.left;
                }
                current = s.Pop();
                Answer.Add(current.Data);
                current = current.right;
            }
           
            return Answer.ToArray();
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
        public bool Checked(long[] Traversal)
        {
            for (int i = 0; i < Traversal.Length - 1; i++)
                if (Traversal[i] > Traversal[i + 1])
                    return false;

            return true;
        }
    }    
}
