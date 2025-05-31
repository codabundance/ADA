using System;
/*
Given an array s of n integers, partition it into two non-empty subsets, s1 and s2, such that the sum of all elements in s1 is equal to 
the sum of all elements in s2. Return a boolean array of size n, where i-th element is 1 if i-th element of s belongs to s1 and 0 if it 
belongs to s2.

Example
{
"s": [10, -3, 7, 2, 1, 3]
}
Output:

[1, 1, 0, 0, 0, 1]
There are multiple partitionings, where s1 sums up to 10 and s2 sums up to 10; they are all correct answers:

s1 = [ 10 , -3 , 3 ] and s2 = [ 7 , 2 , 1 ] (Sample output)

s1 = [ 7 , 2 , 1 ] and s2 = [ 10 , -3 , 3 ]

s1 = [10] and s2 = [-3, 3, 7, 2, 1]

s1 = [-3, 3, 7, 2, 1] and s2 = [10]

s1 = [10, -3, 2, 1] and s2 = [7, 3]

s1 = [7, 3] and s2 = [10, -3, 2, 1].


*/

namespace DP.Problems;
//Approach 1: Recursive approach - Form all possible subsets and see if sum of any 2 of them is equal and return that. As we need only one
// solution, this would work. Also order is not important(all possible subsets), repetition not allowed (no for loop)
// this will have exponential complexity

// Approach 2: will be memoization
public class EqualSubsetProblem
{
    public static List<bool> Equal_subset_sum_partition(List<int> s)
    {
        // Write your code here.
        return new List<bool>();
    }

    private static void Helper(List<int> s, int current, List<int> slate, List<List<int>> result)
    {
        if (current == s.Count)
        {
            result.Add(new List<int>(slate));
            return;
        }
        slate.Add(s[current]);
        Helper(s, current + 1, slate, result);
        slate.RemoveAt(slate.Count - 1);
        Helper(s, current, slate, result);
    }
}
