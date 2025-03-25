using System;

namespace Sorting.Problems;
/*
Problem: Given a list of words from the book Julius Caesar, and dictionary with each word and then the pages on which that word would appear sorted in ascending order.
Write code to perform 2 operationd AND and OR such that 
    AND Operation gives the intersection of page numbers
    OR operation gives the Union of page numbers

Approach : The best approach is to go through both the arrays using 2 pointers. If elements at both the pointers are equal, we add them to the list. If elements are not equal
for AND - if ith element is larger, we need to move the j pointer and vice versa, because the array is sorted and We only need to add if elements are equal.
for OR - if ith element is larger, add the jth element to the result, and increment j and vice versa.

Complexity 
Time - O(m+n), Space - O(1) 
*/
public class AndOrImplementationDictionary
{
    public void AND(List<int> julius, List<int> caesar)
    {
        List<int> result = [];
        int i=0, j=0;
        while(i < julius.Count && j < caesar.Count)
        {
            if(julius[i]==caesar[j])
            {
                result.Add(julius[i]);
                i++;j++;
            }
            else if(julius[i] > caesar[j])
            {
                j++;
            }
            else if(julius[i]< caesar[j])
            {
                i++;
            }
        }
        Console.WriteLine(string.Join(", ", result));
    }
    public void OR(List<int> julius, List<int> caesar)
    {
        List<int> result = [];
        int i=0, j=0;
        while(i < julius.Count && j < caesar.Count)
        {
            if(julius[i]==caesar[j])
            {
                result.Add(julius[i]);
                i++;j++;
            }
            else if(julius[i] > caesar[j])
            {
                result.Add(caesar[j]);
                j++;
            }
            else if(julius[i] < caesar[j])
            {
                result.Add(julius[i]);
                i++;
            }
        }
        while(i < julius.Count)
        {
            result.Add(julius[i]);
            i++;
        }
        while(j < caesar.Count)
        {
            result.Add(caesar[j]);
            j++;
        }
        Console.WriteLine(string.Join(",",result));
    }
}
