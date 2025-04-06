using System;

namespace Trees;

public class Node(int _val, IList<Node> _children)
{
    public int val = _val;
    public IList<Node> children = _children;
}
