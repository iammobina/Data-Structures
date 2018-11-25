using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{

    public class TreeHeight : Processor
    {
        public TreeHeight(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            List<Node> Nodes = new List<Node>();
            long Root = 0;
            long deep = 0;

            for (int i = 0; i < nodeCount; i++)
            {
                Nodes.Add(new Node(i));
            }

            for (int i = 0; i < nodeCount; i++)
            {
                if (tree[i] == -1)
                    Root = i;
                else
                    Nodes[(int)tree[i]].AddChild(Nodes[i]);
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(Nodes[(int)Root]);
            while (q.Count != 0)
            {
                int Span = q.Count;
                if (Span > 0)
                {
                    deep = deep + 1;
                }
                for (int j = 0; j < Span; j++)
                {
                    Node element = q.Dequeue();
                    for (int i = 0; i < element.Children.Count; i++)
                        q.Enqueue(element.Children[i]);
                }
            }
            return deep;
        }
    }
    public class Node
    {
        public Node(int index)
        {
            Index = index;
            Children = new List<Node>();
        }

        public int Index;
        public List<Node> Children;

        public void AddChild(Node Child)
        => Children.Add(Child);
    }
}
