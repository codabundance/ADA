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
            return 1; // because we are going back from leaf, but we have already covered one edge.
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

     // There can be 2 scenarios for longest path between 2 nodes
     // a. Longest path does not pass throgh root - exists in the same subtree of root i.e either left or right
     //     In this case we will need to find the diameter for each child node of the roo and keep a track of diameter
     //     If the diameter of any child node is greater than existing diameter then replace it.
     // b. Longest path passes through the root.
     //     In this case we will have to add the number of edges in longest path in left subtree and number of edges in the longest path
     //     in right subtree
     //     So at each node we will have to find whether the left subtree is larger or right subtree is larger
     //     We will need to return the larger of the 2. At the same time, we would also need to add 1 when we return back from this node
     //     because we will go to the parent and so we will add the edge connecting the child node to parent as well.
     //     Finally at the root we will simply add the length coming from left and length coming from right.

     // We are combining the above 2 conditions in below code.
    public static int binary_tree_diameter(BinaryTreeNode root) {
        // Write your code here.
        int diameter = 0;
        if(root == null)
            return 0;
        Diameter(root,ref diameter);
        return diameter;
    }
    
    private static int Diameter(BinaryTreeNode node, ref int diameter)
    {
        if(node.left == null && node.right == null)
            return 1;
        int diamL = 0;
        int diamR = 0;
        if(node.left != null)
            diamL = Diameter(node.left, ref diameter);
        if(node.right != null)
            diamR = Diameter(node.right, ref diameter);
        diameter = Math.Max(diameter, diamL+diamR); //condition a - when the longest path does not pass through root
        return Math.Max(diamL, diamR) + 1; // condition b - when longest path passes through root.
    }

}
