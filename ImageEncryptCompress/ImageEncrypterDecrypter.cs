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
        /// create a copy of the image to avoid ruin the original image
        /// </summary>
        /// <param name="imageMatrix">the original image</param>
        /// <returns>a copy of the original image</returns>
        private RGBPixel[,] CopyMatrix(RGBPixel[,] imageMatrix)
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
            RGBPixel[,] copiedImage = CopyMatrix(imageMatrix);
            /* 
            LFSR passwordGenerator = new LFSR(seed, tapPosition);
            int numberOfBits = 8;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    copiedImage[i,j].red   = copiedImage[i,j].red   ^ (byte)passwordGenerator.GeneratKey(numberOfBits);
                    copiedImage[i,j].green = copiedImage[i,j].green ^ (byte)passwordGenerator.GeneratKey(numberOfBits);
                    copiedImage[i,j].blue  = copiedImage[i,j].blue  ^ (byte)passwordGenerator.GeneratKey(numberOfBits);
                }
            }
            */
            return encryptedImage;
        }
    }
}
