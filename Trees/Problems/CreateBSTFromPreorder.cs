using System;
using System.ComponentModel;

namespace Trees.Problems;
/*
Construct a Binary Search Tree whose preorder traversal matches the given list.

Example One
{
"preorder": [1, 0, 2]
}
Example Two
{
"preorder": [2, 0, 1, 3, 5, 4]
}
*/
// Approach : Can we not sort the given preorder array and get the inorder array and then
// from inorder we can create the BST??
// This would work only if we have to create a height balanced tree. There will be a unique height balanced
// tree formed from inorder traversal. But, there can be other trees as well which are not height balanced.
// So this approach will not work in this Qs as it does not ask you to create height balanced tree.
// We will have to use both the preorder and  inorder information to create the unique tree, we cannot just rely on inorder to form
// the unique tree.
public class CreateBSTFromPreorder
{
    public static BinaryTreeNode build_binary_search_tree(List<int> preorder) 
    {
        // Write your code here.
        var inorder = new List<int>(preorder);
        inorder.Sort();
        return CreateTree(inorder,preorder,0,inorder.Count -1,0,preorder.Count -1);
    }
    private static BinaryTreeNode CreateTree(List<int> inorder, List<int> preorder, int startI, int endI, int startP, int endP)
    {
        if(startI == endI)
            return new BinaryTreeNode(inorder[startI]);
        if(startI > endI)
            return null;
        // find index of the first element of the preorder (which would be root of subtree) in inorder tree.
        // We cannot go with the "mid" approach because that will create a height balanced tree
        // we have to find the root for each subtree - the root of each subtree would be the start index of the preorder for that subtree
        // so we pick the first element of the preorder array for each subtree and search it in the inorder array.
        // How do we create the perorder sub array from the preorder array - we can extract those many elements from the preorder array
        // as are present in the left subtree of inorder tree.
        // if we get the index of oreorderIndex, we know that the left indices to this in inorder tree are part of left subtree
        // and indices right to this index are part of right subtree
        // Thus we can create the left and right subtree from preorder array using this information.
        int preorderIndex = inorder.FindIndex(x => x == preorder[startP]);
        int leftSubtreeSize = preorderIndex - startI;
        BinaryTreeNode node = new(inorder[preorderIndex])
        {
            // left subtree in preorder array is given by startP+1 and startP+ leftSubtreeSize(inorder)
            left = CreateTree(inorder, preorder, startI, preorderIndex - 1, startP + 1, startP + leftSubtreeSize),
            // right subtree in preorder array is given by startP+ leftsubtreesize(inorder) +1 and endP.
            right = CreateTree(inorder, preorder, preorderIndex + 1, endI, startP + leftSubtreeSize + 1, endP)
        };
        return node;
    }
}
