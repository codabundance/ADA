using System;

namespace Trees.Problems;
/*
Given the root of a binary tree, return the length of the diameter of the tree.

The diameter of a binary tree is the length of the longest path between any two nodes in a tree. T
his path may or may not pass through the root.

The length of a path between two nodes is represented by the number of edges between them.
*/
public class BinaryTreeDiameter
{
    private int diameter=0;// dont make it static
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        if(root == null)
            return 0;
        SubTreeHeight(root);
        return diameter;
    }
    private int SubTreeHeight(TreeNode node)
    {
        // Basically the approach is to find the sum of the left and right subtree at each node
        // if the Sum is greater than diameter then the diameter becomes the new sum
        // At each node we will not return the diameter, but the height of the larger subtree from left and right
        // we return 1 in base case because the leaf node will have height 1.
        if(node.left == null && node.right == null)
            return 1;
        int leftHeight=0;
        int rightHeight=0;
        if(node.left != null)
            leftHeight = SubTreeHeight(node.left);
        if(node.right != null)
            rightHeight = SubTreeHeight(node.right);
        diameter = Math.Max(diameter, leftHeight+rightHeight);
        // We add 1 because with each return, we are coming back to parent node, so the edge between parent and child should be added
        // As diameter is defined by edges only and not nodes.
        return Math.Max(leftHeight, rightHeight)+1;
    }

    private int SubTreeHeightV2(TreeNode node)
    {
        //We could have used this approach as well, where we would check the node only as null instead of left or right
        // If the node is null that means we have tried to reach either left or right of leaf node (both will be null)
        // In botht the cases height will be 0.
        if(node == null)
            return 0;
        int leftHeight;
        int rightHeight;
        leftHeight = SubTreeHeightV2(node.left);
        rightHeight = SubTreeHeightV2(node.right);
        diameter = Math.Max(diameter, leftHeight+rightHeight);
        return Math.Max(leftHeight, rightHeight)+1;
    }
}
