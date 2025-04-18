using System;

namespace Graph.Problems;
/*
Given an undirected graph, perform a Breadth-First Search Traversal on it.
*/
// Approach: We create adjacency list of all the connected vertices. We maintain a visited array
// For each vertex starting from 0 we check if the current vertex has an adjacency List and if vertices in that list are visited or not
// if not visited we add them to Queue and proceed further to process the queue adding items from queue in result
// Once the Queue is empty, this means all the connected vertices have been processed in BFS
// For vertices not yet visited, they are not processed, so we run a loop from 0 to n and check in visited array of any index is unprocessed
// We add the unprocessed index to result.

public class BFSGraph
{
    public static List<int> bfs_traversal(int n, List<List<int>> edges) 
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
        // Do BFS
        // Why do we use a loop to add i instead of adding 1st element?
        // Because the graph can have multiple connected components, but not all vertices cana be visited at once
        // So we would need to check from each vertex in the graph.
        // Consider an example when none of the vertices are connected. In BFS we woould need to visit each node separately
        // This for loop takes care of that
        // In case we have connected vertices BFS will be taken care by adjacency list and since we are using visited, once added using
        // adjacency list that vertex will not be added in the for loop, so no problem in iterating over each vertex in graph.
        // In this way we are covering each node to add either through adjacency list or through the iterative loop, but not adding duplicates
        // because of Visited array.
        bool [] visited = new bool[n];
        var q = new Queue<int>();
        for(int i=0;i <n; i++)
        {
            q.Enqueue(i); // The first element which will have a connected edge in the adj list we chose that as start.
            if(!visited[i])
                result.Add(i);
            while(q.Count > 0)// Order of n because Queue will hold n vertices max.
            {
                var currentVertex = q.Dequeue();
                visited[currentVertex] = true;
                foreach(var adjVertex in adjList[currentVertex])// Order of highest degree
                {
                    if(!visited[adjVertex])
                    {
                        result.Add(adjVertex);
                        visited[adjVertex] = true;
                        q.Enqueue(adjVertex);
                    }
                }
            }
        }
        return result;
    }
}
