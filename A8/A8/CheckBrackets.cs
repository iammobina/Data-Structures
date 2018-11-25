using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class CheckBrackets : Processor
    {
        public CheckBrackets(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            Stack<char> stack = new Stack<char>();
            long Answer = 0;


            if (str.Length == 1)
                return Answer = 1;

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if ((c == '[' || c == '{' || c == '(') && i != str.Length - 1)
                {
                    stack.Push(c);
                }

                if ((c == '[' || c == '{' || c == '(') && i == str.Length - 1)
                {
                    return str.Length;
                }
                else if (c == ']' || c == '}' || c == ')')
                {
                    if (stack.Count == 0)
                        stack.Push(c);

                    switch (c)
                    {
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                                break;
                            }
                            return ++i;

                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                                break;
                            }
                            return ++i;

                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                                break;
                            }
                            return ++i;
                    }
                }
            }
            if (stack.Count != 0)
                {
                    Answer = str.IndexOf(stack.Pop()) + 1;
                }
                else
                {
                    Answer = -1;
                }
            
            return Answer;
        }

        private static char GetComplementBracket(char item)
        {
            //Stack<char> stacky = new Stack<char>();
            switch (item)
            {
                case ')':
                    // stack.Pop();
                    return '(';
                case '}':
                    return '{';
                case ']':
                    return '[';
                default:
                    return ' ';
            }
        }

        class Brackety
        {
            public char Model;
            public int Index;

            public Brackety(char model, int position)
            {
                Model = model;
                Index = position;
            }
            public static bool GetComplementBracket(char item)
            {
                char ch = ')';
                if (item == '(' && ch == ')')
                    return true;
                else if (item == '{' && ch == '}')
                    return true;
                else if (item == '[' && ch == ']')
                    return true;
                else
                    return false;
            }
        }
    }
}