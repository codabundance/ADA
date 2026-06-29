"""
Longest Uniform Substring After Replacements

A uniform substring is one in which all characters are identical. 
Given a string, determine the length of the longest uniform substring 
that can be formed by replacing up to k characters.
"""

'''
Approach:
# we can still use dynamic sliding window as question contains - subarray and we want to be linear
# The condition for sliding the window -> if we can replace 'k' charachters from the substring withing SW and get a uniform string
    ## If yes - move right pointer
    ## If no - move left pointer
# How to check the condition?
    ## Essensitally, in a substring, we can find the frequency of each charachter
    ## The charachter with highest frequency is the one which will give the least number of replacements to make that string uniform
    ## say highest frequenc is 'f'. Now Len(substring) - f gives the least number of charachters that need to be replaced
    ## if this value is <=k then it is possible for us to replace 'k' chars and make this substring uniform (Yes condition)
    ## if this value is > k then (No condition)
# How to implement this condition
    ## Get freqency of each char as we move right and keep finding the max frequency
    ## Once you reach the end of window, max_freq gives this number, Use it to check the condition
# Fiding max string length
    ## Now once we evaluate this for all possible substrings using DSW, 2 of the following happens
        ### substring satisfies the condition -> Expand the window
        ### substring does not satisfy the condition 
            -> Shrink the window and compare with max_length. 
            -> Update Max_length
            -> Remove frequency from the hashmap for the current char
'''
def longest_uniform_substring_after_replacements(s: str, k: int) -> int:
    # Write your code here
    hash_map = {}
    left = right = 0
    max_freq = 0
    max_length = 0
    while right < len(s):
        # add frequency of each char
        hash_map[s[right]] = hash_map.get(s[right], 0) + 1
        # update max_freq
        max_freq = max(max_freq, hash_map[s[right]])
        # condition satisfies for current window, keep moving as this cannot be longest, we can add more
        # longest we can only claim when condition becomes false
        curr_window_length = right - left +1 
        # as soon as we get >k we know that if we move left one step forward it will again
        # satisfy <=k, so that will be our window which satisfies our condition
        # hence max_length = length of this window after moving left
        if (curr_window_length - max_freq) > k:
            hash_map[s[left]] -= 1 # we only reduce frequency of char we left by 1 because that char
            #could be at other positions also and the freq should refelect that
            left += 1
        # if we are still expanding then max_length will not be less than current length
        # because we are expanding only when <=k that means it is a increasing sequence
        # satisfying our condition, so max_length cannot be less, no need to do max here
        max_length = right - left + 1
        right +=1            
    return max_length
            

