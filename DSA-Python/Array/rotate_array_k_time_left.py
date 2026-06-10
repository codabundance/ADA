"""Function to rotate the array to the left by k positions"""
def rotateArray_k(nums, k):
        n = len(nums)  # Size of array
        k = k % n  # To avoid unnecessary rotations

        temp = []

        # Store first k elements in a temporary array
        for i in range(k):
            temp.append(nums[i])

        # Shift n-k elements of given array to the front
        for i in range(k, n):
            nums[i - k] = nums[i]

        # Copy back the k elements at the end
        for i in range(k):
            nums[n - k + i] = temp[i]


