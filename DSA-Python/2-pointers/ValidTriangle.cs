public class Solution {
    public int TriangleNumber(int[] nums) {
        // Your code goes here
        Array.Sort(nums);
        int n= nums.Length;
        int count = 0;
        for(int i=n-1;i>=2;i--) // i>=2 because we need to check triplets so the 0,1,2 inices are needed. We start from n-2 because the condition if a + b > c
        // then all the numbers between a and b will also yield> , only satisfied when we c >b>a
        {
            int left = 0;
            int right = i-1;
            while(left < right)
            {
                if(nums[left] + nums[right] > nums[i]) //this means all the values between left and right will also be greater than nums[i], so count will be all the values
                // between left and right including left
                {
                    count += right - left;
                    right--; // once we know that 'b' will result in valida triangles, we need to see for lower valueo of 'b'
                }
                else // if the a+b sum is smaller than 'c' then we need to increase 'a' to increase a+b sum
                {
                    left++;   
                }
            }
        }
        return count;
    }
}