using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEncryptCompress
{
    public class ImageEncrypterDecrypter
    {
        private int width;
        private int height;

        /// <summary>
        /// creat a copy of the image to avoid ruin the original image
        /// </summary>
        /// <param name="imageMatrix">the original image</param>
        /// <returns>a copy of the original image</returns>
        public RGBPixel[,] CopyMatrix(RGBPixel[,] imageMatrix)
        {
            
            RGBPixel[,] ans = new RGBPixel[width,height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    ans[i,j] = imageMatrix[i,j];
                }
            }
            return ans;
        }

        /// <summary>
        /// Encrypt the image by creating a copy of the original image and apply lfsr on it
        /// </summary>
        /// <param name="imageMatrix">the orignal image</param>
        /// <param name="seed">the initial seed</param>
        /// <param name="tapPosition"></param>
        /// <returns>encrypted image</returns>
        public RGBPixel[,] EncryptDecrypt(RGBPixel[,] imageMatrix, string seed, int tapPosition)
        {
            width = ImageOperations.GetWidth(imageMatrix);
            height = ImageOperations.GetHeight(imageMatrix);

            RGBPixel[,] encryptedImage = new RGBPixel[width, height];
            RGBPixel[,] copyMatrix = CopyMatrix(imageMatrix);
            /* 
            LFSR passwordGenerator = new LFSR(seed, tapPosition);
            int numberOfBits = 8;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    copyMatrix[i,j].red   = copyMatrix[i,j].red   ^ (byte)passwordGenerator.generatKey(numberOfBits);
                    copyMatrix[i,j].green = copyMatrix[i,j].green ^ (byte)passwordGenerator.generatKey(numberOfBits);
                    copyMatrix[i,j].blue  = copyMatrix[i,j].blue  ^ (byte)passwordGenerator.generatKey(numberOfBits);
                }
            }
            */
            return encryptedImage;
        }
    }
}
