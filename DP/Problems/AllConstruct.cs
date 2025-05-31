using System;

namespace DP.Problems;
/*
Given a target word and a dictionary of words. Return all possible ways the target can be formed by words in the dictioanry
*/
public class AllConstruct
{
    public static List<List<string>> AllConstructBruteForce(string target, List<string> words)
    {
        if (target.Length == 0) return [[]];
        List<List<string>> result = [];
        foreach (var word in words)
        {
            if (target.StartsWith(word))
            {
                string suffix = target[(word.Length - 1)..];
                // This returns a List of list of strings which has all possible ways of creating suffix, so we will need to
                // add the word to each subarray that comes to present iteration before returning it
                var returnVal = AllConstructBruteForce(suffix, words);
                for (int i = 0; i < returnVal.Count; i++)
                {
                    returnVal[i].Add(word);
                    result.Add(returnVal[i]);
                }
            }
        }
        return result;
    }

    public static List<List<string>> AllConstructMemo(string target, List<string> words, Dictionary<string, List<List<string>>> memo)
    {
        if(memo.TryGetValue(target, out List<List<string>>? value))
            return value;
        if (target.Length == 0) return [[]];
        List<List<string>> result = [];
        foreach (var word in words)
        {
            if (target.StartsWith(word))
            {
                string suffix = target[(word.Length - 1)..];
                // This returns a List of list of strings which has all possible ways of creating suffix, so we will need to
                // add the word to each subarray that comes to present iteration before returning it
                var returnVal = AllConstructMemo(suffix, words, memo);
                // Iterate through all the internal Lists of string and add word to each of them
                for (int i = 0; i < returnVal.Count; i++)
                {
                    returnVal[i].Add(word);
                    //Add it finally to the result
                    result.Add(returnVal[i]);
                }
            }
        }
        memo[target] = result;
        return result;
    }
}
