using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeTraversals b = new BinaryTreeTraversals("ll");
            //    b.InOrder(new Node(4));
            b.Solve(new long[][] { new long[] { 4 ,1, 2 }, new long[] { 2 ,3, 4 }, new long[] { 5 ,- 1 ,-1 }, new long[] { 1 ,- 1 ,- 1 },new long[] { 3 ,-1,-1} });
        }
    }
}
