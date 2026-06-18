"""
You are given an array of numbers, 
each representing the height of a vertical line on a graph. 
A container can be formed with any pair of these lines, 
along with the x-axis of the graph. 

Return the amount of water which the largest container can hold.
"""

from typing import List

def largest_container(heights: List[int]) -> int:
    # Write your code here
    left = 0
    right = len(heights) - 1
    MaxWater = 0
    while left < right:
        water = min(heights[left], heights[right])*(right-left)
        MaxWater = max(MaxWater,water)
        # if width is same, then the smaller height is the limiting factor
        # so it is better to change that to see volume increases of decreases.
        # left is the limiting factor
        if heights[left] < heights[right]:
            left += 1
        elif heights[left] > heights[right]:
            right -= 1
        else:
            left += 1
            right -= 1
    return MaxWater