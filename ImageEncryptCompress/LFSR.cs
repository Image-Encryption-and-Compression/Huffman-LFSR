using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImageEncryptCompress
{
    public class LFSR
    {

        //- Class Data Members --/

        public int tapPosition;
        private StringBuilder seed;


        // Constructor
        public LFSR(string seed, int tapPosition)
        {

            this.tapPosition = tapPosition;
            this.seed = new StringBuilder(seed);
        }


        //- Class Methods --/

        /// <summary>
        /// This Function shift the leftmost Bit of the seed & Append the returned value of XOR operation in the seed 
        /// and replacing the tap value (only in the function) to shift from left side of string not right side  
        /// </summary>
        /// <returns> Return the Returned_Bit to Be used in generateKey() function </returns>

        public char ShiftBit()
        {

            int tap = tapPosition;
            tap = seed.Length - tap - 1;

            char ReturnedBit = (char)('0' + (seed[0] - '0') ^ (seed[tap] - '0'));

            seed.Remove(0, 1);  // shifting 1st Bit in seed string
            seed.Append(ReturnedBit);

            return ReturnedBit;
        }


        /// <summary>
        /// This Function is to generate a new Binary Key of K Bits, Then converting the Bin_key into a Decimal_Key
        /// </summary>
        /// <param name= "K"> the lenght of the Binary Key</param>
        /// <returns> Return a Decimal Key to be used in encrypting the image components </returns>

        public int GenerateKey(int k)
        {

            StringBuilder keyBin = new StringBuilder("");

            for (int i = 1; i <= k; i++)
            {

                char Bit = ShiftBit();
                keyBin.Append(Bit);
            }

            int keyDecimal = Convert.ToInt32(keyBin.ToString(), 2); // Converting Bin_key to Dec_key

            return keyDecimal;

        }

    }
}


