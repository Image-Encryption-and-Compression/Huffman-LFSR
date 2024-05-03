using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageEncryptCompress
{
    internal class LFSR_Class
    {

        // this function to generate lenght of the key for encryption & decryption.
        public string generate_Key(int K)
        {

            string ini_seed = "01101000010";
            // int Tap = Console.ReadLine(); 

            // string builders 
            StringBuilder seed = new StringBuilder(ini_seed);
            StringBuilder key = new StringBuilder();

            int Tap = 8; // Tap_Postition 
            // int Tap = Console.ReadLine();

            Tap = seed.Length - Tap - 1; // to shift from the left


            for (int i = 1; i <= K; i++)
            {

                int Returned_Val = (seed[0] ^ seed[Tap]);  // XOR operation | Notice: return value form ^ operator is int 

                key.Append(Returned_Val);
                seed.Append(Returned_Val.ToString());

                seed.Remove(0, 1); // shifting the 1st item in the string
            }

            return key.ToString();

        }

    }
}


