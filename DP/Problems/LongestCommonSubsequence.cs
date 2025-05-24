using System;
using System.Runtime.CompilerServices;

namespace DP.Problems;

public class LongestCommonSubsequence
{
    public int LongestCommonSubs(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;
        int[,] map = new int[text1.Length, text2.Length];
        return LCSTopDown(text1, text2, 0, 0, map);
    }

    private static int LCSTopDown(string s1, string s2, int i, int j, int[,] memo)
    {
        if (i == s1.Length || j == s2.Length)
            return 0;
        if (memo[i, j] != 0)
            return memo[i, j];
        // If both the charachters are same, then move both the pointers forward
        if (s1[i] == s2[j])
        {
            var val = 1 + LCSTopDown(s1, s2, i + 1, j + 1, memo);
            memo[i, j] = val;
            return val;
        }
        else
        {
            //if both charachters are different, then we need to see all possibilities
            // So, we take first one (i+1) then we take second one (j+1) and explore
            // We find Max of both of these and save to memo.
            var val = Math.Max(LCSTopDown(s1, s2, i + 1, j, memo), LCSTopDown(s1, s2, i, j + 1, memo));
            memo[i, j] = val;
            return val;
        }
    }

    // Approach : As we have 2 strings here, we need to have a 2D array as DP
    // DP[i][j] = length of longest common subsequence till we have travelled length i in string S1 and length j in string S2
    // If we fill this table up to m and n (where m is the length of S1 and n is length of S2), then we would get the LCS for S1 and S2 at 
    // dp[m,n].
    // To calculate LCS at each length, we know that if S1[i] == S1[j] then LCS till previous value + 1
    // If S1[i] != S2[j] then we have the value as previous value only, no increment
    // Base case - dp[0][0] represents both strings length 0, so value = 0
    // Base Case - dp[i][0] represents S2 is of length 0 so LCS will be 0
    // Base Case - dp[0][j] represents S1 is of length 0, so LCS will be 0.
    private static int LCSBottomUp(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i <= m; i++)
            dp[i, 0] = 0;
        for (int j = 0; j <= n; j++)
            dp[0, j] = 0;
        for (int k = 1; k <= m; k++)
        {
            for (int p = 1; p <= n; p++)
            {
                if (text1[k - 1] == text2[p - 1])
                    dp[k, p] = dp[k - 1, p - 1] + 1;
                else
                    dp[k, p] = Math.Max(dp[k - 1, p], dp[k, p - 1]);
            }
        }
        return dp[m, n];
    }
}
/*✅ Case 1: text1[k-1] == text2[p-1]
dp[k,p] = dp[k-1,p-1] + 1;
📌 Intuition:
The last characters match, so they can extend the LCS.

Whatever the LCS was between the shorter strings (text1[0..k-2] and text2[0..p-2]), we can now add 1 more to that, because the characters text1[k-1] and text2[p-1] are the same and can be part of the LCS.

💡 Insight:
Think of it like: "Since these two characters match, let’s count them in, and look at the best LCS we had before these characters."

❌ Case 2: text1[k-1] != text2[p-1]
dp[k,p] = Math.Max(dp[k-1,p], dp[k,p-1]);
📌 Intuition:
The current characters don’t match, so we can’t include both.

So we must make a choice: ignore one character and take the better of:

dp[k-1,p]: Ignore text1[k-1]

dp[k,p-1]: Ignore text2[p-1]

💡 Insight:
You’re asking: “If I can’t use these two characters together, what’s the best LCS I can get by ignoring one of them?”

You explore both paths, and pick the one that gives you the maximum LCS length.

🔍 Deep Analogy:
Imagine you're walking on a grid (your dp table). At each cell [k,p], you can think:

“Can I walk diagonally (meaning a match and progress both strings)?”

If not, you walk left or up, taking the best LCS from either dropping one character from text1 or text2.
}*/
