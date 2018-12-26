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
