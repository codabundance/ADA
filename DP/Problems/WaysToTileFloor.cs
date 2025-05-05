using System;

namespace DP.Problems;
/*
Given a floor of dimensions 2 x n and tiles of dimensions 2 x 1, the task is to find the number of ways the floor can be tiled. A tile can either be placed horizontally i.e as a 1 x 2 tile or vertically i.e as 2 x 1 tile. 

Examples :

Input: n = 3
Output: 3
Explanation: We need 3 tiles to tile the boardof size  2 x 3. 
We can tile in following ways:
1) Place all 3 tiles vertically. 
2) Place first tile verticallyand remaining 2 tiles horizontally.
3) Place first 2 tiles horizontally and remaining tiles vertically.
Input: n = 4
Output: 5
Explanation: For a 2 x 4 board, there are 5 ways
1) All 4 vertical
2) All 4 horizontal
3) First 2 vertical, remaining 2 horizontal.
4) First 2 horizontal, remaining2 vertical.
5) Corner 2 vertical, middle 2 horizontal.
Input: n = 2
Output: 2

*/
public class WaysToTileFloor
{
    public int numberOfWays(int n) {
        // code here
        int [] table = new int[n+1];
        table[0] = 0;
        table[1] = 1;
        table[2] = 2;
        // recurrence eq is like f(n) = f(n-1)+f(n-2)
        // For nth fill, we have 2 options
        // (n-1)th filled with vertical, so nth can be filled in one way
        // (n-2)th filled with horizontal, so nth can be filled in another way
        // So total ways can be f(n-1) + f(n-2)
        // meaning total ways of tiles for n-1th and total ways of tiles till n-2th
        for(int i=0; i< n; i++)
        {
            table[i] = table[i-1]+table[i-2];
        }
        return table[n];
    }
}
