using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageEncryptCompress;

/// <summary>
/// Calculates the frequency of each color value in a specified channel of an image.
/// </summary>
/// <param name="image"> A 2D array of RGBPixel objects representing the image.</param>
/// <param name="channel"> An integer indicating the channel to calculate the frequency for:
///   - 0: Blue channel
///   - 1: Green channel
///   - 2: Red channel
/// </param>
/// <returns>
/// An integer array of size 255 where the index represents the color value (0-255)
/// and the value at that index represents the frequency of that color value in the
/// specified channel.
/// </returns>
public class ImageUtilities
{
    public int[] GetColorChannelFrequency(RGBPixel[,] image, int channel)
    {
        int[] colorFrequency = new int[256];
        for (int i = 0; i < image.GetLength(0); i++)
        {
            for (int j = 0; j < image.GetLength(1); j++)
            {
                int colorValue = 0;
                switch (channel)
                {
                    case 0:
                        {
                            colorValue = image[i, j].blue;
                            break;
                        }
                    case 1:
                        {
                            colorValue = image[i, j].green;
                            break;
                        }
                    case 2:
                        {
                            colorValue = image[i, j].red;
                            break;
                        }
                }
                colorFrequency[colorValue]++;
            }
        }
        return colorFrequency;
    }
}

