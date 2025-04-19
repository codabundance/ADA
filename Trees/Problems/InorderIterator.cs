using System;

namespace Trees.Problems;
/*
Design and implement an iterator for the in-order traversal of a binary tree.

Given the root node of a tree of positive numbers, and a sequence of operations on the iterator, calculate return values of all those operations.

Iterator has two operations:

has_next() should return 1 if one or more elements remain in the in-order traversal of the tree, otherwise it should return 0.
next() should return the next value in the in-order traversal of the tree if it exists, otherwise a special value of 0.
Execute operations one by one and return all their return values in a list.

Both operations must take constant time on average and use O(height of the tree) of extra memory.
[100,200,300]
"operations": ["next", "has_next", "next", "next", "has_next", "has_next", "next"]
Output:

[100, 1, 200, 300, 0, 0, 0]
*/
public class InorderIterator
{
    public static List<int> implement_tree_iterator(BinaryTreeNode root, List<string> operations) {
        // Write your code here.
        // First form an Inorder array by traversing the tree
        // Then for each operation check on the array.
        List<int> InorderArray = new List<int>();
        List<int> result = new List<int>();
        DFS(root, InorderArray);
        int counter = 0;
        foreach(string s in operations)
        {
            if(s =="has_next")
            {
                if(counter < InorderArray.Count)
                   result.Add(1);
                else
                    result.Add(0);
            }
            else if(s == "next")
            {
                if(counter < InorderArray.Count)
                {
                    result.Add(InorderArray[counter]);
                    counter++;
                }
                else
                    result.Add(0);
            }
        }
        return result;
    }

    private static void DFS(BinaryTreeNode node, List<int> InorderArray)
    {
        if(node.left == null && node.right == null)
        {
            InorderArray.Add(node.value);
            return;
        }
        if(node.left != null)
          DFS(node.left, InorderArray);
        InorderArray.Add(node.value);
        if(node.right != null)
          DFS(node.right, InorderArray);
    }
}
