using System;

namespace Trees;
/*
We cannot just add the right side child for each node, because in that case we will loose the entire left subtree
We need to go through each level and pick the right most node at each level and add it to result
so we follow the same approach and go level by level. Only that, this time, we will not add the entire nodes at a single level, but
only the right most node or last node in the level list - slate.
*/
public class BinaryTreeRightSideView
{
    public IList<int> RightSideView(BinaryTreeNode root) {
        if(root == null)
            return [];
        Queue<BinaryTreeNode> q = new();
        IList<int> result = [];
        q.Enqueue(root);
        while(q.Count > 0)
        {
            IList<int> slate = [];
            //Everytime the while lopp continues, only elements at a specific level will be remaining
            // 1st iteration - {root}
            // 2nd iteration - {root->left, root->right}
            // So we can run a loop till Queue size and add them to slate so that all the nodes at a given
            // level get added.
            int Counter = q.Count;
            for(int i=0; i< Counter; i++)
            {
                var node = q.Dequeue();
                slate.Add(node.value);
                //The order of addin left or right first is very important
                if(node.left != null)
                    q.Enqueue(node.left);
                if(node.right != null)
                    q.Enqueue(node.right);
            }
            result.Add(slate[slate.Count - 1]);
        }
        return result;
    }
}
