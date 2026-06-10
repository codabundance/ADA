"""Given an integer array of size n containing distinct values in the range from 0 to n (inclusive), 
return the only number missing from the array within this range."""
def missingNumber(self, nums):
        n = len(nums)
        sum_of_n__continous_numbers = (int)(n * (n+1))//2
        sum_of_n_numbers = 0
        for i in range(n):
            sum_of_n_numbers += nums[i]
        return sum_of_n__continous_numbers - sum_of_n_numbers 