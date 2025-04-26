using System;
using System.Text;

namespace Recursion.Problems;
/*
Words From Phone Number
Given a seven-digit phone number, return all the character combinations that can be generated 
according to the following mapping:

1-> Nothing
2-> "abc"
3-> "def"
4-> "ghi"
5-> "jkl"
6-> "mno"
7-> "pqrs"
8-> "tuv"
9-> "wxyz"
0-> Nothing

Graph

Return the combinations in the lexicographical order.

Example One
{
"phone_number": "1234567"
}
Output:

[
"adgjmp",
"adgjmq",
"adgjmr",
"adgjms",
"adgjnp",
...
"cfilns",
"cfilop",
"cfiloq",
"cfilor",
"cfilos"
]
First string "adgjmp" in the first line comes from the first characters mapped to digits 2, 3, 4, 5, 6 and 7 
respectively. Since digit 1 maps to nothing, nothing is appended before 'a'. 
Similarly, the fifth string "adgjnp" generated from first characters of 2, 3, 4, 5 
second character of 6 and first character of 7. All combinations generated in such a way must be 
returned in the lexicographical order.
*/

//Approach:
// We create a dictionary of each digit with corresponsing alphabets
// Then we go through each digit in the phone number recursively, the same way we do for subsets
// But instead of adding the phone digit, we recurse over all the corresponding dictionay item and add them one by one
public class AllPhoneNumbers
{
    public static List<string> get_words_from_phone_number(string phone_number) {
        // Write your code here.
        Dictionary<char, string> digitToStrinMapping = new Dictionary<char, string>()
        {
            {'2',"abc"},{'3',"def"},{'4',"ghi"},{'5',"jkl"}, {'6',"mno"},{'7',"pqrs"},{'8',"tuv"},{'9',"wxyz"}
        };
        phone_number= phone_number.Replace("0", "").Replace("1", "");
        List<string> result = new List<string>();
        GenerateStrings(phone_number, digitToStrinMapping, 0,new StringBuilder(),result);
        return result;
    }

    private static void GenerateStrings(string phone_number, Dictionary<char, string> digitToStrinMapping, 
        int index, StringBuilder solution, List<string> result)
    {
        if(solution.Length == phone_number.Length)
        {
            result.Add(solution.ToString());
            return;
        }
        var str = digitToStrinMapping[phone_number[index]];
        foreach(var letter in str.ToCharArray())
        {
            solution.Append(letter);
            GenerateStrings(phone_number, digitToStrinMapping, index+1, solution,result);
            solution.Remove(solution.Length-1, 1);
        }
    }
}
