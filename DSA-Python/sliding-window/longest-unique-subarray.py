"""
Longest Substring With Unique Characters
"""

'''
Approach 1: Use Dynamic Sliding Window
Starting from start of the array, 
1. If there are no duplicates found yet, move right
2. If duplicate found, move left until duplicate no more there

For finding if duplicate/ substring is unique, we can use a hashmap.
one important information to consider is, if we keep track of the previous index of the duplicate
char then we can jump over to index + 1 instead of moving left pointer one at a time.
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
