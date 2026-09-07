public class Solution {
    public void MoveZeroes(int[] nums) {
        // Your code goes here
        // 2 pinters - left and right - Left Points to the position where next non zero will be inserted. Right as a scanner
        int n = nums.Length;
        int left = 0;
        int right = 0;
        while(right < n)
        {
            if(nums[right] != 0)
            {
                swap(nums, left, right);
                left++; // increment next insert position by 1.
            }
            right++;
        }

    }
    private void swap(int[] nums, int k, int l)
    {
        int temp = nums[k];
        nums[k] = nums[l];
        nums[l] = temp;
    }
}