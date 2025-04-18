using System;

namespace Graph.Problems;
/*
Convert the given edge list to the adjacency list of an undirected connected graph.
An adjacency list represents a graph as a list of lists. The list index represents a vertex, and each element in its inner list represents the other vertices that form an edge with the vertex.

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
[1],
[0, 2, 3, 4],
[1],
[1, 4],
[1, 3]
]
*/
public class ConvertEdgeListToAdjacencyList
{
    public static List<List<int>> convert_edge_list_to_adjacency_list(int n, List<List<int>> edges) {
        // Write your code here.
        List<List<int>> result = new List<List<int>>(n);
        for(int i=0; i<n; i++)
        {
            List<int> edge_list = new();
            foreach(var edge in edges)
            {
                if(i == edge[0])
                    edge_list.Add(edge[1]);
                else if(i == edge[1])
                    edge_list.Add(edge[0]);
            }
            edge_list.Sort();
            result.Add(edge_list);
        }
        return result;
    }

}
