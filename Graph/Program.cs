// See https://aka.ms/new-console-template for more information
using Graph;
using Graph.Problems;

// var result = EulerianCycle.check_if_eulerian_cycle_exists(5,[[0, 1],
// [0, 2],
// [1, 3],
// [3, 0],
// [3, 2],
// [4, 3],
// [4, 0]]);
// var result = EulerianPath.check_if_eulerian_path_exists(4, [[0, 1],
// [1, 2],
// [1, 3],
// [2, 0],
// [3, 2]
// ]);
// Console.WriteLine(result);
// var result = ConvertEdgeListToAdjacencyList.convert_edge_list_to_adjacency_list(5,[
// [0, 1],
// [1, 4],
// [1, 2],
// [1, 3],
// [3, 4]
// ]);
// var result = ConvertEdgeListToAdjacencyMatrix.convert_edge_list_to_adjacency_matrix(5,[
// [0, 1],
// [1, 4],
// [1, 2],
// [1, 3],
// [3, 4]
// ]);
// var result = BFSGraph.bfs_traversal(6, [
// [0, 1],
// [0, 2],
// [0, 4],
// [2, 3]
// ]);
// foreach (var edge in result)
// {
//     Console.WriteLine(string.Join(",", edge));
// }
//Console.WriteLine(GraphIsValidTree.is_it_a_tree(4,[0,0,0],[1,2,3]));
// var result = new Bipartite().IsBipartite([[1,3],[0,2],[1,3],[0,2]]);
// Console.WriteLine(result);
// var result = NumberOfIslands.NumIslands([['1','1','1','1','0'],
//   ['1','1','0','1','0'],
//   ['1','1','0','0','0'],
//   ['0','0','0','0','0']]);
//   Console.WriteLine(result);

// var result = GraphIsValidTree.is_it_a_tree_v2(4, [0, 0, 0],[1, 2, 3]);
// Console.WriteLine(result);

// var result = NumberOfIslands.count_islands([
// [1, 1, 0, 0, 0],
// [0, 1, 0, 0, 1],
// [1, 0, 0, 1, 1],
// [0, 0, 0, 0, 0],
// [1, 0, 1, 0, 1]
// ]);
// Console.WriteLine(result);

// var result = FindLargestIsland.max_island_size([
// [1, 1, 0],
// [1, 1, 0],
// [0, 0, 1]
// ]);
// Console.WriteLine(result);

// var result = SnakeAndLadder.minimum_number_of_rolls_v2(19,
// [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 3, -1, 3, -1, -1, -1, -1, -1, -1]);
// Console.WriteLine(result);

var result = CourseSchedule2.FindOrder(4,[[1,0],[2,0],[3,1],[3,2]]);
foreach (var item in result)
{
  Console.Write(string.Join(",", item));
}
