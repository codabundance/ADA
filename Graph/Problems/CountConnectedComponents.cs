using System;

namespace Graph.Problems;
/*
Given an undirected graph, find its total number of connected components.
{
"n": 5,
"edges": [[0 ,1], [1, 2], [0, 2], [3, 4]]
}
Output:
2
*/
public class CountConnectedComponents
{
    public static int number_of_connected_components(int n, List<List<int>> edges) {
        // Write your code here.
        // Step 1: Build the graph and adjacency List
        List<int> result = new List<int>();
        List<int>[] adjList = new List<int>[n];
        int componentCounter = 0;
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
        //Step 3: Outer Loop
        for(int i=0; i< n; i++)
        {
            if(!visited[i])
            {
                // Eveytime a DFS is launched we know that there is one more connected component.
                // Because if we would have only 1 connected component, all nodes would have been visited in single DFS
                // We coould also have used DFS instead of BFS here.
                componentCounter++;
                // Step 2: DFS/BFS
                DFS(i,adjList,visited);
            }
        }
        return componentCounter;
    }
    private static void DFS(int i, List<int>[] adJacencyList, bool[] visited)
    {
        visited[i] = true;
        foreach(var vertex in adJacencyList[i])
        {
            if(!visited[vertex])
            {
                DFS(vertex, adJacencyList, visited);
            }
        }
    }
}
