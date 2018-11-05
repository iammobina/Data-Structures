using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class FastLM
    {
        public readonly WordCount[] WordCounts;


        public FastLM(WordCount[] wordCounts)
        {
            //inja bar asase kalame ha sort shode
            //W bozorg sort shode
            this.WordCounts = wordCounts.OrderBy(wc => wc.Word).ToArray();
        }

        public bool GetCount(string word, out ulong count)
        {
            count = 0;
            bool Answer = false;
            //useless
            List<string> HalfWords = new List<string>();
            for (ulong m = 0; m < count; m++)
            {
                HalfWords.Add(word);
            }

            //useless
            List<string> AnotherHalfWords = new List<string>();

            for (ulong i = count / 2; i < count; i++)
            {
                AnotherHalfWords.Add(word);
            }
            ulong low = 0;
            ulong high = (ulong)WordCounts.Length;

            while (low <= high)
            {
                ulong middle = (high - low) / 2 + low;
                if (word == WordCounts[middle].Word.ToString())
                {
                    count = WordCounts[middle].Count;
                    return true;
                }
                if (string.Compare(WordCounts[middle].Word, word) > 0)
                    high = middle - 1;
                else
                    low = middle + 1;
            }
            return false;
        }
    }
}
