using System;

namespace DP.Problems;

public class LongestCommonSubsequence
{
    public int LongestCommonSubs(string text1, string text2) 
    {
        int m = text1.Length;
        int n = text2.Length;
        int[,] map = new int[text1.Length, text2.Length];
        return LCS(text1,text2,0,0,map);
    }

    private static int LCS(string s1, string s2, int i, int j, int[,] memo)
    {
        if(i == s1.Length || j == s2.Length)
            return 0;
        if(memo[i,j] != 0)
            return memo[i,j];
        // If both the charachters are same, then move both the pointers forward
        if(s1[i] == s2[j])
        {
            var val = 1 + LCS(s1, s2,i+1, j+1,memo);
            memo[i,j] = val;
            return val;
        }
        else
        {
            //if both charachters are different, then we need to see all possibilities
            // So, we take first one (i+1) then we take second one (j+1) and explore
            // We find Max of both of these and save to memo.
            var val = Math.Max(LCS(s1, s2,i+1,j,memo), LCS(s1, s2,i, j+1,memo));
            memo[i,j] = val;
            return val;
        }
    }
}
