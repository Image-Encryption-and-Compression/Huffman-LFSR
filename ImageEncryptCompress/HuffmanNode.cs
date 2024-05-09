using System;

public class HuffmanNode : IComparable<HuffmanNode>
{
    public byte data;
    public int frequency;
    public HuffmanNode leftChild;
    public HuffmanNode rightChild;
    public HuffmanNode(byte data, HuffmanNode leftChild, HuffmanNode rightChild)
    {
        this.data = data;
        this.leftChild = leftChild;
        this.rightChild = rightChild;
        frequency = leftChild.frequency + rightChild.frequency;
    }
    public HuffmanNode(byte data, int frequency)
    {
        this.data = data;
        this.frequency = frequency;
    }
    public int CompareTo(HuffmanNode node)
    {
        return frequency - node.frequency;
    }
}