def rotate_array_1(nums):
    first_num = nums[0]
    for i in range(1, len(nums)):
        nums[i - 1] = nums[i]
    nums[len(nums) - 1] = first_num