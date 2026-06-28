"""
Given an integer array, write a function which returns the sum of values between two indexes.
"""

from typing import List

class SumBetweenRange:
    def __init__(self, nums: List[int]):
        self.prefix_sum = [nums[0]]
        for k in range(1, len(nums)):
            self.prefix_sum.append(self.prefix_sum[k-1]+ nums[k])

    def sum_range(self, i: int, j: int):
        if(i == 0):
            return self.prefix_sum[j]
        return self.prefix_sum[j]- self.prefix_sum[i-1]
            