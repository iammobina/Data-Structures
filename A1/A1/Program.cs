using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static string Process(string Input)
        {
            StringBuilder sb = new StringBuilder();
            using (StringReader Reader = new StringReader(Input))
            using (StringWriter Writer = new StringWriter(sb))
            {
                int a = int.Parse(Reader.ReadLine());
                int b = int.Parse(Reader.ReadLine());
                Writer.WriteLine(Add(a, b));
            }
            return sb.ToString();
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
