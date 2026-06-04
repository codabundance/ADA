from rotate_array_1_time_left import rotate_array_1
from rotate_array_k_time_left import rotateArray_k

# Helper function to print the array
def printArray(nums):
    for val in nums:
        print(val, end=" ")
    print()

def main():
    nums = [1,2,3,4,5,6]
    rotate_array_1(nums=nums)
    printArray(nums)
    rotateArray_k(nums, 2)
    printArray(nums)

if __name__ == "__main__":
    main()