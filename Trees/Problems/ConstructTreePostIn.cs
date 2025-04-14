using System;

namespace Trees.Problems;

public class ConstructTreePostIn
{
    private Dictionary<int, int> hash = new Dictionary<int, int>();
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        for(int i = 0; i< inorder.Length; i++)
            hash.Add(inorder[i],i);
        return Helper(postorder.ToList(),0,postorder.Length - 1, inorder.ToList(),0,inorder.Length - 1);
    }

    private TreeNode Helper(List<int> postorder, int startP, int endP, List<int> inorder, int startI, int endI)
    {
        if(startP > endP) // Empty preorder and because both P and I will be on same size it also means empty inorder
            return null;
        if(startP == endP) // Single element Preorderand because both P and I will be on same size it also means single element inorder
            return new TreeNode(postorder[startP]);
        //Recursion
        TreeNode root = new(postorder[endP]);
        int rootIndex = hash[postorder[endP]];
        int numright = endI - rootIndex;
        root.left = Helper(postorder, startP, endP - numright -1 ,inorder,startI, rootIndex - 1);
        root.right = Helper(postorder,endP - numright+1,endP-1,inorder,rootIndex+1, endI);
        return root;
    }
}
