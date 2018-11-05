using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public static class CandidateGenerator
    {
        public static readonly char[] Alphabet =
            Enumerable.Range('a', 'z' - 'a' + 1)
                      .Select(c => (char)c)
                      .ToArray();

        public static string[] GetCandidates(string word)
        {
            List<string> candidates = new List<string>();
            //TODO
            return candidates.ToArray();
        }

        private static string Insert(string word, int pos, char c)
        {
            // c haafaye alefba
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length + 1];
            char[] CopyWord = new char[wordChars.Length];
            int lenghofTheWord = word.Length;
            int k = 0;
            for (int j=0;j<lenghofTheWord ; j++)
            {
                CopyWord[k]  = wordChars[j];
                k++;
            }
            string ConvertedString= Alphabet.ToString();
            pos = 0;
            foreach (var alphab in Alphabet)
            {
                for (int i = 0; i < Alphabet.Length; i++)
                {
                    int m = 0;
                    //first element should be alphabets 
                    newWord[pos] = Alphabet[i];
                    //then second element should be the old one
                    pos++;
                    newWord[pos] += CopyWord[m];
                    m++;
                }
            }
            return new string(newWord);
        }


        private static string Delete(string word, int pos)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length - 1];
            char[] CopyWord = new char[wordChars.Length];

            List<string> CopyWordR = new List<string>();
            for(int l=0;l<word.Length;l++)
            {
                CopyWordR.Add(word);
            }
            //in this case i want to copy the elements of all 
            for(int i=0;i<word.Length;i++)
            {
                    int k = 0;
                    CopyWord[k] = wordChars[i];
                    k++;
               // CopyWord.Add(word.IndexOf(i));
            }
            foreach(var s in word)
            {
                CopyWordR.RemoveAt(CopyWordR.IndexOf(s.ToString()));
            }
            //  return new string(newWord);
            return CopyWordR.ToString();
        }

        private static string Substitute(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length];
            //TODO
            return new string(newWord);
        }

    }
}
