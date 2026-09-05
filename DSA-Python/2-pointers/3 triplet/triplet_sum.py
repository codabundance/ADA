from typing import List

def triplet_sum(nums: List[int]) -> List[List[int]]:
    # Write your code here
    nums.sort()
    triplets = []
    for i in range(len(nums)):
        # we cannot sum to zero if 'a'>0 as b and c definitely will be
        # we have sorted the array
        if nums[i] > 0:
            break
        # for duplicates if last element is same as current continue
        if i > 0 and nums[i] == nums[i-1]:
            continue
        found = sum_target(nums, i+1, -nums[i])
        for pair in found:
            triplets.append([nums[i]] + pair)
    return triplets
        
def sum_target(nums: List[int], start:int, target:int):
    pairs = []
    left = start 
    right =len(nums)-1
    while left < right:
        sum_pair = nums[left]+ nums[right]
        if sum_pair > target:
            right -= 1
        elif sum_pair < target:
            left +=1
        else:
            pairs.append([nums[left], nums[right]])
            left+=1 # skip same 'b' to avoid duplicate pairs
            while left < right and nums[left] == nums[left - 1]:
                left += 1
    return pairs

        