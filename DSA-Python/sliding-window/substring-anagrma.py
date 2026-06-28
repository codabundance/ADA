"""
Given two strings, s and t , both consisting of lowercase English letters, return the number of substrings in s that are 
anagrams of t.

An anagram is a word or phrase formed by rearranging the letters of another word or phrase, using all the original letters 
exactly once.


"""

'''
We will use fixed sliding window technique. The important information is that anagram can be found by 2 conditions
1. if the length of substring of S is same as T
2. If Substring of S contains same charachters as T

We can store frequency of characthers in each string using 2 separate arrays - expected and actual
we first add the frequency of each charachter in T in expected.
We start in the string S from 0 till length of T, and keep adding frequency of each in actual
Once lenth matches, we compare expected with actual, if they are same we have found anagram and we increase count by 1

if not then we move right by 1 and left by 1, we also reduce the frequency of charachter at left from expected
Do the same operation again
Sliding window makes sure that we cover all substrings of a given length

Time Complexity - O(n)
Space Complexity - O(1) - arrays of fixed size
'''

def substring_anagrams(s: str, t: str) -> int:
    # Write your code here.
    final_count = 0
    lenS = len(s)
    lenT = len(t)
    left = 0
    right = 0
    actual = [0] * 26
    expected = [0] * 26
    # add the frequency of all chars in second string to arra
    for c in t:
        expected[ord(c)- ord('a')] += 1
    while right < lenS:
        # move forward till lenT and add each charachter's frequency in actual array
        actual[ord(s[right]) - ord('a')] += 1
        if(right - left +1 == lenT): #formed the first window
            if actual == expected:
                final_count += 1
            # now once check is done, remove the left charachter frequency before sliding window from left
            actual[ord(s[left]) - ord('a')] -= 1
            left += 1
        right+=1
    return final_count
