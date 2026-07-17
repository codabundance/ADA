"""
Find the longest chain of consecutive numbers in an array. Two numbers are consecutive if they have a difference of 1.

Example:
Input: nums = [1, 6, 2, 5, 8, 7, 10, 3]
Output: 4
Explanation: The longest chain of consecutive numbers is 5, 6, 7, 8.
"""


'''
Approach 1:
Sort the array so that all the consecutive numbers are together, then we can go through the
array and find the longest consecutive in a single pass using 2 pointers
Keep going in the loop until subsequent numbers are consecutive. If the next number is not
consecutive, move i to j and j to j+1 and then do the same
with each iteration keep track of longest sequence yet found
Finally the longest one is the answer once array is fully traversed
Time Complexity - O(nlogn) + O(n)
Space Complexity - O(1)
'''

'''
Approach 2:
No sorting but worst than sorting approach
Go through each element of array (loop 1) for each element n try to find n+1 in array (loop 2)
When n+1 is found make it the next n and repeat the loop
In this way find longest consecutive chain starting from each number. 
Time Complexity - O(n3) the inner loop can take O(n2) in worst case when there is a long chain
Space Complexity - O(1)
'''

'''
Approach 3:
This is a tweak in the Approach 2 to make finding elements O(1) instead of O(n2)
using a hash set.
Time Complexity - O(n2)
Space complexity - O(n)
'''

'''
Approach 4:
Tweak in approach 3. Instead of going through each element, we can skip some of the 
elements as starting number of a sequence. If we already know that the num - 1 is in the
hash set then this means it will be part of some sequence.  So we can skip it
'''
from typing import List

def longest_chain_of_consecutive_numbers(nums: List[int]) -> int:
    # Write your code here
    num_set = set(nums)
    max_length = 0
    for num in num_set:
        # we know that we need to find the consecutive sequence only when num-1 is not there
        # in hash set. If it is there, num will be covered as part of chain starting at num-1
        # so skip it, no double iterations
        if num -1 not in num_set:
            curr_num = num
            curr_chain = 1
            while curr_num+ 1 in num_set:
                curr_num += 1
                curr_chain += 1
            max_length = max(max_length, curr_chain)
    return max_length
