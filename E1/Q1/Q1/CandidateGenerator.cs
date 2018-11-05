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
            string Blank = "";

            for (int j = 0; j <= word.Length; j++)
                for (int i = 0; i < Alphabet.Length; i++)
                    candidates.Add(Insert(word, j, Alphabet[i]));

            for (int p = 0; p < word.Length; p++)
                for (int q = 0; q < Alphabet.Length; q++)
                {
                    Blank = Delete(word, p);
                    candidates.Add(Insert(Blank, p, Alphabet[q]));
                }

            for (int l = 0; l< word.Length; l++)
                candidates.Add(Delete(word, l));

            return candidates.ToArray();
        }

        private static string Insert(string word, int pos, char c)
        {
            // c haafaye alefba
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length + 1];
            char[] CopyWord = new char[wordChars.Length];
            int lenghofTheWord = word.Length;

            int j = 0;
            for (int i = 0; i < newWord.Length; i++)
            {
                if (i != pos)
                    newWord[i] = wordChars[j++];
                else
                {
                    newWord[i] = c;
                }
            }
                
            

            string ConvertedString= Alphabet.ToString();
            //Testing for The the Special Test

            //foreach (var alphab in Alphabet)
            //{
            //    for (int i = 0; i < Alphabet.Length; i++)
            //    {
            //        int m = 0;
            //        //first element should be alphabets 
            //        newWord[pos] = Alphabet[i];
            //        //then second element should be the old one
            //        pos++;
            //        newWord[pos] += CopyWord[m];
            //       m++;
            //    }
            //}
            
            return new string(newWord);
        }


        private static string Delete(string word, int pos)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length - 1];
            char[] CopyWord = new char[wordChars.Length];

            List<string> CopyWordR = new List<string>();
            for(int l=0;l< wordChars.Length; l++)
            {
                CopyWordR.Add(word);
            }
            //in this case i want to copy the elements of all 
            for(int i=0;i< wordChars.Length; i++)
            {
                    int h = 0;
                    CopyWord[h] = wordChars[i];
                    h++;
               // CopyWord.Add(word.IndexOf(i));
            }
            int k = 0;

            for (int i = 0, j = 0; i < wordChars.Length; i++)
                if (i != pos)
                {
                    newWord[k++] = wordChars[i];
                }
                    

          
            return new string(newWord);
           //return CopyWordR.ToString();
        }

        private static string Substitute(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length];
            char[] CopyElement=new char[wordChars.Length];

            for (int i = 0; i < newWord.Length; i++)
            {
                if (i != pos)
                    newWord[i] = wordChars[i];
                else
                    newWord[i] = wordChars[pos];

            }

            //Times up
            return new string(newWord);
        }

    }
}
