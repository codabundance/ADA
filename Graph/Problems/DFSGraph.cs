using System;
using System.Xml.XPath;

namespace Graph.Problems;
/*
Given an undirected graph, perform a Depth-First Search Traversal on it.
{
"n": 6,
"edges": [
[0, 1],
[0, 2],
[1, 4],
[3, 5]
]
}
Output:

[0, 1, 4, 2, 3, 5]
*/
public class DFSGraph
{
    public static List<int> dfs_traversal(int n, List<List<int>> edges) 
    {
        // Write your code here.
        // Prepare Adjcency List for each vertex going through edges
        List<int> result = new List<int>();
        List<int>[] adjList = new List<int>[n];
        for (int j = 0; j< n; j++)
        {
            adjList[j] = new List<int>();
        }
        foreach(var edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);//Duplicates not allowed so this works in O(n)
            adjList[edge[1]].Add(edge[0]); // Undirected Graph so add both as adjacent of each other.
        }
        bool[] visited = new bool[n];
        //Do DFS
        // Why do we use a loop to add i instead of adding 1st element?
        // Because the graph can have multiple connected components, but not all vertices cana be visited at once
        // So we would need to check from each vertex in the graph.
        // Consider an example when none of the vertices are connected. In DFS we woould need to visit each node separately
        // This for loop takes care of that
        // In case we have connected vertices DFS will be taken care by adjacency list and since we are using visited, once added using
        // adjacency list that vertex will not be added in the for loop, so no problem in iterating over each vertex in graph.
        // In this way we are covering each node to add either through adjacency list or through the iterative loop, but not adding duplicates
        // because of Visited array.
        for(int i =0; i< n; i++)
        {
            if(!visited[i])
                result.Add(i);
            DFS(i, adjList, visited, result);
        }
        return result;
    }

    private static void DFS(int i, List<int>[] adJacencyList, bool[] visited, List<int> result)
    {
        visited[i] = true;
        foreach(var vertex in adJacencyList[i])
        {
            if(!visited[vertex])
            {
                result.Add(vertex);
                DFS(vertex, adJacencyList, visited, result);
            }
        }
    }
}
