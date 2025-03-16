using System;

namespace Sorting.SortingAlgos;

public class QuickSort : SortingBase
{
    public List<int> Quick_sort(List<int> arr) {
        // Write your code here.
        Quicksort_helper(arr,0,arr.Count-1);
        return arr;
    }
    
    private void Quicksort_helper(List<int> arr, int start, int end)
    {
        // leafe node and also if any of subarrays is empty
        if(start>=end)
            return;
        //Randomize
        int pivotIndex = new Random().Next(start,end+1);
        swap(arr,pivotIndex,start);
        // Hoare's partitioning
        int smaller = start+1; // start has the pivot so start one beyond that.
        int bigger = end;
        while(smaller <= bigger)
        {
            if(arr[smaller] < arr[start])
                smaller++;
            else if(arr[bigger] > arr[start])
                bigger--;
            else
            {
                swap(arr, smaller, bigger);
                smaller++;
                bigger--;
            }
        }
        swap(arr, start, bigger);
        Quicksort_helper(arr, start, bigger-1);
        Quicksort_helper(arr, bigger+1,end);
        
    }

    public override void Sort(List<int> arr)
    {
        Quick_sort(arr);
    }
}
