using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace Recursion;

public class Permutations
{
    public IList<IList<int>> Permute(int[] nums) 
    {
        IList<IList<int>> result = [];
        Permute_Help(nums.ToList(),result,[]);
        return result.ToList();
    }

    private static void Permute_Help(IList<int> nums, IList<IList<int>> result, IList<int> slate)
    {
        //we cannot use slate count == arr.count because arr.count keeps decreasing. We could have used size of array as an argument N.
        if(nums.Count == 0)
        {
            result.Add(slate);
            return;
        }
        // Why we need loop here if we have recursion
        // It's like fill in the blanks, we fix the first item i.e. i=0 at first place and then recurse
        // We then fix the second place with 1st among remaining n-1 items i.e. i=1
        // So we need loop everytime to iterate over all the remaining elements in problem and fix them one by one
        // So recursion takes us to one after another places to fill, and loop gives us all possible values that can be filled.
        for(int i=0;i < nums.Count;i++)
        {
            // create a copy because we want to maintain the same state when control comes back after recursion
            // If we dont make a copy, the problem and solution both will have the state what subsequent recursion calls have created
            List<int> new_slate =[..slate]; 
            new_slate.Add(nums[i]);
            List<int> new_nums = [.. nums];
            new_nums.RemoveAt(i);
            Permute_Help(new_nums, result, new_slate);
        }
    }

    public IList<IList<int>> PermuteUnique(int[] nums) 
    {
        IList<IList<int>> result = [];
        Permute_Help_Unique(nums.ToList(),result,[]);
        return result.ToList();
    }

    private static void Permute_Help_Unique(IList<int> nums, IList<IList<int>> result, IList<int> slate)
    {
        if(nums.Count == 0)
        { 
            bool IsDuplicate = false;
            for(int j=0;j<result.Count;j++)
            {
                if(IsCopy(slate,result[j]))
                    IsDuplicate = true;
            }
            if(!IsDuplicate)
                result.Add(slate);
            return;
        }
        for(int i=0;i < nums.Count;i++)
        {
            List<int> new_slate =[..slate]; // create a copy
            new_slate.Add(nums[i]);
            List<int> new_nums = [.. nums]; // create a copy
            new_nums.RemoveAt(i);
            Permute_Help_Unique(new_nums, result, new_slate);
        }
    }

    private static bool IsCopy(IList<int> L1, IList<int> L2)
    {
        for(int i = 0; i< L1.Count; i++)
        {
            if(L1[i] != L2[i])
                return false;
        }
        return true;
    }
}
