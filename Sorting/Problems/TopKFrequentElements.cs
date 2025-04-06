using System;

namespace Sorting.Problems;
/*
Given an integer array and a number k, find the k most frequent elements in the array.

Example One
{
"arr": [1, 2, 3, 2, 4, 3, 1],
"k": 2
}
Output:

[3, 1]
Example Two
{
"arr": [1, 2, 1, 2, 3, 1],
"k": 1
}
Output:

[1]
*/
public class TopKFrequentElements
{
    public static List<int> find_top_k_frequent_elements(List<int> arr, int k) {
        // Write your code here.
        List<int> result = [];
        Dictionary<int, int> counter = [];
        for(int i=0; i< arr.Count; i++)
        {
            if(counter.TryGetValue(arr[i], out int value))
                counter[arr[i]] = ++value;
            else
                counter.Add(arr[i], 1);
        }
        // We can use quick search with lomuto's partitioning now over item's frequency to give the most frequent 4 elements
        // We can form an array of Keys and then do partitioning on that array.
        // While comparing, we can use the array elements as key and compare the values from dictionary
        List<int> keys = counter.Keys.ToList();
        int k_largest_index = keys.Count - k;
        quick_select(counter, keys,k_largest_index, 0, counter.Count-1);
        for(int j=k_largest_index; j< keys.Count ; j++)
        {
            result.Add(keys[j]);
        }
        return result;
    }

    private static void quick_select(Dictionary<int,int> counter,List<int> uniqueKeys, int idx, int start, int end)
    {
        if(start > end)
            return;
        int pivot = start;
        // bring piviot to the first position.
        //Swap(uniqueKeys,start,pivot);

        int left = start;
        int right = start+1;

        while(right <= end)
        {
            // While comparing, we can use the array elements as key and compare the values from dictionary
            if(counter[uniqueKeys[right]] < counter[uniqueKeys[pivot]])
            {
                left++;
                Swap(uniqueKeys,left,right);
            }
            right++;
        }
        Swap(uniqueKeys,left,start);
        if(left == idx)
            return;
        else if(idx < left)
            quick_select(counter,uniqueKeys,idx, start, left-1);
        else
            quick_select(counter,uniqueKeys,idx,left+1,end);
    }
     private static void Swap(List<int> arr, int a, int b)
    {
        (arr[b], arr[a]) = (arr[a], arr[b]);
    }
}
