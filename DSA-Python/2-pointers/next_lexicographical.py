"""
Given a string of lowercase English letters, 
rearrange the characters to form a new string representing the next immediate sequence 
in lexicographical (alphabetical) order. 
If the given string is already last in lexicographical order among all possible arrangements, 
return the arrangement that's first in lexicographical order.
"""


def next_lexicographical_sequence(s: str) -> str:
    # Write your code here
    letters = list(s)
    #find the pivot
    pivot = len(letters)-2
    while pivot >=0 and letters[pivot] >= letters[pivot+1]:
        pivot -= 1
    # if pivot is -1 that means array is completetly non increasing and in it's highest lexicographical state
    if pivot == -1:
        return ''.join(reversed(letters))
    # pivot is some index in string
    # find the next letter on right of pivot to swap
    next_letter = len(letters) - 1
    while next_letter > pivot and letters[pivot]>=letters[next_letter]:
        next_letter -= 1
    # Either next letter is found or next_letter is pivot
    # swap next_letter with pivot
    letters[pivot], letters[next_letter] = letters[next_letter], letters[pivot]
    # once swap is done we can reverse the string after pivot to make it smallest
    letters[pivot+1:]= reversed(letters[pivot+1:])
    return ''.join(letters)


"""
1. We need to move right to left because the smallerst increase will happen from right only
2. We move from right to left to see the first non increasing letter. If the sequence is increasing
from right to left, then we can't swap to get larger sequence. Swapping will always give smaller sequence
3. The letter that breaks this right to left increasing sequence is 'pivot'
4. If we swap pivot with any letter to a letter larger than pivot to it's right, 
it will give a larger sequence than current
5. But because we want smallerst increase, we find the letter immendiately larger to pivot
6. Once it is found, we swap with pivot and get the larger subsequence, but this is still not the 
next larger.
7. To find the next larger, we can reverse the letters to the right of pivot because even after swap
the letters to the right are non increasing, so reversing them will give the smallest possible sequence
8. The final string becomes the answer

So first we find a large sequence using swap (but not too large)
Then we use reverse to make even that smaller so that it is the next larger sequence possible
"""