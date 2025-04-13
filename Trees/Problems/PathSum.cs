using System;
/*
Given the root of a binary tree and an integer targetSum, 
return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
*/
namespace Trees.Problems;

public class PathSum
{
    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root == null)
            return false;
        return Helper(root,targetSum,0);
    }    

    private static bool Helper(TreeNode node, int targetSum, int running_sum) 
    {
        // we need to use this condition to make sure that we have reached the leaf node and then check the running sum
        // If we dont use this condition, the return can happen from any node where the condition satisfies
        // And not necessarily path from roo to leaf.
        if(node.left == null && node.right == null)
        {
            //When we are at leaf node we have not added it's value yet to running sum. 
            //So, we check target sum by adding the value to running sum
            if(running_sum + node.val == targetSum)
                return true;
            else
                return false;
        }
        bool left = false; 
        bool right = false;
        if(node.left != null)
            left = Helper(node.left, targetSum,running_sum+node.val);
        if(!left && node.right != null)
            right = Helper(node.right, targetSum,running_sum+node.val);
        return left || right;
    }
    private static bool Helper1(TreeNode node, int targetSum, int running_sum) 
    {
        if(node == null)
        {
            if(running_sum == targetSum)
                return true;
            else
                return false;
        }
        bool right = false;
        bool left = Helper1(node.left, targetSum,running_sum+node.val);
        if(!left)
            right = Helper1(node.right, targetSum,running_sum+node.val);
        return left || right;
    }
}
