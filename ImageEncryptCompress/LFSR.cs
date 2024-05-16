using System;
using System.Collections;
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
        private int tapPosition;
        private int lengthOfSeed;
        private long seed;
      
        // Constructor
        public LFSR(string STR_seed, int tapPosition)
        {
            this.lengthOfSeed = STR_seed.Length;
            this.tapPosition = lengthOfSeed - tapPosition - 1;
            this.seed = Convert.ToInt64(STR_seed, 2);
        }


        //- Class Methods --/

        /// <summary>
        /// This Function shift the leftmost Bit of the seed & Append the returned value of XOR operation in the seed 
        /// and replacing the tap value (only in the function) to shift from left side of string not right side  
        /// </summary>
        /// <returns> Return the a Bit to Be used in generateKey() function </returns>
        public int Step()
        {
            long copy = seed;
            copy = copy << tapPosition;

            long bit = ((copy ^ seed) >> (lengthOfSeed - 1)) & 1;

            seed = seed << (32 - (lengthOfSeed - 1));
            seed = seed >> (31 - (lengthOfSeed - 1));

            seed += bit;

            return (int)bit;
        }


        /// <summary>
        /// This Function is to generate a new Binary Key of K Bits
        /// </summary>
        /// <param name= "K"> the lenght of the Binary Key</param>
        /// <returns> Return a Decimal Key to be used in encrypting the image components </returns>

        public byte GenerateKey(int k)
        {
            byte key = 0;
            for (int i = 1; i <= k; i++)
            {
                byte bit = (byte)Step();
                key *= 2;
                key += bit;
            } 
            return key;
        }

    }
}


