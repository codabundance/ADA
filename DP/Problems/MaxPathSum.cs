using System;

namespace DP.Problems;
/*
Maximum Path Sum
Given a two dimensional grid of numbers. Find a path from top-left corner to bottom-right corner, which maximizes the sum of all numbers along its path.

You can only move either down or right from your current position.

Example One
{
"grid": [
[4, 5, 8],
[3, 6, 4],
[2, 4, 7]
]
}
Output:

28
*/
public class MaxPathSum
{
    public static int maximum_path_sum(List<List<int>> grid) 
    {
        // Write your code here.
        int m = grid.Count;
        int n = grid[0].Count;
        int[,] dp = new int[m,n];
        dp[0,0] = grid[0][0];
        for(int i=1; i < m; i++)
            dp[i,0] = dp[i-1,0]+grid[i][0];
        for(int j=1; j < n; j++)
            dp[0,j] = dp[0,j-1] + grid[0][j];
        for(int row = 1; row < m; row++)
        {
            for(int col = 1; col < n; col++)
            {
                dp[row,col] = Math.Max(dp[row-1,col], dp[row,col-1]) + grid[row][col];
            }
        }
        return dp[m-1,n-1];
    }
}
