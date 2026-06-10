"""Given an integer array nums sorted in non-decreasing order, remove all 
duplicates in-place so that each unique element appears only once.
Return the number of unique elements in the array.

If the number of unique elements be k, then, Change the array nums such that the 
first k elements of nums contain the unique values in the order that they were 
present originally.

The remaining elements, as well as the size of the array does not matter in terms
 of correctness.

 The driver code will assess correctness by printing and checking only the first k elements of the modified array.
"""
def removeDuplicates(self, nums: list[int]) -> int:
# This is similar to move zeros to the end, the only thing is instead of checking zeros
# we need to see duplicates
    j = 0; # pointer to replace
    for i in range(1, len(nums)):
        if nums[i] != nums[j]:
            j += 1 # increase j by 1 to maintain order
            nums[j] = nums[i] # we don's swap because what happens to the other element is not important
    return j+1
            