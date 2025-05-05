using System;

namespace DP.Problems;
/*
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.
*/
public class MinPathSum
{
    public static int MinPathSum1(int[][] grid) 
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,] table = new int[m, n];
        table[0,0] = grid[0][0];
        // Fill the first row as base case
        for(int i=1;i<m;i++)
        {
            table[i,0] = table[i-1,0]+ grid[i][0];
        }
        // fill the first column as base case
        for(int j=1;j<n;j++)
        {
            table[0,j] = table[0,j-1] + grid[0][j];
        }
        // fill other rows and cols of the table based on recursion.
        // follows optimal substrcuture, so we can use the recursion
        for(int k=1;k < m;k++)
        {
            for(int p=1;p < n;p++)
            {
                table[k,p] = Math.Min(table[k-1,p],table[k,p-1]) + grid[k][p];
            }
        }
        return table[m-1,n-1];
    }
}
