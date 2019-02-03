using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q5StronglyConnected : Processor
    {
        public Q5StronglyConnected(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            long NumberofStrongly=0;
            Stack<long> Stack = new Stack<long>();
            bool[] visit = new bool[nodeCount + 1];

            for (int i = 1; i < visit.Length; i++)
                if (visit[i] == false)
                    Sort(i, visit, Stack, Connecting(nodeCount,edges));

            for (int i = 0; i < visit.Length; i++)
                visit[i] = false;

            while (Stack.Count != 0)
            {

                long v = Stack.Pop();
                if (visit[v] == false)
                {
                    dfs(v, visit, RConnecting(nodeCount,edges), NumberofStrongly);
                    NumberofStrongly++;
                }
            }
            return NumberofStrongly;
        }

        public List<long>[] Connecting(long nodeCount,long[][] edges)
        {
            List<long>[] Connecting = new List<long>[nodeCount + 1];
            for (int i = 0; i < Connecting.Length; i++)
            {
                Connecting[i] = new List<long>();
            
            }

            foreach (var vertex in edges)
            {
                Connecting[vertex[0]].Add(vertex[1]);
               
            }
            return Connecting;
        }
        public List<long>[] RConnecting(long nodeCount,long[][] edges)
        {
            
            List<long>[] RConnecting = new List<long>[nodeCount + 1];
            
            for (int i = 0; i < RConnecting.Length; i++)
            {
                
                RConnecting[i] = new List<long>();
            }

            foreach (var vertex in edges)
            {
                
                RConnecting[vertex[1]].Add(vertex[0]);
            }
            return RConnecting;
        }

        private void dfs(long v, bool[] visited, List<long>[] RConnecting, long number)
        {

            visited[v] = true;
            List<long> Rlist = RConnecting[v];
            foreach (var i in Rlist)
            {
                if (visited[i]==false)
                {
                    dfs(i, visited, RConnecting, number);
                }
            }
        }

        private void Sort(long vertex, bool[] visited, Stack<long> stack, List<long>[] Connecting)
        {
            visited[vertex] = true;
            List<long> Clist = Connecting[vertex];
            foreach (var i in Clist)
            {
                if (visited[i]==false)
                Sort(i, visited, stack, Connecting);
            }
            stack.Push(vertex);
        }
    }
}
