﻿using System;
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
        private int lenghtOfSeed;
        private int seed;
      
        // Constructor
        public LFSR(string STR_seed, int tapPosition)
        {
            this.tapPosition = tapPosition;
            this.lenghtOfSeed = STR_seed.Length;
            this.seed = 0;
            for (int i = 0; i < lenghtOfSeed; i++)
            {
                
                this.seed *= 2;
                this.seed += STR_seed[i] - '0';
            }  
        }


        //- Class Methods --/

        /// <summary>
        /// This Function shift the leftmost Bit of the seed & Append the returned value of XOR operation in the seed 
        /// and replacing the tap value (only in the function) to shift from left side of string not right side  
        /// </summary>
        /// <returns> Return the a Bit to Be used in generateKey() function </returns>
        public int Step()
        {
            int tap = tapPosition;
            tap = lenghtOfSeed - tap - 1;

            int copy = seed;
            copy = copy << tap;

            int bit = ((copy ^ seed) >> (lenghtOfSeed - 1)) & 1;

            seed = seed << (32 - (lenghtOfSeed - 1));
            seed = seed >> (31 - (lenghtOfSeed - 1));

            seed += bit;

            return bit;
        }


        /// <summary>
        /// This Function is to generate a new Binary Key of K Bits
        /// </summary>
        /// <param name= "K"> the lenght of the Binary Key</param>
        /// <returns> Return a Decimal Key to be used in encrypting the image components </returns>

        public int GenerateKey(int k)
        {
            int key = 0;
            for (int i = 1; i <= k; i++)
            {
                int Bit = Step();
                key *= 2;
                key += Bit;
            } 
            return key;
        }

    }
}


