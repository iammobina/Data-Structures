using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class IsItBSTHard : Processor
    {
        public IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            Node[] root = LoadTree(nodes);
            Node node = root[0];
            Node temp;
            if (root.Length == 0)
            //    return true;

            //Stack<Node> s = new Stack<Node>();
            //s.Push(node);
            //while (s.Count > 0)
            //{
            //    temp = s.Pop();
            //    if (temp.root != null)
            //    {
            //        if (temp == temp.root.left)
            //        {
            //            temp.max = temp.root.Data - 1;
            //            temp.min = temp.root.min;
            //        }
            //        else
            //        {
            //            temp.max = temp.root.max;
            //            temp.min = temp.root.Data;
            //        }
            //    }
            //    if (temp.Data > temp.max || temp.Data < temp.min)
            //        return false;
            //    if (temp.right != null)
            //        s.Push(temp.right);
            //    if (temp.left != null)
            //        s.Push(temp.left);
            //}
            return true;
        }
        public Node[] LoadTree(long[][] nodes)
        {
            Node[] root = new Node[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                root[i] = new Node(nodes[i][0]);
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i][1] != -1)
                {
                    root[i].left = root[nodes[i][1]];
                }

                if (nodes[i][2] != -1)
                {
                    root[i].right = root[nodes[i][2]];
                }
            }
            return root;
        }
    }
}
