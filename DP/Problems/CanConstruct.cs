using System;

namespace DP.Problems;
/*
Given a target word and a dictionary of words. Return true if the target can be formed by words in the dictioanry
*/
public class CanConstruct
{
    // Time = O(pow(n,m)*m) => n = number of words, m = target string length, substring will also be m
    // Space = O(m pow 2)
    public static bool CanConstructBruteForce(List<string> words, string target)
    {
        if (target.Length == 0) return true; // a length 0 string can always be formed.
        foreach (string word in words)// iterate over each word in words
        {
            // this means the given word is a prefix in target. This is required because we dont want to pick internal parts of target
            if (target.StartsWith(word))
            {
                var suffix = target[(word.Length - 1)..];// Take the remaining word after removing the prefix
                //make the recursive call with suffic and check if it returns true
                if (CanConstructBruteForce(words, suffix))
                    return true;
            }
        }
        return false;
    }

    // Time = O(n*m pow 2) => n = number of words, m = target string length, substring will also be m
    // Space = O(m pow 2)
    public static bool CanConstructMemo(List<string> words, string target, Dictionary<string, bool> memo)
    {
        if (memo.TryGetValue(target, out bool value))
            return value;
        if (target.Length == 0) return true; // a length 0 string can always be formed.
        foreach (string word in words)// iterate over each word in words
        {
            // this means the given word is a prefix in target. This is required because we dont want to pick internal parts of target
            if (target.StartsWith(word))
            {
                var suffix = target[(word.Length - 1)..];// Take the remaining word after removing the prefix
                //make the recursive call with suffic and check if it returns true
                if (CanConstructMemo(words, suffix, memo))
                {
                    memo[target] = true;
                    return true;
                }
            }
        }
        memo[target] = false;
        return false;
    }

    //
    public static bool CanConstructTab(List<string> words, string target)
    {
        // DP[i] represents if it is possible to construct the given string's substring of length i.
        bool[] DP = new bool[target.Length + 1];
        DP[0] = true; // Forming string of length 0 is always possible
        for (int i = 1; i <= target.Length; i++)
        {
            foreach (string word in words)
            {
                if (i - word.Length >= 0)
                {
                    if (DP[i - word.Length])
                    {
                        // if the DP value is true at i-word.Length
                        // Then we check that whether adding the current word to the substring at i-word.Length
                        // will give the substring word.length
                        // E.g. if the word is "ab" and i = 2 - Then substring i-2 of target i.e. ""
                        // If we add the word i.e. ab to it, then will it be equal to substring Length of word i.e.2 of target
                        // "" + "ab" = "ab" : true so DP[2]= true
                        // Similarily if i = 3, "a" + "ab" = "abc" // false, so DP[3]= false;
                        var prevstring = target[..(i - word.Length)];
                        var currentString = prevstring + word;
                        var stringToCompare = target[..word.Length];
                        if (currentString == stringToCompare)
                            DP[i] = true;
                    }
                }
            }
        }
        return DP[target.Length];
    }

    //['',a,b,c,d,e,f]   ["ab", "abc, "def","cd", "abcd"]
}
