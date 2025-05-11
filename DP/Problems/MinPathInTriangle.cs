using System;
using System.Diagnostics;

namespace DP.Problems;

public class MinPathInTriangle
{
    public int MinimumTotal(IList<IList<int>> triangle) 
    {
        int totalRows = triangle.Count;
        // Initialize the DP table
        int[][] dp = new int[totalRows][];
        for(int i=0; i<totalRows; i++) // variable number of columns so initialize each column separately.
            dp[i] = new int[triangle[i].Count];
        //base cases
        dp[0][0] = triangle[0][0];
        for(int k=1; k< totalRows;k++)
        {
            dp[k][0] = dp[k-1][0] + triangle[k][0];
            //columns will be same as row, or legth of each row -1
            dp[k][k] = dp[k-1][k-1] + triangle[k][k];
        }
        //form the rest of the table
        //this gives information for min path for all the last row elements
        for(int row=2; row < totalRows; row++)
        {
            // this loop will run from 1 because column at index 1 is still not touched. It will run till end of current row's length -1
            // If we focus, we can see that the number of elements (or columns) in each row = row index.
            // but because we have already filled the last index as base cas, so we have to fill only upto penultimate column
            // thus this loop runs from 1 to row-1.
            for(int col=1; col <= row-1; col++)
            {
                dp[row][col] = Math.Min(dp[row-1][col-1],dp[row-1][col]) + triangle[row][col];
            }
        }
        // find minimum of all the paths till last row. The min path is not optimal substructure, but length of path is, thus we calculate min of each path
        // and then find min of all min paths.
        int min = int.MaxValue;
        for(int j=0;j< dp[totalRows-1].Length;j++)
        {
            min = Math.Min(min, dp[totalRows-1][j]);
        }
        return min;
    }
}
