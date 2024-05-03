using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class HuffmanTree
{
    internal class Node
    {

    }
    const int VALUES_LIMIT = 256;
    BitArray[] compressedCodes;
    Color channelColor;
    private Node root;
    int[] histogram;

    public HuffmanTree(int[] channelFrequency, Color channelColor)
    {
        channelFrequency.CopyTo(histogram, 0);
        this.channelColor = channelColor;

        BuildHuffmanTree();
    }
    public void BuildHuffmanTree()
    {

    }
}