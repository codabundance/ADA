using System;

namespace Trees.Problems;

public class ConstructTreePreIn
{
    private Dictionary<int, int> hash = new Dictionary<int, int>();
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        for(int i = 0; i< inorder.Length; i++)
            hash.Add(inorder[i],i);
        return Helper(preorder.ToList(),0,preorder.Length - 1, inorder.ToList(),0,inorder.Length - 1);
    }

    private TreeNode Helper(List<int> preorder, int startP, int endP, List<int> inorder, int startI, int endI)
    {
        if(startP > endP) // Empty preorder and because both P and I will be on same size it also means empty inorder
            return null;
        if(startP == endP) // Single element Preorderand because both P and I will be on same size it also means single element inorder
            return new TreeNode(preorder[startP]);
        //Recursion
        TreeNode root = new(preorder[startP]);
        int rootIndex = hash[preorder[startP]];
        int numleft = rootIndex - startI;
        root.left = Helper(preorder, startP+1, startP+numleft,inorder,startI, rootIndex - 1);
        root.right = Helper(preorder,startP+numleft+1,endP,inorder,rootIndex+1, endI);
        return root;
    }

}
