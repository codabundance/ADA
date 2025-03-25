using System;

namespace Sorting.Problems;
//Quick Search Approach.
public class KthLargestElement
{
    public static int Kth_Largest_Element(List<int> arr, int k)
    {
        int idx = arr.Count - k;
        int n = arr.Count;
        Helper(arr,idx,0,n-1);
        return arr[idx];
    }
    private static void Helper(List<int> arr, int idx, int start, int end)
    {
        if(start > end)
            return;
        int pivot = start; // Not randomized pivot, but first element as the pivot
        int g = start;
        int r = start+1;
        while(r <= end)
        {
            if(arr[r] < arr[pivot])
            {
                g++;
                Swap(arr,g,r);
            }
            r++;
        }
        Swap(arr, pivot, g);// Bring the pivot at it's correct position, because after every partitioning, the pivot will be frozen
        if(g == idx) // If pivot is the index we are looking for return. idx will be the index of pivot i.e. g
            return;
        if(g < idx) // Else if pivot's index i.e. g is less than idx, then search on right side of pivot
        {
            Helper(arr, idx, g+1, end);
        }
        else // if pivot's index i.e. g is greater than idx, then search on the left side of pivot.
        {
            Helper(arr, idx, start, g-1);
        }
    }
    private static void Swap(List<int> arr, int a, int b)
    {
        (arr[b], arr[a]) = (arr[a], arr[b]);
    }
}
