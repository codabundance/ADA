"""
Longest Substring With Unique Characters
"""

'''
Approach 1: Use Dynamic Sliding Window
Starting from start of the array, 
1. If there are no duplicates found yet, move right
2. If duplicate found, move left until duplicate no more there

For finding if duplicate/ substring is unique, we can use a hashmap.
Very importantly - if we find a duplicate, we will have to use a "while" loop to shift
the lft pointer and keep removing the charachter from hashmap. Otherwise there is no way
to know if the duplicate is not more in the window.
One left has reached duplicate, it will remove it from hashmap and do left+1
so if in next iteration we check if right is in hashmap or not we get not, this makes sure
that we have removed the duplicate value from current window.

one important information to consider is, if we keep track of the previous index of the charachters
char then we can jump over to index + 1 instead of moving left pointer one at a time.
We will not need a loop here, we can just check if right is in hashnap, if it is there
we know deuplicate is in window and its value in hashmap is it's index
So we can move the left to that index + 1 directly. No loop needed
But, because we are not deleting from hashmap now, we will have to check if the index is
in the current window i.e >=left.
'''

def longest_substring_with_unique_chars(s: str) -> int:
   # Write your code here
    left, right = 0
    max_len = 0
    lenS = len(s)
    prev_index_map = {}
    while right < lenS:
            # find each charchter in hashmap. if found not unique, else unique and keep moving
            if s[right] in prev_index_map:
                # we need to take duplicates only in current window, so we exclude any other duplicate index added out of current window
                if prev_index_map[s[right]] >= left:
                    # if found means duplicate, so move left to prev index + 1
                    left = prev_index_map[s[right]] + 1
            # Add the current charachter to map
            prev_index_map[s[right]] = right
            #update max lane to max of current window size after moving left pointer
            max_len = max(max_len, right-left +1)
            right += 1
    return max_len
