using System;

namespace Trees;

public class BFS
{
    public static List<List<int>> Level_order_traversal(BinaryTreeNode root) {
        // Write your code here.
        if(root == null)
            return [];
        Queue<BinaryTreeNode> q = new();
        List<List<int>> result = [];
        q.Enqueue(root);
        while(q.Count > 0)
        {
            List<int> slate = [];
            //Everytime the while loop continues, only elements at a specific level will be remaining
            // 1st iteration - {root}
            // 2nd iteration - {root->left, root->right}
            // So we can run a loop till Queue size and add them to slate so that all the nodes at a given
            // level get added.

            // We will add root to the queue before entering the loop
            // Once we inter the loop in first iteration, we add next level nodes because we are adding childs of the root
            // In second iteration of while we add child of previously added nodes i,.e 3rd level
            // So you can see that the Counter variable will always give the count of nodes at each level with each iteration. 
            int Counter = q.Count;
            for(int i=0; i< Counter; i++)
            {
                var node = q.Dequeue();
                slate.Add(node.value);
                if(node.left != null)
                    q.Enqueue(node.left);
                if(node.right != null)
                    q.Enqueue(node.right);
            }
            result.Add(slate);
        }
        result.Reverse();
        return result;
    }
}
