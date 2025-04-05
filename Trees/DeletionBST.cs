using System;

namespace Trees;

public class DeletionBST
{
    public static BinaryTreeNode Delete_from_bst(BinaryTreeNode root, List<int> values_to_be_deleted) {
        BinaryTreeNode result = null;
        if(root == null)
            return root;
        foreach(int val in values_to_be_deleted)
        {
            result = find_and_delete_node(root,val);
        }
        return result;
    }
    
    private static BinaryTreeNode find_and_delete_node(BinaryTreeNode root, int x)
    {
        BinaryTreeNode curr = root;
        BinaryTreeNode prev = null;
        // find the node
        while(curr != null)
        {
            if(curr.value == x)
                break;
            prev = curr;
            if(curr.value < x)
                curr = curr.left;
            else if(curr.value > x)
                curr = curr.right;
        }
        if(curr == null)
            return root;
        //loop breaks with current having some value or null
        // case 1: the node does not have any child
        if(curr.left == null && curr.right == null)
        {
            if(prev == null)
                return null;
            if(prev.left == curr)
                prev.left = null;
            else if(prev.right == curr)
                prev.right = null;
        }
        //case 2: The node has one child
        BinaryTreeNode child;
        if(curr.left == null && curr.right != null)
            child = curr.right;
        else if(curr.left != null && curr.right == null)
            child = curr.left;
        if(prev == null)
            return null;
        if(prev.left == curr)
            prev.left = curr.right;
        else if(prev.right == curr)
            prev.right = curr.right;
            
        //case 3: The node has right as well as left child
        if(curr.left != null && curr.right != null)
        {
            // find successor of current, smallest element in the right subtree
            BinaryTreeNode succ = curr.right;
            BinaryTreeNode previous = curr;
            while(succ.left != null)
            {
                previous = succ;
                succ = succ.left;
            }
            // replace the key of current with key of succ and delete succ physically
            // succ cannot have a left node so it falls under case 2 with only right node
            // So previous can be pointed to succ -> right and deletion works
            curr.value = succ.value;
            if(previous.left == succ)
                previous.left = succ.right;
            else if(previous.right == succ)
                previous.right = succ.right;
        }
        return root;
    }

}
