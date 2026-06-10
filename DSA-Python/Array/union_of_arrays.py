"""Given two sorted arrays nums1 and nums2, return an array that contains the union of these two arrays. 
The elements in the union must be in ascending order.
The union of two arrays is an array where all values are distinct and 
are present in either the first array, the second array, or both."""

def unionArray(self, nums1, nums2):
        n = len(nums1)
        m = len(nums2)
        i = 0
        j = 0
        union_array = []
        while i < n and j < m:
            if nums1[i] == nums2[j]:
                add_to_array(union_array, nums1[i])
                i += 1
                j += 1
            elif nums1[i] < nums2[j]:
                add_to_array(union_array, nums1[i])
                i += 1
            else:
                add_to_array(union_array, nums2[j])
                j += 1
        while i < n:
            add_to_array(union_array, nums1[i])
            i += 1
        while j < m:
            add_to_array(union_array, nums2[j])
            j += 1
        return union_array

def add_to_array(nums, p):
        if p not in nums:
            nums.append(p)