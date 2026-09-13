public class Solution {
    public int maxSum(int[] nums, int k) {
        // Your code goes here
        /*
        Simple approach: Add the values in the array till the size becomes k
        Once size becomes k, check the running Sum by left++, right++
        if running Sum is greater than Max, replace Max
        if need to return the subarray also then save left and right index of subarray, together with Max sum
        */

        int left = 0;
        int right = 0;
        int maximumSum = Int32.MinValue;
        int runningSum = 0;
        for(right = 0; right < nums.Length; right++)
        {
            runningSum += nums[right];
            if(right-left+1 == k)
            {
                maximumSum = Math.Max(runningSum, maximumSum);
                runningSum -= nums[left];
                left++;
            } 
        }
        return maximumSum;
    }
}