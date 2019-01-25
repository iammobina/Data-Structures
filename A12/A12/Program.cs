using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A12
{
    public class Program
    {
        static void Main(string[] args)
        {
            //    Q1MazeExit s = new Q1MazeExit("f");
            //    s.Solve(4,new long[][] { new long[] { 1, 2 }, new long[] { 3, 2 }, new long[] { 4, 3 }, new long[] { 1, 4 } },1, 4);

            //Q2AddExitToMaze s = new Q2AddExitToMaze("s");
            //s.Solve(4, new long[][] { new long[] { 1, 2 }, new long[] { 3, 2 } });

            Q3Acyclic s = new Q3Acyclic("s");
            s.Solve(5, new long[][] { new long[] { 1, 2 }, new long[] { 2, 3 }, new long[] { 1, 3 }, new long[] { 3, 4 }, new long[] { 1, 4 }, new long[] { 2, 5 }, new long[] { 3, 5 } });


        }
    }
}
