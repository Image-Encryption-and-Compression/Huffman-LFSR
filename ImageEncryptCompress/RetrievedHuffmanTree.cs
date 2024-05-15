using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RetrievedHuffmanTree
{
    private HuffmanNode root;
    private Dictionary<string, byte> originalCodes;
    public RetrievedHuffmanTree()
    {
        root = null;
        originalCodes = new Dictionary<string, byte>();
    }

    /// <summary>
    /// Interface to use the BuildTreeFromFile(HuffmanNode node, BinaryReader reader) function
    /// </summary>
    /// <param name="reader"></param>
    public void BuildTreeFromFile(ref BinaryReader reader)
    {
        root = ConstructTree(ref reader);
    }

    /// <summary>
    /// Reads and re-constructs the HuffmanTree from the binary file
    /// </summary>
    /// <param name="node">The current HuffmanNode to be read</param>
    /// <param name="reader">The BinaryReader object used to read data from the binary file</param>
    /// <returns>The root of the RetrivedHuffmanTree</returns>
    private HuffmanNode ConstructTree(ref BinaryReader reader)
    {
        //0: internal node
        //1: child node
        //2: end of tree

        byte nodeType = reader.ReadByte();
        if (nodeType == 2)
            return new HuffmanNode(0, 0);

        if (nodeType == 0)
        {
            //build sub-trees
            HuffmanNode leftChild = ConstructTree(ref reader);
            HuffmanNode rightChild = ConstructTree(ref reader);
            return new HuffmanNode(Constants.INTERNAL_NODE, leftChild, rightChild);
        }
        //frquency doesn't matter here. We already used it in building it for the first time
        return new HuffmanNode(reader.ReadByte(), 0);
    }

    private void BuildOriginalCodes()
    {
        // I am storing the Huffman code as a string since each node has a new Huffman code
        // They can't share the same StringBuilder, using StringBuilder here isn't suitable
        // HuffmanNode, HuffmanCode when reached this node
        Queue<KeyValuePair<HuffmanNode, string>> queue = new Queue<KeyValuePair<HuffmanNode, string>>();

        queue.Enqueue(new KeyValuePair<HuffmanNode, string>(root, ""));

        HuffmanNode currentNode;
        string currentHuffmanCode;

        while (queue.Count != 0)
        {
            currentNode = queue.Peek().Key;
            currentHuffmanCode = queue.Peek().Value;

            queue.Dequeue();

            // This is because in the Huffman tree if a node has a left child, then it for sure has a right child
            if (currentNode.leftChild != null)
            {
                queue.Enqueue(new KeyValuePair<HuffmanNode, string>(currentNode.leftChild, currentHuffmanCode + '0'));
                queue.Enqueue(new KeyValuePair<HuffmanNode, string>(currentNode.rightChild, currentHuffmanCode + '1'));
            }
            else
            {
                originalCodes[currentHuffmanCode] = currentNode.data;
            }
        }
    }
}
