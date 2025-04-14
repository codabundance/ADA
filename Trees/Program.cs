// See https://aka.ms/new-console-template for more information
using Trees;
using Trees.Problems;
/*

"root": [2,
5, 4,
0, 1, 3, 6]
}
*/
// BinaryTreeNode root = new(4)
// {
//     left = new BinaryTreeNode(2),
//     right = new BinaryTreeNode(6)
// };
// root.left.left = new BinaryTreeNode(1);
// root.left.right = new BinaryTreeNode(3);
// root.right.left = new BinaryTreeNode(5);
// root.right.right = new BinaryTreeNode(7);

// List<int> valuesTobeDeleted = [5,6];
// DeletionBST.Delete_from_bst(root, valuesTobeDeleted);
//BFS.Level_order_traversal(root);

//ConvertSortedArrayToBST.SortedArrayToBST([-10,-3,0,5,9]);
var result = new ConstructTreePostIn().BuildTree([3,9,20,15,7],[9,3,15,20,7]);
