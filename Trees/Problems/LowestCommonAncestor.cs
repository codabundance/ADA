using System;

namespace Trees;
/*
Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
The LCA of nodes a and b in a tree is defined as the shared ancestor node of a and b that is located farthest from the root of the tree.
*/
/*
Approach 1: 
We can trace the path to both the nodes from the root and store the 2 path nodes in
2 arrays. Then we do a iteration of both the arrays and the common node in both gives LCA.
This is O(n) Time and O(2n) Space complexity.

Approach 2:
We do a DFS of the Graph, and if we find either of the 2 nodes we return the value. There can
be 2 cases
1. The DFS will return both node values - return the current node
2. The DFS will return either of 2 nodes - That node will be the LCA.

Let's assume the node to be searched are p,q

While doing DFS, 
if P is not ancestor of Q or viceversa then either P or Q is found in any Path then that 
path will return whatever is found. And whatever node will have both values of P & Q
That becomes LCA.

If P is already an ancestor of Q or vice versa then only the ancestor will be returned.
In this case LCA is the ancestor

If neither P or Q is found then NULL is returned


*/
public class LowestCommonAncestor
{
    public static int lca(BinaryTreeNode root, BinaryTreeNode a, BinaryTreeNode b) {
        // Write your code here.
        if (root == null)
            return 0;
        return Helper(root, a, b);
    }

    private static int Helper(BinaryTreeNode node, BinaryTreeNode a, BinaryTreeNode b)
    {
        if(node == null)
           return 0;
        if(node.value == a.value || node.value == b.value)
            return node.value;
        int left = Helper(node.left, a, b);
        int right = Helper(node.right, a,b);
        if(left != 0 && right != 0)
            return node.value;
        if(left != 0)
           return left;
        return right;
    }
}
