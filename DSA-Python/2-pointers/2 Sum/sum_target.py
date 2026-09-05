from typing import List

def pair_sum_sorted(nums: List[int], target: int) -> List[int]:
    # Write your code here
    left = 0
    right = len(nums) - 1
    while(left < right):
        sum_val = nums[left] + nums[right]
        if sum_val > target:
            right -= 1
        elif sum_val < target:
            left += 1
        else:
            return [left, right]
    return []