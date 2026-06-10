"""Given an integer array nums of size n, return the majority element of the array
The majority element of an array is an element that appears more than n/2 times in the array. 
The array is guaranteed to have a majority element."""

def majorityElement_better(self, nums):
    set_of_nums = {}
    n = len(nums)
    for i in range(0,n):
        if nums[i] in set_of_nums:
            set_of_nums[nums[i]] += 1
        else:
            set_of_nums[nums[i]] = 1
    
    for j, freq in set_of_nums.items():
        if freq > n // 2:
            return j

def majorityElement_optimal(self, nums):
        n = len(nums)
        candidate = nums[0]
        count = 1
        for i in range(1, n):
            if nums[i] == candidate:
                count +=1
            elif count == 0:
                candidate = nums[i]
                count += 1
            else:
                count -= 1
        # verification
        count_of_candidate = 0
        for j in range(n):
            if nums[j] == candidate:
                count_of_candidate += 1
        if count_of_candidate > n/2:
            return candidate
        else:
            return -1;