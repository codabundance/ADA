using System;
using System.ComponentModel;

namespace DP.Problems;
/*
Unique Paths
Given a grid of size n x m and a robot initially staying at the top-left position, return the number of unique paths for the robot to reach the bottom-right corner of the grid. The robot is allowed to move either down or right at any point in time.

Example One
{
"n": 3,
"m": 2
}
Output:

3
From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:

Right -> Down -> Down
Down -> Down -> Right
Down -> Right -> Down
Example Two
{
"n": 4,
"m": 1
}
Output:

1
From the top-left corner, there is only one way to reach bottom-right corner:

Down -> Down -> Down

*/
public class UniquePaths
{
    public static int unique_paths(int n, int m) {
        // Write your code here.
        int[,] dp = new int[n, m];
        for(int i = 0; i < n; i++)
        {
            dp[i,0] = 1; // for first column, the only unique path to reach at each square is from top so count is 1.
        }
        for(int j=0; j< m; j++)
        {
            dp[0,j] = 1; // for first row, the only unique path to reach at each square is from left so count is 1.
        }

        for(int row=1; row < n; row++)
        {
            for(int col=1; col < m; col++)
            {
                dp[row,col] = dp[row-1,col] + dp[row, col-1];// either come from left or from right
            }
        }
        return dp[n-1,m-1];//n and m is size, so we have to return the m-1 and n-1 value as we are working on indices.
    }
}
