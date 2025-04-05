// See https://aka.ms/new-console-template for more information
using Trees;
/*

"root": [2,
5, 4,
0, 1, 3, 6]
}
*/
BinaryTreeNode root = new(4)
{
    left = new BinaryTreeNode(2),
    right = new BinaryTreeNode(6)
};
root.left.left = new BinaryTreeNode(1);
root.left.right = new BinaryTreeNode(3);
root.right.left = new BinaryTreeNode(5);
root.right.right = new BinaryTreeNode(7);

List<int> valuesTobeDeleted = [5,6];
DeletionBST.Delete_from_bst(root, valuesTobeDeleted);
//BFS.Level_order_traversal(root);