using System;

namespace Recursion.Problems;
/*
Given an integer array, generate all the unique combinations of the array numbers that sum up to a given target value.

{
"arr": [1, 2, 3],
"target": 3
}
Output:

[
[3],
[1, 2]
]

{
"arr": [1, 1, 1, 1],
"target": 2
}
Output:

[
[1, 1]
]
*/
public class UniqueCombinationSum
{
    public static List<List<int>> generate_all_combinations(List<int> arr, int target) {
        // Write your code here.
        var result = new List<List<int>>();
        Recursion(arr,target,0,new List<int>(),result,0);
        return result;
    }

    //Approach:
    // same as Unique subsets, the only difference is that we take a running sum.
    private static void Recursion(List<int> arr, int target, int index, List<int> sol, List<List<int>> result, int runningSum)
    {
        if(runningSum == target)
        {
            var copy = new List<int>(sol);
            result.Add(copy);
            return;
        }
        if(arr.Count == index)
            return;
        sol.Add(arr[index]);
        Recursion(arr, target, index+1,sol, result, runningSum+arr[index]);
        sol.RemoveAt(sol.Count-1);
        while(index < arr.Count-1 && arr[index]==arr[index+1])
            index++;
         Recursion(arr, target, index+1,sol, result, runningSum);
    }
}
