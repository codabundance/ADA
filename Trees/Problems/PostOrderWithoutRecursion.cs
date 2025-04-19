using System;
using System.Transactions;
using System.Xml.XPath;

namespace Trees.Problems;
/*
Given a binary tree, find its post-order traversal without using recursion.
*/
// Approach : We are trying to add the current node's right and left in that order to Stack
        // Adding right child first because we need to visit left first so left should be on top of stack and before right for every node
        // Then we pop Stack and see if the popped element has left or right child
        // If no left or right child, then it is a leaf node, so add it to result and remove from Stack
        // If left or right child there, add these children to Stack in same order right then left.
        // We would also need to maintain a processed Hashmap, which keeps a track of nodes whose children has already been processed
        // Because once we pop the items from the Stack there is no way we can determine if the current element has already been taken care of
        // if element is taken care of we dont process it's children again, but just add the element to result.
public class PostOrderWithoutRecursion
{
    public static List<int> postorder_traversal(BinaryTreeNode root) 
    {
        // Write your code here.
        if(root == null) 
            return new List<int>();
        List<int> result = new List<int>();
        BinaryTreeNode node = root;
        List<BinaryTreeNode> Stack = new();
        Dictionary<BinaryTreeNode, bool> processed = new Dictionary<BinaryTreeNode, bool>();
        Stack.Add(node);
        while(Stack.Count > 0)
        {
            if(node.left == null && node.right == null || (processed.ContainsKey(node) && processed[node]))
            {
                result.Add(node.value);
                Stack.RemoveAt(Stack.Count -1);
            }
            else
            {
                if(node.right != null)
                    Stack.Add(node.right);
                if(node.left != null)
                    Stack.Add(node.left);
                processed[node] = true;
            }
            // To handle the last element removed in line 34
            if(Stack.Count > 0)
                node = Stack.Last();
        }
        return result;
    }
}
