/*
Write a function to sort a given integer array nums in-place (and without the built-in sort function), 
where the array contains n integers that are either 0, 1, and 2 and represent the colors red, white, and blue. 
Arrange the objects so that same-colored ones are adjacent, in the order of red, white, and blue (0, 1, 2).
*/
// This problem has other falvors as well such as Dutch National Flag.
public class Solution {
    public void sortColors(int[] nums) {
        // Your code goes here
        // 0 = Red, 1 = White, 2= blue
        int n= nums.Length;
        // first move all zeroes to the left i.e swap when you get a zero
        // Then move all 1s to the left in a second loop. By default 2s will be placed correctly
        // this will be O(n) because we are running 2 independent loops
        int left = 0;
        int right = 0;
        while(right < n)
        {
            if(nums[right] == 0)
            {
                swap(nums, left, right);
                left++;
            }
            right++;
        }
        // Let's move 1s
        right = left;
        while(right < n)
        {
            if(nums[right] == 1)
            {
                swap(nums, left, right);
                left++;
            }
            right++;
        }
    }

    public void sortColors2(int[] nums)
    {
        // This approach we need to create 4 zones - 0-left (all zeroes), left- middle(all ones), middle-right(all unsorted), right-end(all 2s)
        // Initially left, middle will start from 0 and right will start from end
        // We will use middle to scan the array. If it finds a 0, swap the value with left and increment left and middle
        // if it finds a 1, then only increment middle. We dont increment left because 1 is already in correct position, we just need to expand the area between left and middle
        // if we get a 2, then we swap it with right and decrease right and increase middle
        // loop breaks when middle passes right, that means our unsorted area is done.
        int n = nums.Length;
        int left = 0;
        int right = n-1;
        int medium = 0;
        // we have to manipulate the scan index variable as well, so using for loop becomes difficult
        while(medium <= right)
        {
            if(nums[medium] == 0)
            {
                swap(nums, medium, left);
                left++;
                medium++;
            }
            else if(nums[medium] == 1) // we expand the 1 zone
                medium++;
            else // values is 2
            {
                swap(nums, medium, right);
                right--; // we dont increase medium in this case because We decremented right after swapping. and the value we have swapped is a value from unsorted zone. 
            }
        }
    }

    private void swap(int[] nums, int k, int l)
    {
        int temp = nums[k];
        nums[k] = nums[l];
        nums[l] = temp;
    }
}