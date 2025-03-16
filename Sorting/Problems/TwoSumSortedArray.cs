using System;

namespace Sorting.Problems;
/**************************************************************
Given an array sorted in non-decreasing order and a target number, find the indices of the two values from the array that sum up to the given target number.


**************************************************************/
public class TwoSumSortedArray
{

    public static List<int> Pair_sum_sorted_array_1(List<int> numbers, int target) {
        // Write your code here.
        //Because the array is sorted, we will try the BST approach of finding a complimentary element
        // O(n log n)
        List<int> result = [];
        for(int i=0;i< numbers.Count; i++)
        {
            var x = BinarySearch(numbers, i+1, numbers.Count -1, target-numbers[i]);
            if(x != -1)
            {
                result.Add(x);
                result.Add(i);
                return result;
            }
        }
        result.Add(-1);
        result.Add(-1);
        return result;
    }
    
    private static int BinarySearch(List<int> arr,int start, int end, int SearchElement)
    {
        int low=start;int high = end;
        while(low <= high)
        {
            int mid = low + (high-low)/2;
            if(arr[mid]==SearchElement)
                return mid;
            if(arr[mid] < SearchElement)
                low = mid+1;
            if(arr[mid] > SearchElement)
                high = mid-1;
        }
        return -1;
    }

    public static List<int> pair_sum_sorted_array_2(List<int> numbers, int target) {
        // Write your code here.
        Dictionary<int, int> hash = [];
        var result = new List<int>();
        for(int i=0;i<numbers.Count;i++)
        {
            if(hash.ContainsKey(target-numbers[i]))
            {
                var m = hash[target-numbers[i]];
                result.Add(m);
                result.Add(i);
                return result;
            }
            hash.TryAdd(numbers[i],i);
        }
        result.Add(-1);
        result.Add(-1);
        return result;
    }
}

