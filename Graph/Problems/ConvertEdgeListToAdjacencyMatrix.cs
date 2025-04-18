using System;

namespace Graph.Problems;
/*
Convert the given edge list to the adjacency matrix of an undirected connected graph.
The adjacency matrix is a matrix with rows and columns labeled by graph vertices, with a 1 or 0 in position (u, v) according to whether vertices u and v are adjacent or not.

Example
{
"n": 5,
"edges": [
[0, 1],
[1, 4],
[1, 2],
[1, 3],
[3, 4]
]
}
Output:

[
[0, 1, 0, 0, 0],
[1, 0, 1, 1, 1],
[0, 1, 0, 0, 0],
[0, 1, 0, 0, 1],
[0, 1, 0, 1, 0]
]
*/
public class ConvertEdgeListToAdjacencyMatrix
{
    public static List<List<bool>> convert_edge_list_to_adjacency_matrix(int n, List<List<int>> edges) 
    {
        List<List<bool>> result = new();
        for(int i=0; i<n; i++)
        {
            bool[] edge_matrix = new bool[n];
            foreach(var edge in edges)
            {
                if(i == edge[0])
                    edge_matrix[edge[1]] = true;
                else if(i == edge[1])
                    edge_matrix[edge[0]] = true;
            }
            result.Add(edge_matrix.ToList());
        }
        return result;
    }
}
