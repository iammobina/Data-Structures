using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckBrackets test = new CheckBrackets("In_1.txt");
            test.Solve("[{}]{");
        }
    }
}
