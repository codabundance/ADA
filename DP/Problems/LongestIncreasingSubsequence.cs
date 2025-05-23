using System;
using System.Runtime.CompilerServices;

namespace DP.Problems;
// https://www.youtube.com/watch?v=h9rm4N8XbL0
// https://www.youtube.com/watch?v=DG50PJIx2SM
public class LongestIncreasingSubsequence
{
    public static int LengthOfLISBottomUp(int[] nums)
    {
        int[] dp = new int[nums.Length + 1];
        for (int i = 0; i <= nums.Length; i++)
        {
            dp[i] = 1;
        }
        //dp[i] = longest increasing subsequence ending at i.
        // Atleast 1 will be the answer because every number itself will be a solution
        int maxLength = 1;
        for (int j = 1; j < nums.Length; j++)
        {
            for (int k = 0; k < j; k++)
            {
                if (nums[k] < nums[j])
                {
                    // At index j in DP table, we compare the length of all possible subsequence formed using previous values
                    // Out of those we choose the max length and add 1 to it to arrive at the value of the max length of subsequence
                    // at element at j. 
                    dp[j] = Math.Max(dp[j], 1 + dp[k]);
                    // Out of all those index j we choose th max value again in the DP table.
                    maxLength = Math.Max(maxLength, dp[j]);
                }
            }
        }
        return maxLength;
    }


    //Approach: We will try to create every possible subsequence, the only condition will be that the subsequence will be created only 
    // when the current value is greater than the previous. Then for every subsequence formed, we check if it is lengthier than the max length
    // already existing. if yes replace.
    // Why only previous needs to be considered, even though subsequence can not be necessarily contiguous
    // This is because, we are taking and skipping. We take only those values which are continously increasing, and we add current to that subsequence
    // E.g. if we form subsequence like 1,2,5,8 then the previous will be 5 only here and we need to add 8 after 5. Thus for "take" scenarios
    // if we keep taking the previous as current-1 (or i-1) then it would work. 
    public static int LengthOfLISTopDown(int[] nums)
    {
        int [,] memo = new int[nums.Length,nums.Length];
        for (int i = 0; i < nums.Length; i++)
            for (int j = 0; j < nums.Length; j++)
                memo[i, j] = -1;
        return Helper(nums, -1, 0,memo);
    }

    private static int Helper(int[] nums, int previous, int current, int[,] memo)
    {
        if (current >= nums.Length)
            return 0;
        if (previous != -1 && memo[previous, current] != -1)
            return memo[previous, current];
        int take = 0;
        int skip = 0;
        if (previous == -1 || nums[previous] < nums[current])
        {
            take = 1 + Helper(nums, current, current + 1, memo);
        }
        skip = Helper(nums, previous, current + 1, memo);
        if(previous != -1)
            memo[previous, current] = Math.Max(take, skip);
        return Math.Max(take, skip);
    }
}
