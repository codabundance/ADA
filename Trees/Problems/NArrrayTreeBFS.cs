using System;

namespace Trees;

public class NArrrayTreeBFS
{
    public IList<IList<int>> LevelOrder(Node root) {
        if(root == null)
            return [];
        Queue<Node> q = new();
        IList<IList<int>> result = [];
        q.Enqueue(root);
        while(q.Count > 0)
        {
            IList<int> slate = [];
            int Counter = q.Count;
            for(int i=0; i< Counter; i++)
            {
                var node = q.Dequeue();
                slate.Add(node.val);
                foreach(var child in node.children)
                    q.Enqueue(child);
            }
            result.Add(slate);
        }
        return result;
    }
}
