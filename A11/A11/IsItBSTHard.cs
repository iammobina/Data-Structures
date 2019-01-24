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
            if (root.Length == 0)
                return true;

            Stack<Node> s = new Stack<Node>();
            s.Push(node);
            while (s.Count > 0)
            {
                Node current = s.Pop();
                if (current != null)
                {
                    if (current == current.root.left)
                    {
                        current.max = current.root.Data - 1;
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
