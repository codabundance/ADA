using System;

namespace Graph.Problems;
/*
Check if there exists any eulerian cycle in a given undirected connected graph. The Euler cycle is a path in the graph that visits every edge exactly once and starts and finishes at the same vertex.

Example One
Graph

{
"n": 5,
"edges": [
[0, 1],
[0, 2],
[1, 3],
[3, 0],
[3, 2],
[4, 3],
[4, 0]
]
}
Output:

1
*/
public class EulerianCycle
{
    //Check if the degree of any of the vertice is odd or not.
    // If any of the vertices has odd degree then the graph will not have elulerian cycle.
    public static bool check_if_eulerian_cycle_exists(int n, List<List<int>> edges) {
        // Write your code here.
        for(int i=0; i< n;i++)
        {
            int count =0;
            foreach(var edge in edges)
            {
                if(i == edge[0] || i == edge[1])
                    count++;
            }
            if(count % 2 !=0)
                return false;
        }
        return true;
    }
}
