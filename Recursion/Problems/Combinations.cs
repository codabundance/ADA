using System;

namespace Recursion;
// Given an array A, find all possible combinations of size K.
public class Combinations
{
    public static List<List<int>> GetCombinations(List<int> arr, int k)
    {
        List<List<int>> result = new List<List<int>>();
        Helper(arr, result, [],0,k);
        return result;
    }
    private static void Helper(List<int> arr, List<List<int>> results, List<int> slate, int index, int k)
    {
        if(slate.Count + arr.Count - index + 1 < k) // We cannot form tree as the remaining elements are less than K.
            return;
        if(slate.Count == k)
        {
            List<int> new_slate = [..slate];// Add a copy and not a reference
            results.Add(new_slate);
            return;
        }
        if(index == arr.Count)
            return;
        // Include current element
        slate.Add(arr[index]);
        Helper(arr,results,slate, index+1,k);
        //Equivalent of Pop. Remove last elementwe need to remove this so as to bring slate in correct state
        slate.RemoveAt(slate.Count - 1);

        //Exclude current element
        Helper(arr, results, slate, index+1,k);
    }

    private static void Helper_1(int n, IList<IList<int>> results, IList<int> slate, int index, int k)
    {
        if(slate.Count + n - index + 1 < k) // We cannot form tree as the remaining elements are less than K.
            return;
        if(slate.Count == k)
        {
            IList<int> new_slate = [..slate];// Add a copy and not a reference
            results.Add(new_slate);
            return;
        }
        // This code will not allow last element to be added because it will return even before last is added.
        //if(index == n)
            //return;
        // Include current element
        slate.Add(index);
        Helper_1(n,results,slate, index+1,k);
        //Equivalent of Pop. Remove last elementwe need to remove this so as to bring slate in correct state
        slate.RemoveAt(slate.Count - 1);

        //Exclude current element
        Helper_1(n, results, slate, index+1,k);
    }
}
