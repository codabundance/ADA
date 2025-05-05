using System;
using System.Globalization;

namespace DP.Problems;
/*
Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

You have the following three operations permitted on a word:

Insert a character
Delete a character
Replace a character
 

Example 1:

Input: word1 = "horse", word2 = "ros"
Output: 3
Explanation: 
horse -> rorse (replace 'h' with 'r')
rorse -> rose (remove 'r')
rose -> ros (remove 'e')
Example 2:

Input: word1 = "intention", word2 = "execution"
Output: 5
Explanation: 
intention -> inention (remove 't')
inention -> enention (replace 'i' with 'e')
enention -> exention (replace 'n' with 'x')
exention -> exection (replace 'n' with 'c')
exection -> execution (insert 'u')
*/
public class EditDistance
{
    public int MinDistance(string word1, string word2) 
    {
        int [,] memo = new int[word1.Length, word2.Length];
        return Helper(word1, word2,0,0,memo);
    }

    private static int Helper(string S1, string S2, int i, int j, int[,] memo)
    {
        if(i==S1.Length)
        {
            return S2.Length - j;
        }
        if(j == S2.Length)
        {
            return S1.Length - i;
        }
        if(memo[i,j] != 0)
        {
            return memo[i,j];
        }
        if(S1[i] == S2[j])
        {
           var val = Helper(S1, S2, i+1, j+1,memo);
           memo[i,j] = val;
           return val;
        }
        else
        {
            // if the chars are different, then we can do 3 things
            // Insert char in first string from second string - increment i and not j
            // Delete char in first string  - increment j and not i
            // Replace char in first string from second string - increment j and i.
            var val =  1 + Math.Min(Math.Min(Helper(S1, S2, i+1, j,memo),
            Helper(S1, S2, i, j+1,memo)),
            Helper(S1, S2, i+1, j+1,memo));

            memo[i,j] = val;
            return val;
        }
    }

    private static int MinDistance2(string word1, string word2) 
    {
        int [,] table = new int[word1.Length+1, word2.Length+1];
        for(int i=0;i<= word1.Length;i++)
        {
            table[0,i] = i;
        }
        for(int j=0;j<= word2.Length;j++)
        {
            table[0,j] = j;
        }
        for(int row = 1; row <=word1.Length; row++)
        {
            for(int col = 1; col <= word2.Length; col++)
            {
                //If both the charachters are same then no action required, so move the pointers forward
                if(word1[row-1] == word2[col-1])
                   table[row,col] = table[row-1,col-1];
                else
                // if the chars are different, then we can do 3 things
                // Insert char in first string from second string - increment i and not j
                // Delete char in first string  - increment j and not i
                // Replace char in first string from second string - increment j and i.
                    table[row,col] = Math.Min(
                    Math.Min(table[row-1,col-1], table[row, col-1]),
                    table[row-1,col]);

            }
        }
        return table[word1.Length-1,word2.Length-1];
    }
}
