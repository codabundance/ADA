using System;

namespace Graph.Problems;
/*
Given an undirected graph, find out whether it is a tree.
The undirected edges are given by two arrays edge_start and edge_end of equal size. 
Edges of the given graph connect nodes edge_start[i] and edge_end[i] for all valid i.
*/

//Approach : A graph is a valid tree if it does not have a cycle & it is connected.
public class GraphIsValidTree
{   
    public static bool is_it_a_tree(int node_count, List<int> edge_start, List<int> edge_end) 
    {
        // Write your code here.
        // build the graph
        List<int>[] AdjList = new List<int>[node_count];
        for(int k=0; k < AdjList.Length; k++)
        {
            AdjList[k] = new List<int>();
        }
        for(int j=0;j< edge_start.Count; j++)
        {
            AdjList[edge_start[j]].Add(edge_end[j]);
            AdjList[edge_end[j]].Add(edge_start[j]);
        }
        int connectedComponents = 0;
        int[] parent = new int[node_count];
        for(int m=0; m< parent.Length; m++)
            parent[m] = -1;
        bool[] visited = new bool[node_count];
        // check if the graph has one connected component and does not have a cycle, then only it would become a valid tree
        for(int i=0; i< node_count; i++)
        {
            if(!visited[i])
            {
                visited[i] = true;
                connectedComponents++;
                if(connectedComponents > 1 || IsCyclePresentDFS(i,AdjList,parent, visited))
                    return false;
            }
        }
        return true;
    }

    private static bool IsCyclePresentDFS(int currentVertex, List<int>[] AdjacencyList, int[] parent, bool[] visited)
    {
        foreach (int edge in AdjacencyList[currentVertex])
        {
            if (!visited[edge])
            {
                visited[edge] = true;
                parent[edge] = currentVertex;
                if(IsCyclePresentDFS(edge, AdjacencyList, parent, visited)) 
                    return true;
            }
            else
            {
                // if the visited is false then let's check if it is not parent of current node. If not parent then this is a cross edge
                // Cycle is present
                if(parent[currentVertex] != edge)
                    return true;
            }
        }
        return false;
    }
}
