using System;

public class HuffmanNode : IComparable<HuffmanNode>
{
    public int data;
    public int frequency;
    public HuffmanNode leftNode;
    public HuffmanNode rightNode;
    public HuffmanNode(int data, HuffmanNode leftNode, HuffmanNode rightNode)
    {
        this.data = data;
        this.leftNode = leftNode;
        this.rightNode = rightNode;
        this.frequency = leftNode.frequency + rightNode.frequency;


    }
    public HuffmanNode(int data, int frequency)
    {
        this.data = data;
        this.frequency = frequency;
    }
    public int CompareTo(HuffmanNode node)
    {
        return frequency - node.frequency;
    }
}






