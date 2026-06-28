"""
Write a function to efficiently count vowels within specified substrings of a given string.
"""
def vowelStrings(self, word: str, queries: List[List[int]]) -> List[int]:
        # Your code goes here
        vowels = set('aeiou') # assuming all lowercase
        final_result = []
        prefix_sum = [0] * (len(word)+1)
        for i in range(1, len(word) + 1): #size of prefix array will be one larger
            if word[i-1] in vowels:
                prefix_sum[i] = prefix_sum[i-1] + 1
            else:
                prefix_sum[i] = prefix_sum[i-1]
        
        for j,k in queries:
            vowels_count = prefix_sum[k+1] - prefix_sum[j]
            final_result.append(vowels_count)
        return final_result

