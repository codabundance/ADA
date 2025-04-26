using System;
using System.Runtime.CompilerServices;

namespace Recursion.Problems;
/*
Given a string that might contain duplicate characters, find all the possible distinct subsets of that string.

Example One
{
"s": "aab"
}
Output:

["", "a", "aa", "aab", "ab", "b"]
Example Two
{
"s": "dc"
}
Output:

["", "c", "cd", "d"]
*/
public class UniqueSubsets
{
    HashSet<char> visited = new HashSet<char>();
    public static List<string> get_distinct_subsets(string s) {
        // Write your code here.
        var result = new List<string>();
        helper(SortString(s),0, string.Empty, result);
        return result;
    }

    private static void helper2(string arr, int index, string sol, List<string> result)
    {
        if(index == arr.Length)
        {
            result.Add(SortString(sol));
            return;
        }
        helper2(arr, index+1, sol+arr[index], result);
        // This while loop restricts the exclusion path if the same elements repeat
        // We have already included and excluded the element in the subsequent subtrees
        // So we dont want to exclude and then include it again, because it would be the same result
        // so once an element is covered, we want to exclude all it's occurrences
        // We have sorted the array so that all duplicates come together to apply this logic
        while(index < arr.Length-1 && arr[index] == arr[index+1])
            index++;
        helper2(arr, index+1, sol, result);
    }
    static string SortString(string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }
    private static void helper(string arr, int index, string sol, List<string> result)
    {
        if(index == arr.Length)
        {
            result.Add(SortString(sol));
            return;
        }
        helper(arr, index+1, sol+arr[index], result);
        while(index < arr.Length-1 && arr[index] == arr[index+1])
            index++;
        helper(arr, index+1, sol, result);
    }
}
