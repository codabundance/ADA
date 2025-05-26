/*
Given a variety of coin denominations existing in a currency system, find the total number of ways a given amount of money can be expressed using coins in that currency system.

Assume an infinite supply of coins of every denomination.

Example
{
"coins ": [1, 2, 3],
"amount": 3
}
Output:

3
*/
using System;

namespace DP.Problems;

public class WaysToMakeChange
{
    public static int Number_of_ways(List<int> coins, int amount)
    {
        // Write your code here.
        return Memoization(coins, amount, new List<int>(), 0, -1);
    }

    // Top Down
    // We will have a recursive approach
    // We will take all the coins in a loop and for every coin which is less than amount, we will 
    public static int Memoization(List<int> coins, int amount, List<int> current, int NoOfWays, int index)
    {
        int currentSum = 0;
        for (int i = 0; i < current.Count; i++)
        {
            currentSum += current[i];
        }
        if (currentSum == amount)
        {
            NoOfWays++;
            return NoOfWays;
        }
        if (currentSum > amount)
            return NoOfWays;
        int result = 0;
        /// This loop is required when we add same element multiple times. This will start from index because we dont want to revisit old elements.
        for (int j = index; j < coins.Count; j++)
        {
            if (coins[j] <= amount)
            {
                current.Add(coins[j]);
                result = Memoization(coins, amount, current, NoOfWays, j);
                current.RemoveAt(current.Count - 1);
            }
        }
        return result;

    }

    public static int Memoization2(List<int> coins, int amount, int index, Dictionary<(int, int), int> memo)
    {
        if (amount == 0)
            return 1;
        if (amount < 0)
            return 0;

        if (memo.ContainsKey((amount, index)))
            return memo[(amount, index)];

        int result = 0;
        /// This loop is required when we add same element multiple times. This will start from index because we dont want to revisit old elements.
        for (int j = index; j < coins.Count; j++)
        {
            if (coins[j] <= amount)
            {
                result += Memoization2(coins, amount - coins[j], j, memo);
            }
        }
        memo[(amount, index)] = result;
        return result;
    }

    // Bottom Up
    // This is wrong approach as it is working like permutation and taking same coins with different order as different
    // when you are trying to calculate DP[3] you are going through all the coins, so first you are adding coind 2 to 1
    // and in a subsequent loop you are also adding 1 to 2, thus recounting these.
    // This matters in counting problems, but not in max min problems, because even if you count them twice the value is same i.e. 3
    // So finding max or min is not affected.
    // This the correct approach is Combinations

    public static int Tabulation(List<int> coins, int amount)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1; // There is one way to form a change of 0. i.e. not choosing anything.
        for (int i = 1; i < dp.Length; i++)
        {
            for (int k = 0; k < coins.Count; k++)
            {
                if (i - coins[k] >= 0)
                    dp[i] = dp[i] + dp[i - coins[k]];
            }
        }
        return dp[amount];
    }

    // This is correct as it is working as combination
    // We are taking the coin as outer loop, so that we dont repeat thec coins
    // When we take coins as outer loop, we know that all coins will be added to each other only once
    // This is one important group of problems where ordering matters in Tabulation DP.
    public static int Combinations(List<int> coins, int amount)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1;

        foreach (int coin in coins)
        {
            for (int i = coin; i <= amount; i++)
            {
                dp[i] += dp[i - coin];
            }
        }

        return dp[amount];
    }

}
