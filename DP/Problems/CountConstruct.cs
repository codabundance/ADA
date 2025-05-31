using System;
using System.Security.Principal;

namespace DP.Problems;
/*
Given a target word and a dictionary of words. Return number of ways the target can be formed by words in the dictioanry
*/
public class CountConstruct
{
    public static int CountConstructBruteForce(string target, List<string> words)
    {
        if (target.Length == 0) return 1; // We can construct a word of length 0 in one way, by choosing nothing
        int count = 0;
        foreach (string word in words)
        {
            if (target.StartsWith(word))
            {
                var suffix = target[(word.Length - 1)..];
                count += CountConstructBruteForce(suffix, words);
            }
        }
        return count;
    }
    public static int CountConstructMemo(string target, List<string> words, Dictionary<string, int> memo)
    {
        if(memo.TryGetValue(target, out int value))
           return value;
        if (target.Length == 0) return 1; // We can construct a word of length 0 in one way, by choosing nothing
        int count = 0;
        foreach (string word in words)
        {
            if (target.StartsWith(word))
            {
                var suffix = target[(word.Length - 1)..];
                count += CountConstructMemo(suffix, words, memo);
            }
        }
        memo[target] = count;
        return count;
    }
}
