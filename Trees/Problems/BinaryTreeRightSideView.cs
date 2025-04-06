using System;

namespace Trees;

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
