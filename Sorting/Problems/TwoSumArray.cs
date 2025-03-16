using System;

namespace Sorting.Problems;
/**************************************************************
Given an array and a target number, find the indices of the two values from the array that sum up to the given target number.
***************************************************************/
public class TwoSumArray
{
    
    public static List<int> Two_sum(List<int> numbers, int target) {
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