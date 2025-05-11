using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP.Problems;
/*
You are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

An obstacle and space are marked as 1 or 0 respectively in grid. A path that the robot takes cannot include any square that is an obstacle.

Return the number of possible unique paths that the robot can take to reach the bottom-right corner.

The testcases are generated so that the answer will be less than or equal to 2 * 109.

 

Example 1:


Input: obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
Output: 2
Explanation: There is one obstacle in the middle of the 3x3 grid above.
There are two ways to reach the bottom-right corner:
1. Right -> Right -> Down -> Down
2. Down -> Down -> Right -> Right
Example 2:


Input: obstacleGrid = [[0,1],[0,0]]
Output: 1
 

Constraints:

m == obstacleGrid.length
n == obstacleGrid[i].length
1 <= m, n <= 100
obstacleGrid[i][j] is 0 or 1.
*/
//We can solve this in the same way as Unique Path problem. Only that for filling each dp[i][j] we will see of either dp[i-1][j] or dp[i][j-1]
//has an obstacle. If there is an obstacle, dont consider that, so for that dp[i] there would be only 1 solution instead of Max().
// Will this still be optimal substructure? Yes it will be because we cannot take the path with obstacle for any subproblems as well.
public class UniquePathsII
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid) 
    {
        int numRows = obstacleGrid.Length;
        int numCols = obstacleGrid[0].Length;
        int[,] table = new int[numRows, numCols];
        if(obstacleGrid[numRows-1][numCols-1]== 1)
            return 0;
        if(obstacleGrid[0][0]== 1)
            return 0;
        else
            table[0,0] = 1;
        //base cases
        for(int i=0; i<numRows; i++)
        {
            if(obstacleGrid[i][0] == 1)//if there is an obstacle, we cannot reach this node and other nodes in the same row so value is 0.
               break;
            table[i,0] = 1;
        }
        for(int j=0; j<numCols; j++)
        {
            if(obstacleGrid[0][j] == 1)//if there is an obstacle, we cannot reach this node and other nodes in the same column so value is 0.
               break;
            table[0,j] = 1;
        }
        // form the table
        for(int row = 1; row < numRows; row++)
        {
            for(int col = 1; col < numCols; col++)
            {
                // we dont need to explicitly check for [row, col-1] and [row-1,col] here because we would have already solved them
                // if these nodes had obstacles, they would already be filled with 0
                // consider this - if 1st one OR 2nd one is 0, then there is only those many ways as the one with non zero
                // if both are zeros, then there is not way. Makes sense
                if(obstacleGrid[row-1][col] == 1) //if current subproblem is obstacle there is no way to reach this.
                    table[row,col] = 1;
                else 
                    table[row, col] = table[row, col-1] + table[row-1, col];
            }
        }
        return table[numRows-1, numCols-1];
    }
}
