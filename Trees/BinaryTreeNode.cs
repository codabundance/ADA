

using System;

namespace Trees;

public class BinaryTreeNode {
    public int value;
    public BinaryTreeNode left;
    public BinaryTreeNode right;

    public BinaryTreeNode(int value) {
        this.value = value;
        this.left = null;
        this.right = null;
    }
}
