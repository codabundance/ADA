using System;

namespace Recursion;

public class RunningSum
{
    public static bool Check_if_sum_possible(List<long> arr, long k) {
        // Write your code here.
        var result = Helper(arr, k,0, 0, 0);
        return result;
    }
    
    private static bool Helper(List<long> arr, long k, int i, long running_length, long running_sum)
    {
        // assuming array can have negative integers.
        // Running length is important to handle the K=0 use case. If running_length is greater than 0, that means atleast one 
        // recursion node has been formed. This means Sum will be 0 because we have added negative numbers in recursive tree
        // Not because of initial case where we pass 0 from calling function.
        if(running_sum == k && running_length > 0)
            return true;
        if(i == arr.Count)
            return false;
        bool res1 = Helper(arr,k,i+1,running_length,running_sum);
        if(res1)
            return true;
        bool res2 = Helper(arr,k,i+1,running_length + 1,running_sum + arr[i]);
        if(res2)
            return true;
        return false;
    }
}
