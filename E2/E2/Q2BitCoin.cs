using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace E2
{
    public class Q2BitCoin
    {
        public static SHA256Managed Hasher= new SHA256Managed();

        /// <summary>
        /// این پیاده سازی کار نمیکنه چون فقط یک عدد را امتحان میکند
        /// باید این پیاده سازی را طوری عوض کنید که یک 
        /// nonce 
        /// درست را پیدا کند.
        /// </summary>
        public bool Mine(byte[] data, int difficultyLevel, out uint nonce)
        {
            // List<int> HowManyZero = new List<int>();
            Random rnd = new Random(0);

            // Try one random value
            List<uint> diffrentNumbers = new List<uint>();
            for (uint i = 0; i < uint.MaxValue; i++)
            {
                diffrentNumbers.Add(i);
            }


            //برای اینکه نانس رو پیدا بکنیم چون واحد ما unit است میتوانیم 
            //با یک فور تمام حالات را بررسی کنیم
            for(uint i=0;i<diffrentNumbers.Count;i++)
            {
                nonce = i;
            }

            nonce =(uint) rnd.Next(0, int.MaxValue);
            // Copy nonce to the end of data

            //    nonce = BestNonce();
            //foreach (var element in diffrentNumbers)
            //{
              //  nonce = BestNonce(data);
                BitConverter.GetBytes(nonce).CopyTo(data, sizeof(uint));
                // Calculate Hash
                byte[] doubleHash = Hasher.ComputeHash(Hasher.ComputeHash(data));

                // How many zero bytes does it have at the end?
                int zeroBytes = CountEndingZeroBytes(doubleHash, difficultyLevel);

                //} while (zeroBytes >= difficultyLevel);
                //HowManyZero.Add(zeroBytes);

                //do
                //{
                //   nonce = BestNonce();
                //} while (zeroBytes >= difficultyLevel);
            //}
                // Return if the number of zero bytes is enough
                return zeroBytes >= difficultyLevel;
            
        }

        public static int CountEndingZeroBytes(byte[] doubleHash, int? maxBytesToCheck = null)
        {
            int zeroBytes = 0;
            for (int i = doubleHash.Length - 1;
                     i >= doubleHash.Length - (maxBytesToCheck??doubleHash.Length);
                     i--, zeroBytes++)
            {
                if (doubleHash[i] > 0)
                    break;
            }
            return zeroBytes;
        }

   //     public static bool BestNonce(byte[] data,out uint nonce)
   //     {
   //         nonce = 0;
   //         List<uint> diffrentNumbers = new List<uint>();
   //         for (uint i = 0; i < int.MaxValue; i++)
   //         {
   //             diffrentNumbers.Add(i);
   //         }
   //         foreach (var el in diffrentNumbers)
   //         {
   //             BitConverter.GetBytes(el).CopyTo(data, sizeof(uint));
   //             byte[] doubleHash = Hasher.ComputeHash(Hasher.ComputeHash(data));
   //             int zeroBytes = CountEndingZeroBytes(doubleHash, 3);
               
   //             //for (uint i = 0/*uint.MinValue*/; i <= int.MaxValue; i++)
   //             //{
   //             //    nonce = i;
   //             //}
   //             //return nonce;
   //                 if (zeroBytes >= 3)
   //                 {
   //                     nonce = el;
   //                     break;
   //                 }
   //                 else
   //                     continue;
                
   //         }
   //             return nonce;
   //}
        
        public static uint randomNonce()
        {
            Random rand = new Random();
            uint nonce = (uint)rand.Next(0, int.MaxValue);
            return nonce;
        }
    }
}