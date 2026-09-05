public class Solution {
    public List<List<int>> threeSum(int[] nums) {
        // Your code goes here
        int[] sortedNums = nums.OrderBy(x =>x).ToArray();
        List<List<int>> FinalOutput = new List<List<int>>();
        List<List<int>> TempOutput;
        for(int i = 0; i < sortedNums.Length; i++)
        {
            if(sortedNums[i] > 0) // optimization: if num is +ve and array is sorted in ascending, all coming numbers will be +ve so we will never get 0 as sum.
                break; // breaking because if the first number is +ve all later are also and there cannot be a zero sum.
            if(i >= 1 && sortedNums[i-1] == sortedNums[i]) // check if the previous number is not same as current. Also important is check for i>=1 so that array is not out of bound. We are ideally doing this check only starting from the second number in array.
                continue;
            TempOutput = PairedSumOrdered(sortedNums,i+1, -sortedNums[i]); // call the function, the target sum is -a i.e -nums[i], i+1 because we want to see if pair sum is present in array exclusing current number.
            FinalOutput.AddRange(TempOutput);
        }
        return FinalOutput;
    }

    //Importatnt note : We have used If to eliminate duplicates above, but we are using while to do it in Paired Sum method. 
    // The real reason is that in the above code we are not doing any processing so we can continue and skip (it's similar to while loop), 
    // but in below code with each next element there is processing and we are adding values to final list, 
    // so we need to skip all duplicates at once. We cannot rely on continue or on the outer while loop to skip, 
    // because of we do, we will process everything and then eliminate. By the time we move to elimination, 
    // processing is already done and our duplicate is already added. Remember this important pattern.
    public List<List<int>> PairedSumOrdered(int[] nums, int startIndex, int target)
    {
        List<List<int>> allpairsum = new List<List<int>>();
        int left = startIndex;
        int right = nums.Length - 1;
        while (left < right)
        {
            int sum = nums[left] + nums[right];
            if(sum == target)
            {
                List<int> pairSumCurrent = new List<int>(); // a new copy for each iteration.
                // Add to result
                pairSumCurrent.Add(nums[startIndex-1]);
                pairSumCurrent.Add(nums[left]);
                pairSumCurrent.Add(nums[right]);
                allpairsum.Add(pairSumCurrent);
                left++; // Move to next non duplicate element
                while (left < right && nums[left] == nums[left-1]) // duplicate 'b' elimination. Also check left<right because it can be all 
                    left++;
            }
            else if(sum < target)
                left++;
            else
                right--;
        }
        return allpairsum;
    }
}