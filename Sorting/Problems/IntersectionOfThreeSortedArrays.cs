using System;

namespace Sorting.Problems;
/*
Given three arrays sorted in the ascending order, return their intersection sorted array in the ascending order.

Example One
{
"arr1": [2, 5, 10],
"arr2": [2, 3, 4, 10],
"arr3": [2, 4, 10]
}
Output:

[2, 10]
Example Two
{
"arr1": [1, 2, 3],
"arr2": [],
"arr3": [2, 2]
}
Output:

[-1]
*/
public class IntersectionOfThreeSortedArrays
{
    public static List<int> find_intersection(List<int> arr1, List<int> arr2, List<int> arr3) {
        // Write your code here.
        List<int> result = new();
        List<int> tempResult = new();
        Find_Intersection_of_two(arr1,arr2,tempResult);
        Find_Intersection_of_two(tempResult, arr3, result);
        if(result.Count == 0)
            result.Add(-1);
        return result;
    }
    
    private static void Find_Intersection_of_two(List<int> arr1, List<int> arr2, List<int> res)
    {
        int i = 0; int j=0;
        while(i< arr1.Count && j< arr2.Count)
        {
            if(arr1[i] == arr2[j])
            {
                // i++ and j++ is not affecting here because we have an else condition, so line 51
                // does not get executed and when control reaches directly to line 44 while is false.
                res.Add(arr1[i]);
                i++;
                j++;
            }
            else if(arr1[i] < arr2[j])
                i++;
            else if(arr2[j] < arr1[i])
                j++;
        }
    }
     public static List<int> find_intersection_1(List<int> arr1, List<int> arr2, List<int> arr3) {
        // Write your code here.
        List<int> result = new();
        /*
        Approach 2: Find the minimum of the three array elements at i,j,k. Whatever is minimum increase that.
        Add to result only of all 3 are equal.
        */
        int i=0; int j=0; int k=0;
        while (i< arr1.Count && j< arr2.Count && k < arr3.Count)
        {
            if(arr1[i] == arr2[j] && arr1[i] == arr3[k] && arr2[j] == arr3[k])
            {
                // We should not increment i,j,k because if the last elements in all the 3 arrays are equal
                // then line 73 will throw out of bound error. Line 73 is always executed so it is an issue.
                // So if we put an else at line 76 even i++, j++, k++ wpild work.
                result.Add(arr1[i]);
                //i++; j++;k++;
            }
            int minimum = Math.Min(Math.Min(arr1[i], arr2[j]),arr3[k]);
            if(minimum == arr1[i])
                i++;
            if(minimum == arr2[j])
                j++;
            if(minimum == arr3[k])
                k++;
        }
        if(result.Count == 0)
            result.Add(-1);
        return result;
    }
}
