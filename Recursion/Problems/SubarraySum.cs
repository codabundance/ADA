using System;

namespace Recursion;
/*Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.

A subarray is a contiguous non-empty sequence of elements within an array.
Contiguous is the keyword here.
Example 1:

Input: nums = [1,1,1], k = 2
Output: 2
Example 2:

Input: nums = [1,2,3], k = 3
Output: 2
*/
public class SubarraySum
{
    // This is not exhaustive search problem. This is simple array traversing problem. Exhaustive search will give you exponential
    // while array traversal worst case would be n square.
    // Brute Force Approach : 2 for loops and keep adding sum and check if sum == k. Increase count.
    int ResultCount = 0;
    public int Subarray_Sum(int[] nums, int k) {
        Helper(nums.ToList(),k,0,0,0);
        return ResultCount;
    }
    private void Helper(List<int> arr, long k, int i, int running_length, int running_sum)
    {
        if(running_sum == k && running_length > 0)
        {
            ResultCount++;
            return; 
        }
        if(i == arr.Count)
            return;
        Helper(arr,k,i+1,running_length + 1,running_sum + arr[i]);
        Helper(arr,k,i+1,running_length,running_sum);
    }
}
