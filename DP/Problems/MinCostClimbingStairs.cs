using System;

namespace DP.Problems;
/*
There are n stairs indexed 0 to n – 1. Each stair has a cost associated with it. After paying the cost, it's allowed either to climb one or two steps further. 
It's allowed to either start from the step with index 0, or the step with index 1.
Given the cost array, find the minimum cost to reach the top of the floor.
cost[i] represents the cost of i-th stair.

Example One
{
"cost": [1, 1, 2]
}
Output:

1
There are 5 ways to reach the top floor.

step 0 → step 1 → step 2 → top floor.
step 0 → step 1 → top floor.
step 0 → step 2 → top floor.
step 1 → step 2 → top floor.
step 1 → top floor.
Here, the last way(step 1 → top floor) will provide the most optimal cost 1.

Example Two
{
"cost": [3, 4]
}
Output:

3
*/
public class MinCostClimbingStairs
{
    public static int min_cost_climbing_stairs(List<int> cost) 
    {
        // Write your code here.
        int n = cost.Count;
        int[] dp = new int[n+2];
        cost.Add(0);
        dp[0] = 0;
        dp[1] = cost[0];
        for(int i=2; i< dp.Length;i++)
        {
            dp[i] = Math.Min(dp[i-1], dp[i-2])+cost[i-1];
        }
        return dp[dp.Length-1];
    }
}
