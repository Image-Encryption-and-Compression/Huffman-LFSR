using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

public class HuffmanNode : IComparable<HuffmanNode>
{
    public int frequency;
    public int data;
    public HuffmanNode leftNode;
    public HuffmanNode rightNode;
    public HuffmanNode(HuffmanNode leftNode, HuffmanNode rightNode, int frequency, int data)
    {
        this.leftNode = leftNode;
        this.rightNode = rightNode;
        this.frequency = frequency;
        this.data = data;
    }
    public HuffmanNode(int frequency, int data)
    {
        this.frequency = frequency;
        this.data = data;
    }
        public int CompareTo(HuffmanNode node)
    {
        return node.frequency - frequency;
    }
}

