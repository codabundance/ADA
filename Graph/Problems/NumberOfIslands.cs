using System;

namespace Graph.Problems;
/*
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
*/
public class NumberOfIslands
{
    /*
    Approach 1: 
    -------------
    Each 1 in this matrix would represent a connecting edge and each 0 would represent a no connection.
    It is not same as adjacency matrix, because that also provides connection info/ edge between 2 vertices.
    This matrix only provides info whether the current vertex is connected to any other vertex or not and no info about the other vertex.

    We can do a BFS or DFS from each node taking the path of 1s. As soon as we reach a point where we have covered all once and there is no
    way to go forward - the covered nodes become an island, importantly this also resembles one connected component in this traversal.
    So #islands = #connected_components

    We do the same traversal again for non visited vertices and find all the conected components.
    That is the answer.
    */
    public static int NumIslands(char[][] grid) 
    {
        char[,] grid2 = ToMultidimensionalArray(grid);
        int rows = grid2.GetLength(0);
        int cols = grid2.GetLength(1);

        bool[,] visited = new bool[rows, cols];
        int count = 0;
        for(int i=0; i<rows; i++)
        {
            for(int j=0; j<cols; j++)
            {
                if(grid2[i,j] == '1' && !visited[i,j])
                {
                    dfs(grid2, i,j,visited);
                    count++;
                }
            }
        }
        return count;
    }

    private static void dfs(char[,] grid, int r, int c, bool[,] visited)
    {
        int[] rowsAdd = [-1, 1, 0, 0]; // Which all rows to be traversed
        int[] colsAdd = [0, 0, -1, 1]; // which all columns to be traversed
        visited[r,c] = true;
        for(int k=0;k < 4;k++)
        {
            int new_r = r + rowsAdd[k];
            int new_c = c + colsAdd[k];
            if(CanIncludeInDfs(grid, new_r,new_c,visited))
                dfs(grid, new_r,new_c,visited);
        }
    }
    private static bool CanIncludeInDfs(char[,] grid, int r, int c, bool[,] visited)
    {
        int m = grid.GetLength(0);
        int n = grid.GetLength(1);
        return r >= 0 && r < m && c >= 0 && c < n && grid[r,c] =='1' && !visited[r,c];
    }
    private static T[,] ToMultidimensionalArray<T>(T[][] jagged)
    {
        if (jagged.Length == 0 || jagged.Any(row => row.Length != jagged[0].Length))
        {
            throw new ArgumentException("All rows in the jagged array must have the same length.");
        }

        int rows = jagged.Length;
        int cols = jagged[0].Length;
        T[,] multi = new T[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                multi[i, j] = jagged[i][j];
            }
        }
        return multi;
    }

    public static int count_islands(List<List<int>> matrix) 
    {
        // Write your code here.
        int rows = matrix.Count;
        int columns = matrix[0].Count;
        bool[,] visited = new bool[rows,columns];
        int count = 0;
        for(int i=0; i< rows; i++)
        {
            for(int j=0; j< columns; j++)
            {
                if(matrix[i][j] == 1 && !visited[i,j])
                {
                    count++;
                    IslandTraversal(visited,matrix,i,j,rows,columns);
                }
            }
        }
        return count;
    }
    
    private static void IslandTraversal(bool[,] visited, List<List<int>> matrix, int r, int c, int rows, int cols)
    {
        //These 2 arrays give all possible combinations of coordinates to which we can go from current matrix element.
        // combining each element from rowsarray to corresponding element in colsarray gives different coordinates
        // E.g. -1,-1 means diagonal movements.
        int[] rowsArray = new int[8]{-1,-1,-1,0,1,1,1,0};
        int[] colsArray =new int[8]{-1,0,1,1,1,0,-1,-1};
        visited[r,c] = true;
        for(int i=0; i< 8; i++)
        {
            int new_r = r + rowsArray[i];
            int new_c = c + colsArray[i];
            // new row and col should not be out of bounds
            // new row and col should have matrix value of 1
            // new row and col matrix value should not have been visited already.
            if(new_r >= 0 && new_r < rows && new_c >= 0 && new_c < cols && matrix[new_r][new_c] == 1 && !visited[new_r,new_c])
                IslandTraversal(visited,matrix,new_r,new_c,rows,cols);
        }
    }
}
