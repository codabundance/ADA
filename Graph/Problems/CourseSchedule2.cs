using System;

namespace Graph.Problems;
/*
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

 

Example 1:

Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].
Example 2:

Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].
Example 3:

Input: numCourses = 1, prerequisites = []
Output: [0]

*/
public class CourseSchedule2
{
    public static int[] FindOrder(int n, int[][] prerequisites) {
        // Write your code here.
        // Create Directed Graph
        List<int>[] adjList = new List<int>[n];
        for(int m=0;m<n;m++)
          adjList[m] = new List<int>();
        foreach(var idx in prerequisites)
        {
            //Directed node will be from the the Dependency to the next course. Because we will complete dependency first
            //The answer should also reflect the same.
            adjList[idx[1]].Add(idx[0]);
        }
        bool[] arrival = new bool[n];
        bool[] departure = new bool[n];
        List<int> orderOfCourses = new();
        // we dont know from where to start, so we need to try every element, thus loop required
        for(int k=0; k<n;k++)
        {
            if(!arrival[k])
            {
                if(IsCyclic(n,adjList,arrival,departure,k, orderOfCourses))
                    return Array.Empty<int>();
            }
        }
        // We are doing a DFS, so we add the course that we will do later(or dependant course) first to the result
        // And prerequisite course secondly. So we need to reverse to find the correc order.
        orderOfCourses.Reverse();
        return orderOfCourses.ToArray();
        
    }
    private static bool IsCyclic(int n, List<int>[] adjList, bool[] arrival, bool[] departure, int curr, List<int> orderOfCourses)
    {
        arrival[curr] = true;
        var neighbours = adjList[curr];
        foreach(var adj in neighbours)
        {
            if(!arrival[adj])
            {
                if(IsCyclic(n, adjList, arrival, departure, adj, orderOfCourses))
                    return true;
            }
            else
            {
                // Arrival is set as true, if departure is not true, then cycle else DFS would have completed.
                if(!departure[adj])
                    return true;
            }
        }
        // set departure as true when DFS completes on current node.
        departure[curr] = true;
        orderOfCourses.Add(curr);
        return false;
    }
}
