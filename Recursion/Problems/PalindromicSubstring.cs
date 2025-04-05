using System;

namespace Recursion;
/*
Find all palindromic decompositions of a given string s.

A palindromic decomposition of string is a decomposition of the string into substrings, such that all those substrings are valid palindromes.

Example
{
"s": "abracadabra"
}
Output:

["a|b|r|a|c|ada|b|r|a", "a|b|r|aca|d|a|b|r|a", "a|b|r|a|c|a|d|a|b|r|a"]
*/
public class PalindromicSubstring
{
    public List<string> generate_palindromic_decompositions(string s) 
    {
        // Write your code here.
        List<string> answer = [];
        List<string> result = [];
        // we dont want solution to be empty but to contain the first charachter of string always As it should start from there.
        Generate_all_permutations(result,s[1..],0,s[0].ToString());
        foreach(string str in result)
        {
            string [] splittedarray = str.Split('|');
            bool IsPalindromicString = true;
            foreach(string str2 in splittedarray)
            {
                if(!IsPalindrome(str2))
                    IsPalindromicString = false;
            }
            if(IsPalindromicString)
                answer.Add(str);
        }
        return answer;
    }
    public List<string> generate_palindromic_decompositions_1(string s) 
    {
        // Write your code here.
        List<string> result = [];
        // we dont want solution to be empty but to contain the first charachter of string always As it should start from there.
        Generate_all_permutations_1(result,s[1..],0,s[0].ToString());
        return result;
    }
    
    private static void Generate_all_permutations(List<string> result,string problem, int index, string slate)
    {
        // generate all decompositions of the string
        // Let the string be "abracadabra"
        // The leftmost extreme ecomposition would be a|b|r|a|c|a|d|a|b|r|a
        // The rightmost extreme decomposition would be abracadabra
        // We need to find the decompositions in which all of the substrings are palindrome.
        // For each charachter of string we have 2 choices - either put a | or put a blank.
        if(problem.Length == index)
        {
            result.Add(slate);
            return;
        }
        
        // New Problem need to be crated. Remember in case of Permutation we cannot manipulate indices as we need to travel back
        // In combinations we can do that because once in move one step ahead we dont need to come back to the prevousl element.
        // New solution will have 2 choices now - one by adding a "|" and another by adding nothing.
        Generate_all_permutations(result, problem, index+1, slate+"|"+problem[index]);
        Generate_all_permutations(result, problem, index+1, slate+problem[index]);
    }
    private static void Generate_all_permutations_1(List<string> result,string problem, int index, string slate)
    {
        // generate all decompositions of the string
        // Let the string be "abracadabra"
        // The leftmost extreme ecomposition would be a|b|r|a|c|a|d|a|b|r|a
        // The rightmost extreme decomposition would be abracadabra
        // We need to find the decompositions in which all of the substrings are palindrome.
        // For each charachter of string we have 2 choices - either put a | or put a blank.
        if(problem.Length == index)
        {
            if(IsPalindromicDecomposition(slate))
                result.Add(slate);
            return;
        }
        
        // New Problem need to be crated. Remember in case of Permutation we cannot manipulate indices as we need to travel back
        // In combinations we can do that because once in move one step ahead we dont need to come back to the prevousl element.
        // New solution will have 2 choices now - one by adding a "|" and another by adding nothing.
        Generate_all_permutations_1(result, problem, index+1, slate+"|"+problem[index]);
        Generate_all_permutations_1(result, problem, index+1, slate+problem[index]);
    }
    private static bool IsPalindromicDecomposition(string slate)
    {
        string [] splittedarray = slate.Split('|');
        bool IsPalindromicString = true;
        foreach(string str2 in splittedarray)
        {
            if(!IsPalindrome(str2))
                IsPalindromicString = false;
        }
        return IsPalindromicString;
    }
    private static bool IsPalindrome(string str)
    {
        return str.SequenceEqual(str.Reverse());
    }
}

public class PalindromicDecomposition
{
    public List<string> GeneratePalindromicDecompositions(string s)
    {
        List<string> result = [];
        List<string> currentPartition = [];

        Backtrack(s, 0, currentPartition, result);
        return result;
    }

    private void Backtrack(string s, int start, List<string> currentPartition, List<string> result)
    {
        if (start == s.Length)
        {
            result.Add(string.Join("|", currentPartition));
            return;
        }

        for (int end = start; end < s.Length; end++)
        {
            if (IsPalindrome(s, start, end))
            {
                currentPartition.Add(s.Substring(start, end - start + 1));
                Backtrack(s, end + 1, currentPartition, result);
                currentPartition.RemoveAt(currentPartition.Count - 1); // Backtrack
            }
        }
    }

    private bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
}
