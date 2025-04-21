using System;

namespace Graph.Problems;
/*
There is an undirected graph with n nodes, where each node is numbered between 0 and n - 1. You are given a 2D array graph, where graph[u] is an array of nodes that node u is adjacent to. More formally, for each v in graph[u], there is an undirected edge between node u and node v. The graph has the following properties:

There are no self-edges (graph[u] does not contain u).
There are no parallel edges (graph[u] does not contain duplicate values).
If v is in graph[u], then u is in graph[v] (the graph is undirected).
The graph may not be connected, meaning there may be two nodes u and v such that there is no path between them.
A graph is bipartite if the nodes can be partitioned into two independent sets A and B such that every edge in the graph connects a node in set A and a node in set B.

Return true if and only if it is bipartite.
*/
public class Bipartite
{
    // Approach 2: We can traverse through each of the nodes using BFS/DFS and give different colors to adjacent nodes
    // if at any node, the color of current and adjacent are same, it is not bipartite.
    public bool IsBipartite(int[][] graph) 
    {
        // Build the graph
        List<int>[] Adjacency = new List<int>[graph.Length];
        for(int i = 0; i< graph.Length;i++)
        {
            Adjacency[i] = graph[i].ToList();
        }
        int [] color = new int[graph.Length];
        for(int k = 0; k < color.Length; k++)
            color[k] = -1;
        for(int j=0; j< graph.Length;j++)
        {
            if(color[j]== -1)
            {
                if(!DFS(Adjacency,j,color,1))
                    return false;
            }
        }
        return true;
    }

    private static bool DFS(List<int>[] adj, int current, int[] color, int currentColor)
    {
        color[current] = currentColor;
        foreach(var v in adj[current])
        {
            if(color[v] == -1)
            {
                if(!DFS(adj, v, color, 1- currentColor))
                    return false;
            }
            else if(color[v] == currentColor)
                return false;
        }
        return true;
    }

    // Approach 1: A graph will be bipartite if
        // 1. It is acyclic
        // 2. If it is cyclic and the cycle has even number of nodes
        // 3. It is NOT bipartite only if it has cycle with Odd number nodes, rest all cases it is Bipartite.
        // 4. For finding cycle with odd number nodes - the distance of vertices which have the cross edge (the one that forms cycle)
        //    should be same from source.
    public bool IsBipartiteV2(int[][] graph)
    {
        // Build the graph
        List<int>[] Adjacency = new List<int>[graph.Length];
        for(int i = 0; i< graph.Length;i++)
        {
            Adjacency[i] = graph[i].ToList();
        }
        int [] distance = new int[graph.Length];
        int [] parent = new int[graph.Length];
        for(int k =0; k< distance.Length; k++)
        {
            distance[k] = -1;
            parent[k] = -1;
        }
        bool[] visited = new bool[graph.Length];
        for(int j=0; j< graph.Length; j++)
        {
            distance[j] = 0;
            if(!visited[j])
            {
                // Even if graph has connected components, if one of them is not bipartite then graph iself is not.
                // This if condition takes care of that as well.
                if(IsOddCycleBFS(Adjacency,j,distance,parent,visited))
                    return false;
            }
        }
        return true;
    }
    private bool IsOddCycleBFS(List<int>[] adj, int current, int[] distance,int[] parent, bool[] visited)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(current);
        visited[current] = true;
        while(queue.Count > 0)
        {
            current = queue.Dequeue();
            foreach(int V in adj[current])
            {
                if(!visited[V])
                {
                    visited[V] = true;
                    parent[V] = current;
                    distance[V] = distance[current]+1;
                    queue.Enqueue(V);
                }
                else if(parent[current]!=V /*Cycle found*/ && distance[current] == distance[V] /*Distance equal from source so Odd*/)
                    return true;
            }
        }
        return false;
    }
}
