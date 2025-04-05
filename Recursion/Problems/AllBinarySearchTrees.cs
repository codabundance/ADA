using System;
using System.Net;

namespace Recursion;
/*Write a function that returns the number of distinct binary search trees that can be constructed with n nodes. 
For the purpose of this exercise, do solve the problem using recursion first even if you see some non-recursive approaches.*/
public class AllBinarySearchTrees
{
    // Approach 1: try generating all possible permutations of given numbers and see if any permutation represents a BST
    // This is difficult approach because finding whether elements are BST or not is difficult
    // Also the numbers do not matter to decide whether it is a BST or not, because any combination of numbers can be said to be a BST.
    // If you choose one number as root, then other numbers either become left subtree or right subtree. This includes empty left/right
    public static int GetAllBinarySearchTreesCount(int n)
    {
        int Count = 0;
        List<int> problem = [];
        List<int> solution = [];
        List<List<int>> result = [];
        for(int i = 0; i < n ; i++)
        {
            problem.Add(i);
        }
        GetBSTHelper(problem,solution, result);
        foreach(List<int> val in result)
        {
            if(IsBST(val))
              Count++;
        }
        return Count;
    }

    private static bool IsBST(List<int> tree)
    {
        // logic here
        return true;
    }

    private static void GetBSTHelper(List<int> problem, List<int> solution, List<List<int>> result)
    {
        for(int idx = 0; idx < problem.Count; idx++)
        {
            if(problem.Count == 0)
            {
                List<int> copy = solution.ToList();
                result.Add(copy);
                return;
            }
            _ = problem.Remove(problem[idx]);
            solution.Add(problem[idx]);
            GetBSTHelper(problem, solution, result);
        }
    }

// Approach 2: Consider each element as root and divide into left and right subtree
// Every possible subtree after division can again be checked if it is BST or not
// this continues until we have 0 or 1 node for which we only havs 1 BST possible. This becomes base case of recursion
// Please note that what values are there in the array does not matter for BST or not. Any combination of values can form a BST.
// So we explore all possible combinations of root, left and right subtree by using divide and conquer.
     public static long how_many_bsts(int n) {
        long answer = 0L;
        if(n == 0 || n == 1)
            return 1L;
        for(int i=0;i<n;i++)
        {
            answer = answer + (how_many_bsts(i)*how_many_bsts(n-i-1));
        }
        return answer;
    }
}
