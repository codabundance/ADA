using System;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Xml.XPath;

namespace DP.Problems;

public class BestSum
{
    public static List<int> GetBestSumBruteForce(int targetSum, List<int> nums, List<int> Best)
    {
        if (targetSum == 0) return []; // reached the required result, we keep on adding the element to this once we return back
        if (targetSum < 0) return null; // not possible to reach target sum from here

        foreach (var num in nums)
        {
            int remainder = targetSum - num; // explore each branch by reducing the current number from target sum
            var result = GetBestSumBruteForce(remainder, nums, Best); // recursive call
            if (result != null)// we have a path where target sum is possible
            {
                result.Add(num); // add the element from which we reached that path
                // if the length of current path is less than the one stored in Best, then best becomes current
                if (Best == null || result.Count < Best.Count)
                {
                    Best = result;
                }
            }
        }
        return Best;
    }

    public static List<int> GetBestSumMemo(int targetSum, List<int> nums, List<int> Best, Dictionary<int, List<int>> memo)
    {
        if (memo.TryGetValue(targetSum, out List<int>? value))
            return value;
        if (targetSum == 0) return []; // reached the required result, we keep on adding the element to this once we return back
        if (targetSum < 0) return null; // not possible to reach target sum from here

        foreach (var num in nums)
        {
            int remainder = targetSum - num; // explore each branch by reducing the current number from target sum
            var result = GetBestSumMemo(remainder, nums, Best, memo); // recursive call
            if (result != null)// we have a path where target sum is possible
            {
                result.Add(num); // add the element from which we reached that path
                // if the length of current path is less than the one stored in Best, then best becomes current
                if (Best == null || result.Count < Best.Count)
                {
                    Best = result;
                }
            }
        }
        memo[targetSum] = Best;
        return Best;
    }

    public static List<int> GetBestSumTab(int targetSum, List<int> nums)
    {
        List<int>[] DP = new List<int>[targetSum + 1];// initialized with null by default
                                                      // DP[i] represents the best path to reach the number i. Notice that this is asking for optimization
                                                      // So it must have optimal substructure to apply DP. And it has
        DP[0] = [];// The best path to reach target sum= 0 is do not choose any element
        for (int i = 1; i <= targetSum; i++)// fill the table
        {
            List<int> bestSolution = null;
            //iterate through each element in nums and find the best way to reach 'i' out of these nums and add it
            //notice that best way would be one with min length
            foreach (var num in nums)
            {
                if (i >= num) // num should be smaller than i then only you can use it to reach i.
                {
                    if (DP[i - num] != null)// DP[i-num] is null means we have not been able to find best part for i-num. So we need to ignore it
                    {
                        var prev = DP[i - num]; // it will have the best solution till i-num, so we will get this and add num
                        var newList = new List<int>(prev);
                        newList.Add(num);
                        if (bestSolution == null || newList.Count < bestSolution.Count)
                            bestSolution = newList;
                    }
                }
            }
            DP[i] = bestSolution;
        }
        return DP[targetSum];
    }
}
