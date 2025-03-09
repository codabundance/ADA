using System;

namespace Sorting.SortingAlgos;

public class MergeSort : SortingBase
{
    public override void Sort(List<int> arr)
    {
        //List<int> auxArray = [];
        Merge_sort_helper(arr,0,arr.Count-1);
    }

    private static void Merge_sort_helper(List<int> arr,int start, int end)
    {
        if(start==end)
            return;
        //Divide
        int mid = (start+end)/2;
        Merge_sort_helper(arr,start,mid);
        Merge_sort_helper(arr,mid+1,end);
        
        //Merge/Conquer
        int left = start;
        int right = mid+1;
        List<int> aux = new();
        while(left <= mid && right <= end)
        {
            if(arr[left] <= arr[right])
            {
                //insert left into auxilliary array
                aux.Add(arr[left]);
                left++;
            }
            else
            {
                //insert right into auxilliary array
                aux.Add(arr[right]);
                right++;
            }
            
        }
        //when left array is remaining
        while(left <= mid)
        {
            //insert remaining left elements into aux array
            aux.Add(arr[left]);
            left++;
        }
        while(right <= end)
        {
            //insert remaining left elements into aux array
            aux.Add(arr[right]);
            right++;
        }
        //Once the subarrays are sorted copy those elements to respective positions in the array
        // As this subproblem deals with it's own start and end, we add the elements from start
        int k = start;
        int m = 0;
        while(m<aux.Count)
        {
            arr[k++] = aux[m++];
        }
    }
}
