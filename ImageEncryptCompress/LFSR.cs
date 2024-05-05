using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/*< code >
  < seed > </ seed >
  < tapPosition > </ tapPosition >
  < key_Bin >  </ key_Bin >
  < key_Decimal >  </ key_Decimal >
</ code > 
*/

namespace ImageEncryptCompress
{
    internal class LFSR
    {

        //- Class Data Members ---/

        public int tapPosition;
        private static StringBuilder seed = new StringBuilder(""); // seed here is static, so Obj value always updated after operations.


        //Constructor
        public LFSR(StringBuilder seedCon,int tapPosition) {

            this.tapPosition = tapPosition;
            seed.Append(seedCon);                        // that's how to assign a "string" value to a "stringBuilder".
        }


        //- Class Methods ---/
        

        /* This function do (2) things: 
         * (1) Shifting the left most bit only once.
         * (2) Updating original seed by the XOR operation.*/

        public char shiftBit()
        {
            int tap = tapPosition;
            tap = seed.Length - tap - 1; // to shift from the left side not right side
            
            char Returned_Val = (char)(seed[0] ^ seed[tap]);  // XOR operation | Notice: return value form ^ operator is int 

            // updating the original seed
            seed.Remove(0, 1); // shifting the 1st item in the string
            seed.Append(Returned_Val);

            return Returned_Val;
        }


        /* This function to generate the key in decimal for encryption & decryption.*/
        public int generateKey(int K)
        {

            StringBuilder key_Bin = new StringBuilder("");  // the Binary Key of K bits

            for (int i = 1; i <= K; i++)
            {
                char Bit = shiftBit();
                key_Bin.Append(Bit);
            }

            int key_Decimal = Convert.ToInt32(key_Bin.ToString(), 2); // Converting the Bin_key to Dec_key

            return key_Decimal;

        }

    }
}


