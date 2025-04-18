using System;

namespace Graph.Problems;

public class EulerianPath
{
    public static bool check_if_eulerian_path_exists(int n, List<List<int>> edges) {
        // Write your code here.
        List<bool> CountArray = new List<bool>();
        for(int i=0; i< n;i++)
        {
            int count = 0;
            foreach(var edge in edges)
            {
                if(i == edge[0] || i == edge[1])
                    count++;
            }
            if(count % 2 != 0)
                CountArray.Add(true);
        }
        if(CountArray.Count == 2 || CountArray.Count == 0)
            return true;
        else
            return false;
    }
}
