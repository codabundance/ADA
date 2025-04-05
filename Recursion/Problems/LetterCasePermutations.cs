using System;
using System.Text.RegularExpressions;

namespace Recursion;
/*
Given a string s, you can transform every letter individually to be lowercase or uppercase to create another string.

Return a list of all possible strings we could create. Return the output in any order.

 

Example 1:

Input: s = "a1b2"
Output: ["a1b2","a1B2","A1b2","A1B2"]
Example 2:

Input: s = "3z4"
Output: ["3z4","3Z4"]
*/
public class LetterCasePermutations
{
    public static List<string> GetLetterCasePermutations(string s)
    {
        List<string> result = [];
        LetterCasePermutationsHelper(s,result,"",0);
        return result;
    }

    private static void LetterCasePermutationsHelper(string sourceString, List<string> results, string slate, int index)
    {
        if(index == sourceString.Length)
        {
            results.Add(slate);
            return;
        }
        if(Char.IsLetter(sourceString[index]))
        {
            LetterCasePermutationsHelper(sourceString,results,slate + Char.ToUpper(sourceString[index]), index+1);
            LetterCasePermutationsHelper(sourceString,results,slate + Char.ToLower(sourceString[index]), index+1);
        }
        else
        {
            // recursive call - just go to next character
            LetterCasePermutationsHelper(sourceString, results,slate + sourceString[index],index+1);
        }
    }
}
