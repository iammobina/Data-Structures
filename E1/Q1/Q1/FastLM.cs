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
            List<string> HalfWords = new List<string>();
            for(ulong m =0;m<count;m++)
            {
                HalfWords.Add(word);
            }
           
            //useless
            List<string> AnotherHalfWords = new List<string>();

            for (ulong i = count/2; i < count; i++)
            {
                AnotherHalfWords.Add(word);
            }
            foreach (var numb in WordCounts)
            {
                ulong low = 0;
                ulong high = (ulong)WordCounts.Length;
                ulong middle1 = (high + low / 2) + low;
                foreach (var s in word)
                {
                    while (true)
                    {
                        ulong middle = (high + low / 2) + low;
                        if ((low < high) || (middle > (ulong)WordCounts.Length))
                        {
                            Answer = false;
                        }
                        if (word == HalfWords[(int)middle])
                        {
                            Answer = true;
                        }
                    }  
                }
                if (low < middle1)
                    low = middle1 - 1;
                else
                    low = middle1 + 1;
            }
            return Answer;
        }
    }
}
