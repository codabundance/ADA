def is_palindrome_valid(s: str) -> bool:    
    # Write your code here
    left = 0
    right = len(s) - 1
    while(left < right): # includes condition when even numbers i.e. left > right
    #and odd numbers i.e. left==right
        # if all the values are non alpha, then we need to check
        # only till half the chars i.e left < right 
        while left < right and not s[left].isalnum():
            left += 1
        while left < right and not s[right].isalnum():
            right -= 1
        # if alpha found both from left or from right before half of string
        # They are not equal not a palindrome
        if s[left] != s[right]:
            return False
        # if equal move pointers
        left += 1
        right -= 1
    # finally all alpha matched
    return True

"""
why left < right condition is required even in internal while loop

Because this prevents index out of bound. Even if all the charachters are not alphanumeric,
Is Palindrom should be true. 
if we dont put that condition then for scenarios where all are not alphanumeric, the while loop
goes through all elements and there is not stopping. So, it goes beyond index.
"""

        
