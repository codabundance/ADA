// See https://aka.ms/new-console-template for more information
using Trees;
/*

"root": [2,
5, 4,
0, 1, 3, 6]
}
*/
BinaryTreeNode root = new(2)
{
    left = new BinaryTreeNode(5),
    right = new BinaryTreeNode(4)
};
root.left.left = new BinaryTreeNode(0);
root.left.right = new BinaryTreeNode(1);
root.right.left = new BinaryTreeNode(3);
root.right.right = new BinaryTreeNode(6);

BFS.Level_order_traversal(root);