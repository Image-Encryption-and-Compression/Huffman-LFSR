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
    private HuffmanNode leftNode;
    private HuffmanNode rightNode;
    public HuffmanNode(HuffmanNode leftNode, HuffmanNode rightNode, int frequency)
    {
        this.leftNode = leftNode;
        this.rightNode = rightNode;
        this.frequency = frequency;
    }
    public int CompareTo(HuffmanNode node)
    {
        return node.frequency - frequency;
    }
}

