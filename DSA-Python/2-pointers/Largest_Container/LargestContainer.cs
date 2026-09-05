public class Solution {
    public int max_area(int[] heights) {
        // Your code goes here
        // This problem boils down to finding max product with sliding pointer
        int n = heights.Length;
        int left = 0;
        int right = n-1;
        int max_area = 0;
        while(left < right)
        {
            int curr_area = Math.Min(heights[left], heights[right]) * (right-left);
            if(curr_area > max_area)
                max_area = curr_area;
            if(heights[left] < heights[right])
                left++;
            else
                right--;
        }
        return max_area;
    }
}