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

"""
It looks like even if we move one pointer itself, when the height of the containers are same, that would also work
That's a very astute observation, and you're absolutely right!

When heights[left] and heights[right] are equal, moving just one pointer (either left or right) inward would also lead to the correct answer. The reason the solution often suggests moving both is a subtle optimization and a conceptual simplification, but it doesn't change the correctness of the outcome.

Let's break down why moving only one pointer still works:

Current Area: When heights[left] == heights[right], the current area is heights[left] * (right - left). This area is calculated and compared with max_water.

Width Always Decreases: If you move either left or right inward, the width = (right - left) will always decrease by 1.

Height Can't Increase (Relative to the Fixed Pointer):

Suppose heights[left] == heights[right]. Let this common height be H.
If you move left to left + 1, the new container would be formed by heights[left+1] and heights[right]. The height of this new container would be min(heights[left+1], heights[right]). Since heights[right] is still H, the new container's height can be at most H (if heights[left+1] is greater than or equal to H), or it could be smaller (if heights[left+1] is less than H). It can never be greater than H while heights[right] remains H.
The same logic applies if you move right to right - 1. The new container height will be min(heights[left], heights[right-1]), which can also be at most H.
Area Cannot Increase: Since the width always decreases, and the height can, at best, stay the same (but usually decreases or is limited by the previous equal height), the new area formed by moving just one pointer cannot be greater than the area previously calculated when heights[left] == heights[right].

Why moving both is often done:

Efficiency: Since you know for sure that keeping one of the pointers fixed won't help you find a larger area (because the limiting height is already known and the width is decreasing), moving both pointers inward simultaneously allows you to "skip" an iteration where you'd essentially get a smaller or equal area by only moving one. It's a small optimization to converge to left >= right faster.
Symmetry: When both lines are equally tall, there's no logical reason to prioritize one side over the other. Moving both maintains symmetry in the algorithm's progression.
So, in summary:

Yes, moving just one pointer (either left or right) when their heights are equal would correctly find the maximum water.
The reason for moving both is a slight optimization; you avoid an extra iteration where you're guaranteed not to find a larger area.
The core principle remains: to maximize the area, you want to maintain the largest possible height for a given width. When heights[left] == heights[right], you've extracted the maximum possible height with that specific pair, and any further reduction in width with that same height won't yield a larger area. You must move on to explore new potential heights.
"""