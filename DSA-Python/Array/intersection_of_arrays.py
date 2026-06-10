"""Given two sorted arrays, nums1 and nums2, return an array containing the intersection of these two arrays. 
Each element in the result must appear as many times as it appears in both arrays; 
that is, if an element appears x times in nums1 and y times in nums2, 
it should appear min(x, y) times in the result."""
def intersectionArray(self, nums1, nums2):
        n = len(nums1)
        m = len(nums2)
        i=0
        j=0
        intersection_array = []
        while i < n and j < m:
            if nums1[i] == nums2[j]:
                intersection_array.append(nums1[i])
                i += 1
                j += 1
            elif nums1[i] < nums2[j]:
                i += 1
            else:
                j+=1
        return intersection_array