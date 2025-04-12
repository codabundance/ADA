using System;

namespace Sorting.Problems;
/*
Given an array with K different charachters 
Rearrange the array such that all the same charachters are together
*/
public class MultiplePartitions
{
    public static string RearrangeSameCharachtersTogether(string s, List<char> chars)
    {
        List<char> newChars = s.ToCharArray().ToList();
        int idx = 0;
        foreach (char c in chars)
        {
            //idx will get updated with the last element index in current partition.
            idx = Partition(newChars, idx,c);
        }
        return new string(newChars.ToArray());
    }

    // This method would rearrange the first charachter in the chars array to the left, 
    // and then return the index of last element in that partition
    private static int Partition(List<char> s, int searchindex, char c)
    {
        int explorer = searchindex + 1;
        while(explorer < s.Count)
        {
            if(s[explorer] == c)
            {
                searchindex++;
                Swap(s, explorer, searchindex);
            }
            explorer++;
        }
        return searchindex;
    }

    private static void Swap(List<char> str, int index1, int index2)
    {
        (str[index2], str[index1]) = (str[index1], str[index2]);
    }
}
