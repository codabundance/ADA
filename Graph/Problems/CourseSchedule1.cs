using System;

namespace Graph.Problems;
/*
Complete All Courses With Dependencies
A university has n courses to offer. To graduate from that university, a student must complete all those courses. 
Some courses have prerequisite courses. One can take a course only after completing all of its prerequisites. 
Dependencies between the courses are described by two arrays a and b of the same size: 
course a[i] must be taken before course b[i] for all valid indices. Is it possible to complete all the courses without violating constraints?

Example One
{
"n": 4,
"a": [1, 1, 3],
"b": [0, 2, 1]
}
Output:

1
One possible ordering is 3, 1, 0, 2.

Example Two
{
"n": 4,
"a": [1, 1, 3, 0],
"b": [0, 2, 1, 3]
}
Output:

0
*/
public class CourseSchedule1
{
    public static bool can_be_completed(int n, List<int> a, List<int> b) {
        // Write your code here.
        // Create Directed Graph
        List<int>[] adjList = new List<int>[n];
        for(int m=0;m<n;m++)
          adjList[m] = new List<int>();
        for(int i=0; i<a.Count; i++)
        {
            adjList[b[i]].Add(a[i]);
        }
        bool[] arrival = new bool[n];
        bool[] departure = new bool[n];
        // we dont know from where to start, so we need to try every element, thus loop required
        for(int k=0; k<n;k++)
        {
            if(!arrival[k])
            {
                if(IsCyclic(n,adjList,arrival,departure,k))
                    return false;
            }
        }
        return true;
    }
    private static bool IsCyclic(int n, List<int>[] adjList, bool[] arrival, bool[] departure, int curr)
    {
        arrival[curr] = true;
        var neighbours = adjList[curr];
        foreach(var adj in neighbours)
        {
            if(!arrival[adj])
            {
                if(IsCyclic(n, adjList, arrival, departure, adj))
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
        return false;
    }
}
