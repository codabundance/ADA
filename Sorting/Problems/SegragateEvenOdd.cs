using System;

namespace Sorting.Problems;

/**************************************************************
Given an array of numbers, rearrange them in-place so that even numbers appear before odd ones.
**********************************************/
public class SegragateEvenOdd
{

    public static List<int> Segregate_evens_and_odds(List<int> numbers) {
        // Write your code here.
        // We can try decrease and conquer. We will have 2 pointers i,j starting at 0. i is to keep track of last element of even array
        // j is to keep track of 1st element of Odd array.
        // if the element at current position is even then increase i to next, if it is odd
        int even = 0;
        int odd = numbers.Count-1;
        /* 2 pointers odd and even. If number at even place is odd then swap. But, once we swap, we are sure that the new number that we 
        shifted at odd place is odd, because we moved it only because it was odd. So, we can reduce the odd pointer by one, but for event
        pointer, we are still not sure, so we will still need to check the swapped element at even pointer for even or odd, so we dont 
        increase the even pointer and vice versa*/ 
        while(odd >= even)
        {
            if(numbers[even] % 2 == 0)//even in odd array so swap
            {
                even++;
            }
            else if(numbers[even] % 2 != 0)//odd
            {
                swap(numbers,odd,even);
                odd--;
            }
        }
        return numbers;
    }
    
    private static void swap(List<int> arr, int j, int i)
    {
        var temp = arr[i];
        arr[i]=arr[j];
        arr[j]=temp;
    }


}
