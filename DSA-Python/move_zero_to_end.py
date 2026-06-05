# 2 pointers - i moves through the array
# j - finds the position to swap the element
# when i finds a non zero element, swap with j and move j one place ahead
# when i finds a zero element just move i
# in this way we keep swapping and pushing the non zero elements to front (thus zeros to the end)
#
def moveZeroes(self, nums):
        j = 0;
        for i in range(len(nums)):
            if nums[i] != 0:
                nums[i], nums[j] = nums[j], nums[i]
                j += 1