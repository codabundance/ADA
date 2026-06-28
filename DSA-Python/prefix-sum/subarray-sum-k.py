"""
Write a function that returns the total number of contiguous subarrays within a 
given integer array whose elements sum up to a target K.
"""
'''
Approach 1: The we can create a prefix sum array and then for that array, we can run 2 loops to check if the difference of 2 numbers is K or not
Note that once prefix sum array is formed, the problem gets reduced to finding 2 elements in the prefix sum array whose difference is 'K'
Because the difference is always between right element and left element, we need not find the difference between all elements. This means
i can go from 0 to N and j can go from 0 to i+1

Time Complexity - O(n2)
Space Complexity -  O(n)
'''

'''
Approach 2: We can reduce 2 loops to one by building a hashmap of prefix sum together with array
The hash map will be built from array and with frequency of each prefix sum. 
Then we follow the same approach of going through each element of prefix sum and finding out if the complement is present in hashmap or not
Now in a hashmap we can only add unique elements so if there is repition of elements in prefix sum, we need to increase the frequency of
repeating element. 

Time Complexity - O(n)
Space Complexity - O(n) - But we form 2 separate DS - Hashmap and prefix sum array
'''

'''
Approach 3: In approach 2 we can do a slight modification
Instead of pre building the hash map, we can build the hash map on the fly
We know that in the prefix-sum array we only need to do arr[j]-arr[i] where j > 0
So we need to compare only to elements going backwards i.e. elements which have already occurred in array
We can use this information and try to build the hashmap on the fly without even needing a prefix sum array
for each current prefix sum, we check if K-(cuurent prefix sum) present in the hash map or not
if present increase the frequency, if not present add it with frequency of 1
Now, we calculate curr perfix sum at each step and check if we already have a subarray that sums with this current subarray sum (cur prefix sum) 
to give K by checking in already created hashmap.  If it does then we increase the count by frequency

Important to note that this works because we always need to check backwards

Time Complexity = O(n)
Space Complexity = O(n)
'''
from typing import List

def k_sum_subarrays(nums: List[int], k: int) -> int:
    # Write your code here
    hash_map = {0:1} # default to 0 as when you add first numnber of array to zero it gives the first number only.
    curr_prefix_sum = 0 # our loop index starts from 0 so 1st number is also included when calculating curr_pref_sum
    total_count = 0
    for i in range(0, len(nums)):
        curr_prefix_sum += nums[i]
        if (curr_prefix_sum - k) in hash_map:
            total_count += hash_map[curr_prefix_sum - k]
        hash_map[curr_prefix_sum] = hash_map.get(curr_prefix_sum, 0) + 1
    return total_count
        
