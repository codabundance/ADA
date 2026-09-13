public class Solution {
    public int TrappingWater(int[] height) {
        // Your code goes here
        /*2 things we need to do
        1. Find out if water can be tapped at a given index. For this, there should be 2 walls - one to the left and one to the right
        which are higher than current index
        2. Second how much water can be contained at the current index - Min(leftMax, rightMax) - height

        One approach is to go to each index from left to right
        - Keep Track of left Max, but calculate right Max for each index (go through each value in array)
        - For each index calculate the water by above formula
        - This will be O(n2)

        Second approach is to optimize this only
        - Instead of going through index left to right, let's take 2 pointers. One to the left and one to the right
        - Now each pointer will track the max value to the left and to the right respectively
        - If the left Max is smaller than right max, this means that for the index next to leftMax (left+1), we know that the max boundary is left Max
        - If the right Max is smaller than left max, then for the index next to rightMax (right -1), we know that the max boundary is right Max
        - Now once we move to Left +1 or right -1 in either case it can be possible that the height is greater than left Max or rigth Max. So that means
        we cannot hold water there, so we need to move to the left or to the right unless we find an index whose height is less than either of them. Also 
        in the process, the leftMax and RightMax will also keep updating based on heights we encounter.
        - This whole process goes on from left and from right until we reach a point where we have moved across all indices (left < right)

        */
        if(height == null || height.Length ==0)
            return 0;
        int n = height.Length;
        int left = 0;
        int right = n-1;
        int leftMax = height[left];
        int rightMax = height[right];
        int count = 0;
        while(left < right)
        {
            if(leftMax < rightMax) // we know that for sure leftMax can be the left boundary, so we calculate for left++
            {
                left++;
                // but as we arrive on new left we also need to check if it's height is smaller than the max left, 
                // then only it can have water, else we have to make this the new max
                if(height[left] > leftMax)
                {
                    leftMax = height[left];
                }
                else
                {
                    count += leftMax - height[left];
                }
            }
            else // the other case when we know that rightMax is the boundary, so we calculate for right --
            {
                right--;
                if(height[right] > rightMax) // same height check here
                {
                    rightMax = height[right];
                }
                else
                {
                    count += rightMax - height[right];
                }
            }
        }
        return count;
        
    }
}