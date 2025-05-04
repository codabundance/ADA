using System;

namespace DP.Problems;

public class LongestCommonSubsequence
{
    public int LongestCommonSubs(string text1, string text2) 
    {
        int m = text1.Length;
        int n = text2.Length;
        HashSet<int> map = [];
        return LCS(text1,text2,0,0,map);
    }

    private static int LCS(string s1, string s2, int i, int j, HashSet<int> map)
    {
        if(i == s1.Length || j == s2.Length )
            return 0;
        //check if already contained in memo and return
        if(s1[i] == s2[j])
            return 1 + LCS(s1, s2,i+1, j+1,map);
            //add to memo here
        else
            return Math.Max(LCS(s1, s2,i+1,j,map), LCS(s1, s2,i, j+1,map));
            //add to memo here.
    }
}
