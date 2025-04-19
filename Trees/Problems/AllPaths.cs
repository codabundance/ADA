using System;

namespace Trees.Problems;

public class AllPaths
{
    public static List<List<int>> all_paths_of_a_binary_tree(BinaryTreeNode root) {
        // Write your code here.
        List<List<int>> result = new List<List<int>>();
        if(root == null)
            return result;
        TreeHelper(root, result, new List<int>());
        return result;
    }

    private static void TreeHelper(BinaryTreeNode node, List<List<int>> result, List<int> current)
    {
        if(node.left == null && node.right == null)
        {
            current.Add(node.value);
            var copy = new List<int>(current);
            result.Add(copy);
            current.RemoveAt(current.Count - 1);
            return;
        }
        current.Add(node.value);
        if(node.left != null)
            TreeHelper(node.left, result, current);
        if(node.right != null)
            TreeHelper(node.right, result, current);
        current.RemoveAt(current.Count - 1);
    }
    private static void TreeHelper1(BinaryTreeNode node, List<List<int>> result, List<int> current)
    {
        if(node == null)// this will add the current 2 times so better to go with the above approach.
        {
            var copy = new List<int>(current);
            result.Add(copy);
            return;
        }
        current.Add(node.value);
        TreeHelper(node.left, result, current);
        TreeHelper(node.right, result, current);
        current.RemoveAt(current.Count - 1);
    }
}
