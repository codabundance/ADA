using System;

namespace Graph;
/*
Given a two-dimensional grid of 0s and 1s, find the size of the largest island. If there is no island return 0.

An island is a group of 1s connected vertically or horizontally.

Example One
{
"grid": [
[1, 1, 0],
[1, 1, 0],
[0, 0, 1]
]
}
Output:

4

There are two islands:

[(0, 0), (0, 1), (1, 0), (1, 1)]
[(2, 2)]
Size of the largest (first) island is 4.

Example Two
{
"grid": [
[0, 0, 0],
[0, 0, 0],
[0, 0, 0]
]
}
Output:

0
*/
public class FindLargestIsland
{
    private static int IslandSize = 0;
    public static int max_island_size(List<List<int>> grid) 
    {
        // Write your code here.
        int rows = grid.Count;
        int cols = grid[0].Count;
        bool[,] visited = new bool[rows,cols];
        int maxIslandSize = 0;
        //int connectedCount = 0;
        for(int row = 0; row < rows; row++)
        {
            for(int col = 0;col  < cols; col++)
            {
                if(grid[row][col] == 1 && !visited[row,col])
                {
                    IslandSize = 1;
                    GridTraversal(grid, visited, row, col);
                    if(IslandSize > maxIslandSize)
                       maxIslandSize = IslandSize;
                }
            }
        }
        return maxIslandSize;
    }
    // Add a new variable IslandSize which will calculate the number of 1s visited in 1 DFS
    // This will give the size of island in that DFS
    // With every DFS, calculate island size and update the max island size.
    private static void GridTraversal(List<List<int>> grid, bool[,] visited, int row, int col)
    {
        int[] rowsArray = new int[4]{-1, 1, 0, 0};
        int[] colsArray =new int[4]{0, 0, -1, 1};
        visited[row,col] = true;
        for(int i=0;i<4;i++)
        {
            int new_row = row+rowsArray[i];
            int new_col = col+colsArray[i];
            if(new_row >=0 && new_row < grid.Count && new_col >=0 && new_col < grid[0].Count
            && !visited[new_row, new_col] && grid[new_row][new_col] == 1)
            {
                IslandSize+=1;
                GridTraversal(grid, visited, new_row, new_col);
            }
        }
    }
}
