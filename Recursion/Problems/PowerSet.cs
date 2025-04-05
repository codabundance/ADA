using System;

namespace Recursion;
// Given an array A find all possible subsets of Array A.
public class PowerSet
{
    public List<List<int>> GetPowerSet(List<int> arr)
    {
        List<List<int>> result = new List<List<int>>();
        Helper(arr, result, [],0);
        return result;
    }
    private static void Helper(List<int> arr, List<List<int>> results, List<int> slate, int index)
    {
        if(index == arr.Count)
        {
            List<int> new_slate = [..slate];// Add a copy and not a reference
            results.Add(new_slate);
            return;
        }
        // Include current element
        slate.Add(arr[index]);
        Helper(arr,results,slate, index+1);
        //Equivalent of Pop. Remove last elementwe need to remove this so as to bring slate in correct state
        slate.RemoveAt(slate.Count - 1);

        //Exclude current element
        Helper(arr, results, slate, index+1);
    }
}
