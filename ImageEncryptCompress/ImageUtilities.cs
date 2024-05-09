using ImageEncryptCompress;

public class ImageUtilities
{
    /// <summary>
    /// Gets the frequency of each color value in a specified channel of an image.
    /// </summary>
    /// <param name="image">The 2D array of RGBPixel representing the image.</param>
    /// <param name="channel">The color channel to analyze (Red, Green, or Blue).</param>
    /// <returns>An integer array of size 256, where each index represents a color value and the value at that index 
    /// represents the frequency of that color in the specified channel.</returns>
    static public int[] GetColorChannelFrequency(RGBPixel[,] image, Color channel)
    {
        int[] colorFrequency = new int[256];
        int height = image.GetLength(0);
        int width = image.GetLength(1);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int colorValue = 0;
                switch (channel)
                {
                    case Color.RED:
                        {
                            colorValue = image[i, j].red;
                            break;
                        }
                    case Color.GREEN:
                        {
                            colorValue = image[i, j].green;
                            break;
                        }
                    case Color.BLUE:
                        {
                            colorValue = image[i, j].blue;
                            break;
                        }

                }
                colorFrequency[colorValue]++;
            }
        }
        return colorFrequency;
    }
}
