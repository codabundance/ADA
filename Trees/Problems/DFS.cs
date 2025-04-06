using System;

namespace Trees;

public class DFS
{
    public static void InvokeDfs(BinaryTreeNode root)
    {
        List<int> result;
        result = [];
        InOrderTraversal(root, result);
        Console.WriteLine(string.Join(",", result));
        result = [];
        PostOrderTraversal(root,result);
        Console.WriteLine(string.Join(",", result));
        result = [];
        PreOrderTraversal(root,result);
        Console.WriteLine(string.Join(",", result));
    }
    private static void InOrderTraversal(BinaryTreeNode node, List<int> result)
    {
        if(node == null)
            return;
        if(node.left != null)
            InOrderTraversal(node.left, result);
        result.Add(node.value);
        if(node.right != null)
            InOrderTraversal(node.right, result);
    }
    private static void PreOrderTraversal(BinaryTreeNode node, List<int> result)
    {
        if(node == null)
            return;
        result.Add(node.value);
        if(node.left != null)
            PreOrderTraversal(node.left, result);
        if(node.right != null)
            PreOrderTraversal(node.right, result);
    }
    private static void PostOrderTraversal(BinaryTreeNode node, List<int> result)
    {
        if(node == null)
            return;
        if(node.left != null)
            PostOrderTraversal(node.left, result);
        if(node.right != null)
            PostOrderTraversal(node.right, result);
        result.Add(node.value);
    }

}
