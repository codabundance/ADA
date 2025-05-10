using System;

namespace Trees.Problems;
/*
Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.
*/
public class ConvertSortedArrayToBST
{
    public static TreeNode SortedArrayToBST(int[] nums) 
    {
        TreeNode root = CreateSubTree(nums,0,nums.Length - 1);
        return root;
    }

    // As array is sorted, a balanced tree would be always having 2 nodes and difference in height less than 1.
    // We can only create a balanced tree, a non balanced tree cannot be created.
    // Approach: We keep dividing the array into 2 halves, and the mid point for each half becomes the root
    // The elements smaller than mid become part of left subtree, and elements larger than mid become part of right subtree
    // As the array is sorted - The elements left to mid become part of left subtree, and elements right to mid become part of right subtree
    private static TreeNode CreateSubTree(int[] nums, int start, int end)
    {
        if(start == end)// leaf node
        {
            return new TreeNode(nums[start]);
        }
        // when we have only a single element remaining in the array after partition in the array, then start =1, end = 1, mid = 1
        // so for line 30 we pass end as mid-1 = 0, start as 1
        // so for line 31 we pass start as mid+1 = 2,end = 1
        // In both the cases the start > end, and we dont want to add any node
        if(start > end)
            return null;
        int mid = (start + end)/2;
        TreeNode node = new(nums[mid]);
        // The above if condn at line 30 is to handle this subtree
        // Whene there are 2 elements in subtree at index 0 and index 1. When we do an integer division mid is also 0.
        // So now when we do a mid -1 then the end becomes -1 and start becomes 0
        // similarily for any other partitions with 2 elements this subtree will create issue
        // So we put a check if start > end to prevent it from entering an infinite loop.
        node.left = CreateSubTree(nums, start, mid-1);
        node.right = CreateSubTree(nums, mid+1,end);
        return node;
    }

    public static BinaryTreeNode sorted_list_to_bst(LinkedListNode head) {
        // Write your code here.
        List<int> nums = new();
        var node = head;
        while(node != null)
        {
            nums.Add(node.value);
            node = node.next;
        }
        return CreateTree(nums,0,nums.Count-1);
    }
    
    private static BinaryTreeNode CreateTree(List<int> nums, int start, int end)
    {
        if(start == end)//leaf node
        {
            BinaryTreeNode leaf = new BinaryTreeNode(nums[start]);
            return leaf;
        }
        if(start > end)
            return null;
        int mid = (start + end)/2;
        BinaryTreeNode node = new BinaryTreeNode(nums[mid]);
        node.left = CreateTree(nums, start, mid-1);
        node.right = CreateTree(nums, mid+1, end);
        return node;
    }
}
