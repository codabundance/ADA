using System;

namespace Sorting.Problems;
/*
Problem: Given a list of words from the book Julius Caesar, and dictionary with each word and then the pages on which that word would appear sorted in ascending order.
Write code to perform 2 operationd AND and OR such that 
    AND Operation gives the intersection of page numbers
    OR operation gives the Union of page numbers

Approach 1 : The best approach is to go through both the arrays using 2 pointers. If elements at both the pointers are equal, we add them to the list. If elements are not equal
for AND - if ith element is larger, we need to move the j pointer and vice versa, because the array is sorted and We only need to add if elements are equal.
for OR - if ith element is larger, add the jth element to the result, and increment j and vice versa.
Complexity 
Time - O(m+n), Space - O(1) 

Approach 2: We can also have a binary search approach where we try to find one element in the second array using binary search.
Time - O(nlog n), Space - O(1)

Comparison
Take cases where N << M. E.g. N = 100, M = 10 pow 6.
    Binary Search = O(n log n) = 100* log(10 pow 6) = 100*6*log 10 = 100 * 6 * 3.32 = 2100
    Near Sweep = O(m+n) = 100+10 pow 6 = 1000000
    So in this case binary search performs better.
Case When N=M, Near sweep is better.

Conclusion - If you have a scenario where one array is small, the binary search approach works good, because we can try finding the elements of first array
into the second array(which is large) and binary search overall reduces the complexity. But if we do Near sweep then even though the 1st array is small
the algorithm will go through the entire array to find equal elements. But, can't we break? - We can break, but consider the example where the smaller array
has an element greater than all elements in the larger array
E.g. - 
L1 = [10, 12, 11, 13, 15,...............,123456] // Length is 100000
L2 = [100000,200000,300000,300001, 400000]

Now in this case the pointer in 1st array will continue till last i.e. all 100000 elements and we cannot break.
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
