
using ImageEncryptCompress;
using System;
using System.IO;
using System.Text;

public class HuffmanCoding
{

    private static HuffmanTree red;
    private static HuffmanTree green;
    private static HuffmanTree blue;
    public static void CompressImage(RGBPixel[,] image, ref BinaryWriter writer)
    {
        /*
        File structure:
            seed (int32) tapPosition(byte)
            Red Channel Tree
            Green Channel Tree
            Blue Channel Tree
            {EOH = 3}
            image[0,0].red image[0,0].green image[0,0].blue image[0,1].red...
            .
            .
            .
        ------------------------------------------------------------------------
        Tree strucutre in the file:
            - pre-order traversal
            - 0: internal node, 1: leaf node, 2: end of the tree
            - All bytes
            - End it with 2
        ------------------------------------------------------------------------
        Image structure in the file:
            - Concating each 8 bits into one byte
            - All strings
        */
        red = new HuffmanTree(ImageUtilities.GetColorChannelFrequency(image, Color.RED));
        green = new HuffmanTree(ImageUtilities.GetColorChannelFrequency(image, Color.GREEN));
        blue = new HuffmanTree(ImageUtilities.GetColorChannelFrequency(image, Color.BLUE));

        red.WriteTreeToFile(ref writer);
        writer.Write((byte)2); //indicating end of the red HuffmanTree

        green.WriteTreeToFile(ref writer);
        writer.Write((byte)2); //indicating end of the green HuffmanTree

        blue.WriteTreeToFile(ref writer);
        writer.Write((byte)3); //indicating end of the Header

        WriteImageToFile(image, ref writer);
    }
    private static void WriteImageToFile(RGBPixel[,] image, ref BinaryWriter writer)
    {
        int height = image.GetLength(0);
        int width = image.GetLength(1);
        StringBuilder currentByte = new StringBuilder();
        StringBuilder currentPixel = new StringBuilder();

        double cnt = 0;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //concate each 8 bits in one byte
                currentPixel.Append(red.GetCode(image[i, j].red));
                currentPixel.Append(green.GetCode(image[i, j].green));
                currentPixel.Append(blue.GetCode(image[i, j].blue));
                var res = currentPixel.ToString();
                foreach (var d in res)
                {
                    currentByte.Append(d);
                    if (currentByte.Length == 8)
                    {
                        cnt++;
                        writer.Write(Convert.ToByte(currentByte.ToString(), 2));
                        currentByte.Clear();
                    }
                }
                currentPixel.Clear();
            }
        }
        if (currentByte.Length != 0)
        {
            cnt++;
            writer.Write(Convert.ToByte(currentByte.ToString(), 2));
            currentByte.Clear();
        }
        double total = Math.Round(height * width * 3.0 / 1024.0);
        Console.WriteLine("Compression Output {0}{1}", cnt, " Bytes");

        cnt = Math.Round(cnt / 1024);
        Console.WriteLine("Compression Ratio {0}", cnt / total);
    }
}