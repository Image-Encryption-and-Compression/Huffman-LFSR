using Priority_Queue;
using System.Collections.Generic;
using System.Text;

public class HuffmanTree
{
    private HuffmanNode root;
    private readonly int[] histogram;
    private StringBuilder[] CompressedCodes;
    public HuffmanTree(int[] histogram)
    {
        histogram.CopyTo(this.histogram, 0);
        CompressedCodes = new StringBuilder[Constants.MAX_VALUE];
    }

    /// <summary>
    /// Builds a Huffman tree for efficient data compression using a priority queue.
    /// </summary>
    public void BuildHuffmanTree()
    {
        SimplePriorityQueue<HuffmanNode, int> pq = new SimplePriorityQueue<HuffmanNode, int>();
        for (int i = 0; i < histogram.Length; i++)
        {
            pq.Enqueue(new HuffmanNode(i, histogram[i]), histogram[i]);
        }

        while (pq.Count > 1)
        {
            HuffmanNode leftNode = pq.First;
            pq.Dequeue();

            HuffmanNode rightNode = pq.First;
            pq.Dequeue();

            //MAX_VALUE to indicate to internal node: does not represent any value
            HuffmanNode parent = new HuffmanNode(Constants.MAX_VALUE, leftNode, rightNode);

            pq.Enqueue(parent, parent.frequency);
        }
        root = pq.First;
    }
}