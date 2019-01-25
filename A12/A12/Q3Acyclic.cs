using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q3Acyclic : Processor
    {
        public Q3Acyclic(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            // Your code here
            //سر این تمرین کلافه شدممم و خسته خاستم پیاده سازی متنوع انجام بدم مثلللللللللللن
            List<long>[] DirectedGraph = new List<long>[nodeCount+1];
            return CyclicGraph(DirectedGraph,nodeCount);
        }

        public List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            List<long>[] Connecting = new List<long>[nodeCount + 5];

            for (int i = 0; i < Connecting.Length; i++)
                Connecting[i] = new List<long>();
               

            foreach (var vetex in edges)
            {
                Connecting[vetex[0]].Add(vetex[1]);
                //Connecting[vetex[1]].Add(vetex[0]);
            }
            return Connecting;
        }

        private static long CyclicGraph(List<long>[] DirectedGraphy,long nodeCount)
        {
            long[] visited = new long[nodeCount+1];
            long[] RecursionCall = new long[nodeCount+1];
            for (int i = 0; i <= nodeCount; i++)
            {
                if (visited[i] == 0)
                {
                    //if(CyclicGraph(i)==true)
                    if (dfs(DirectedGraphy, i, visited, RecursionCall,nodeCount) == 1)
                        return 1;
                }
            }
            return 0;
        }

        private static int dfs(List<long>[] DirectedGraphy, long x, long[] visited, long[] recall, long nodeCount)
        {

            visited[x] = 1;
            recall[x] = 1;

            for (int i = 0; i <= nodeCount; i++)
            {
                if (visited[i] == 0 && dfs(DirectedGraphy, i, visited, recall, nodeCount) == 1)
                    return 1;
                else if (recall[i] == 1)
                    return 1;
            }
            recall[x] = 0;
            return 0;
        }
    }
}