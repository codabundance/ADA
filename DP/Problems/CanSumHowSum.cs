using System;
using System.Runtime.Intrinsics.Arm;

namespace DP.Problems;
/*
Given an array of integers and a target sum, find any combination of elements of the array that gives target sum
*/
public class CanSumHowSum
{
    // Recursive
    // Time = pow(targetSum, nums.Count). Here the tree expands by n everytime instead of 2.
    // Space = TargetSum, max length of the array can be target sum. consider when nums has all elements as 1, so we will have to add target
    // sum times to get the target sum.
    public static List<int> CanSumHowRec(List<int> nums, int targetSum)
    {
        if (targetSum == 0) return [];
        if (targetSum < 0) return null;

        for (int i = 0; i < nums.Count; i++)
        {
            int remainder = targetSum - nums[i];
            var result = CanSumHowRec(nums, remainder);
            if (result != null)
            {
                result.Add(nums[i]);
                return result;
            }
        }
        return null;
    }

    // Memoization
    // Time = pow(targetSum*nums.Count) --> Here because of memoization, every level has only n nodes
    // Space = TargetSum * nums.Count
    public static List<int> CanSumHowMemo(List<int> nums, int targetSum, Dictionary<int, List<int>> memo)
    {
        if (memo.TryGetValue(targetSum, out List<int>? value))
            return value;
        if (targetSum == 0) return [];
        if (targetSum < 0) return null;

        for (int i = 0; i < nums.Count; i++)
        {
            int remainder = targetSum - nums[i];
            var result = CanSumHowMemo(nums, remainder, memo);
            if (result != null)
            {
                result.Add(nums[i]);
                memo[targetSum] = result;
                return result;
            }
        }
        memo[targetSum] = null;
        return null;
    }

    //Tabulation
    //Time complexity = O(m*n)
    //Space complexity = O(m*n)
    public static bool CanSumTab(List<int> nums, int targetSum)
    {
        //because we have the target sum as the variable we will have our DP table based on that
        bool[] DP = new bool[targetSum + 1];// DP[i] represents is it possible to obtain i by adding elements in nums
        DP[0] = true; // if we dont choose any element we obtain 0.
        for (int i = 1; i < DP.Length; i++)//fill the DP table
        {
            foreach (var num in nums)
            {
                // Dont go out of bounds
                if (i >= num)
                {
                    //we can reach "i" only by using values in the nums array. 
                    // If any DP at i-nums is true then it is possible to reach i as well, this set i as true
                    // if none of the elements can take us to i, DP[i] will anyways be false.
                    if (DP[i - num])
                        DP[i] = true;
                }
            }
        }
        return DP[targetSum];
    }
    //Tabulation
    //Time complexity = O(m*n)
    //Space complexity = O(m*n)
    public static List<int> HowSumTab(List<int> nums, int targetSum)
    {
        //Because we have the target sum as the variable we will have our DP table based on that
        //DP[i] represents list of elements to obtain i by adding elements in nums
        //Each list will be initialized by null by default. This is what we want.
        List<int>[] DP = new List<int>[targetSum + 1];
        DP[0] = []; // if we dont choose any element we obtain 0.
        for (int i = 1; i < DP.Length; i++)//fill the DP table
        {
            foreach (var num in nums)
            {
                // Dont go out of bounds
                if (i >= num)
                {
                    // we can reach "i" only by using values in the nums array. 
                    // We can reach i by adding any of the elements in the nums array to i-[num].
                    // if none of the elements can take us to i, DP[i] will anyways be null.
                    if (DP[i - num] != null)
                    {
                        var prev = DP[i - num];
                        var newList = new List<int>(prev);// create a copy because we dont want to disturb the prev
                        newList.Add(num);// Add the current number to this list because we can reach i by using current number.
                        DP[i] = newList;
                    }
                }
            }
        }
        return DP[targetSum];
    }
}
