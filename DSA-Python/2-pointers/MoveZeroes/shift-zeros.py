"""
Given an array of integers, modify the array in place to move all zeros 
to the end while maintaining the relative order of non-zero elements.
"""
from typing import List

def shift_zeros_to_the_end(nums: List[int]) -> None:
    # Write your code here
    left = 0
    n = len(nums)
    for right in range(0, n):
        if nums[right] != 0:
            nums[left], nums[right] = nums[right], nums[left]
            left += 1 # move the left pointer to new insert position
             # move right pointer to next find position, loop will take care of that
