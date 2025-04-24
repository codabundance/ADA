using System;

namespace Recursion.Problems;
/*
Given an array of numbers with possible duplicates, return all of its permutations in any order.

Example
{
"arr": [1, 2, 2]
}
Output:

[
[1, 2, 2],
[2, 1, 2],
[2, 2, 1]
]
*/
public class PermutationsDuplicate
{
    public static List<List<int>> get_permutations(List<int> arr) 
    {
        // Write your code here
        var result = new List<List<int>>();
        Helper(arr,[],result);
        return result;
    }

    /*
    Very interesting problem. 
    In Exhaustive search Permutation problems - 
    1. Each recursive call = Every blank that we want to fill
    2. Each Iterative call = Every possible optios for that blank.
    For Duplicate elements we want to restrict the options to Unique values.
    So, for each recursive call (the blank that we are trying to fill) we want to restrict the iterative loop to be on unique options. Thus before
    every iteration we maintain a visited Set, which only gives us the unique values for iteration.

    */

    //Every recursive call to helper corresponds to blank that we want to fill
    // 1st recursive = 1st blank
    // 2nd recursive = 2nd blank and so on....
    private static void Helper(List<int> problem, List<int> solution, List<List<int>> result)
    {
        if(problem.Count == 0)
        {
            var copy = new List<int>(solution);
            result.Add(copy);
            return;
        }
        
        HashSet<int> visited = new();
        for(int i=0; i < problem.Count; i++)
        {
            // Unique options for each blank
            if(!visited.Contains(problem[i]))
            {
                visited.Add(problem[i]);
                var item = problem[i];
                //If we use copies to pass here, then when recursion comes back the problem and solution would be in correct state.
                var new_solution = new List<int>(solution);
                new_solution.Add(item);
                var new_problem = new List<int>(problem);
                new_problem.RemoveAt(i);
                Helper(new_problem, new_solution, result);
                // solution.RemoveAt(solution.Count - 1);
                // problem.Add(item);
            }
        }
    }
    //Leet Code
    public IList<IList<int>> PermuteUnique(int[] nums) 
    {
        IList<IList<int>> result = [];
        Permute_Help_Unique(nums.ToList(),result,[]);
        return result.ToList();
    }

    private static void Permute_Help_Unique(IList<int> problem, IList<IList<int>> result, List<int> solution)
    {
        if(problem.Count == 0)
        {
            var copy = new List<int>(solution);
            result.Add(copy);
            return;
        }
        
        HashSet<int> visited = new();
        for(int i=0; i < problem.Count; i++)
        {
            // Unique options for each blank
            if(!visited.Contains(problem[i]))
            {
                visited.Add(problem[i]);
                var item = problem[i];
                var new_solution = new List<int>(solution);
                new_solution.Add(item);
                var new_problem = new List<int>(problem);
                new_problem.RemoveAt(i);
                Permute_Help_Unique(new_problem, result, new_solution);
            }
        }
    }
}
