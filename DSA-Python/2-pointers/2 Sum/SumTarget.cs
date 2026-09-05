public class Solution {
    public bool twoSum(int[] nums, int target) {
        // Your code goes here
        // nums is already sorted
        int left = 0;
        int right = nums.Length - 1;
        while(left < right)
        {
            int sum = nums[left]+ nums[right];
            if(sum == target)
                return true;
            else if (sum < target) left++;
            else right--;
        }
        return false;
    }
}