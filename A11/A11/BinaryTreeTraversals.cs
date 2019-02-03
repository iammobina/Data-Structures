using System;
using System.Collections;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class Node
    {
        public long Data;
        public Node left, right, root;
        public long min = long.MinValue;
        public long max=long.MaxValue;


        public Node(long data)
        {
           Data = data;
           root= left = right = null;
        }


    }
    public class BinaryTreeTraversals : Processor
    {
        public BinaryTreeTraversals(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);



        public long[][] Solve(long[][] nodes)
        {

            Node[] BinaryTree = LoadTree(nodes);
            return new long[3][] { InOrder(BinaryTree), PreOrder(BinaryTree), PostOrder(BinaryTree)};


        }

        public long[] PostOrder(Node[] binaryTree)
        {//left,right,root
            Stack<Node> stack = new Stack<Node>();
            List<long> Answer = new List<long>();
            Node root = binaryTree[0];
            while (root != null || stack.Count > 0)
            { 
                while (root != null)
                {
                    if (root.right != null)
                    stack.Push(root.right);
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (root.right != null && stack.Count>0 && stack.Peek() == root.right)
                {
                    stack.Pop();
                    stack.Push(root);
                    root = root.right;
                }
                else
                {
                    Answer.Add(root.Data);
                    root = null;
                }
            }
            return Answer.ToArray();
        }

        public long[] PreOrder(Node[] binaryTree)
        {//root,left,right
            Stack<Node> s = new Stack<Node>();
            List<long> Answer = new List<long>();
            Node root = binaryTree[0];
            s.Push(root);
            while(s.Count >0)
            {
                Node current = s.Pop();
                Answer.Add(current.Data);
                if (current.right != null) 
                s.Push(current.right);
                if (current.left != null)
                    s.Push(current.left);
            }
          return  Answer.ToArray();
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
                while (current !=null)
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


        public Node[] LoadTree(long[][] nodes)
        {

            Node[] Tree = new Node[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
                Tree[i] = new Node(nodes[i][0]);
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i][1] != -1)
                    Tree[i].left = Tree[nodes[i][1]];
                if (nodes[i][2] != -1)
                    Tree[i].right = Tree[nodes[i][2]];
            }
            return Tree;
            //for (int i = 0; i < nodes.Length; i++)
            //    for (int j = 0; j < nodes.Length; j++)
            //    {
            //        if (nodes[i][j] != -1)
            //        {
            //            Node left = new Node(nodes[j][0]);
            //            Node Right = new Node(nodes[j][0]);
            //        }

            //    }
        }
    }
}
