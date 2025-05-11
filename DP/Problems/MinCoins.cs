using System;

namespace DP.Problems;
/*
Minimum Coins
Given a variety of coin types defining a currency system, find the minimum number of coins required to express a given amount of money. Assume infinite supply of coins of every type.

Example
{
"coins": [1, 3, 5],
"value": 9
}
Output:

3
*/


// Approach : This is an optimisation problem. So we will use DP
// Here value can be formed by any coin present in the coins problem, so f(n) = 1 + Min(f(n-c(i)) where i= all possible coins
// All possible subproblems can be 0 to 'value' so a DP table of size 'value+1' will be required. We are forming a table with all possible subproblems.
// These will be filled or not filled based on coins given.
// table[i] will contain min ways to form the subproblem i using the coins given
// if a given subproblem i could not be formed by given coins table[i] will have -1.
// once we build the entire table the answer will be in table[value]
public class MinCoins
{
    public static int minimum_coins(List<int> coins, int value) 
    {
        // Write your code here.
        // Initialize the DP table
        int[] dp = new int[value+1];
        for(int i=0;i<=value;i++)
            dp[i] = int.MaxValue; // We cannot use -1 because we have to calculate min and -1 will always evaluate to min.
        //Base case
        dp[0] = 0;
        // Build the rest of the table
        for(int j=1;j<=value;j++)
        {
            foreach(var coin in coins)
            {
                if(coin <= j) // We cannot form the subproblems from the given coins as subproblems are smaller than coins, so we put a check here for vaild subproblem
                {
                    dp[j] = Math.Min(dp[j], dp[j-coin]);// For every subproblem, we find the min of ways it can be formed from diff coins.
                }
            }
            if(dp[j] < int.MaxValue)
                dp[j]++; // finanlly when we have found the min ways. We add one more to the current subproblems value in dp table. Remember : 1 + Min(f(n-c(i))
        }
        if(dp[value] == int.MaxValue)
            return -1;
        return dp[value]; // finally return the min ways for forming value.
    }
}
