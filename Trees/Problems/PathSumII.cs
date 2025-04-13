using System;

namespace Trees.Problems;
/*
Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values 
in the path equals targetSum. Each path should be returned as a list of the node values, not node references.
*/
public class PathSumII
{
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) 
    {
        if(root == null)
            return [];
        IList<IList<int>> result = [];
        Helper(root,targetSum,0,[],result);
        return result;
    }

    private static void Helper(TreeNode node, int targetSum, int runningSum, IList<int> currentPath, IList<IList<int>> result) 
    {
        if(node.left == null && node.right == null)
        {
            // We have not added the last node value, so we will add it to the current and once that becomes part of result
            // we also pop it from current before returning. So, current backtracks to last recursive call.
            if(runningSum + node.val == targetSum)
            {
                currentPath.Add(node.val);
                IList<int> copy = [.. currentPath];
                result.Add(copy);
                currentPath.RemoveAt(currentPath.Count - 1);
                return;
            }
            return;
        }
        currentPath.Add(node.val);
        if(node.left != null)
            Helper(node.left, targetSum, runningSum+node.val, currentPath, result);
        if(node.right != null)
            Helper(node.right, targetSum, runningSum+node.val, currentPath, result);
        currentPath.RemoveAt(currentPath.Count - 1);
    }

    private static void Helper1(TreeNode node, int targetSum, int runningSum, IList<int> currentPath, IList<IList<int>> result) 
    {
        if(node == null)
        {
            if(runningSum == targetSum)
            {
                IList<int> copy = [.. currentPath];
                result.Add(copy);
                return;
            }
            return;
        }
        currentPath.Add(node.val);
        Helper1(node.left, targetSum, runningSum+node.val, currentPath, result);
        Helper1(node.right, targetSum, runningSum+node.val, currentPath, result);
        currentPath.RemoveAt(currentPath.Count - 1);
    }
}
