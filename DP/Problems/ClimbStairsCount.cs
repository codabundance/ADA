using System;

namespace DP.Problems;
/*
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 

Example 1:

Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
*/
public class ClimbStairsCount
{
    public int ClimbStairs(int n) {
        int[] table = new int[n+1];
        table[0] = 0;
        table[1] = 1;
        table[2] = 2;
        for(int i=3;i<=n;i++)
            table[i] = table[i-1] + table[i-2];
        return table[n];
    }
}
