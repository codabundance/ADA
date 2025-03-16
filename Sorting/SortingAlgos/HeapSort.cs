using System;

namespace Sorting.SortingAlgos;

public class HeapSort : SortingBase
{
    public List<int> Heap_sort(List<int> arr) 
    {
        // Write your code here.
        int n = arr.Count-1;
        Build_Heap(arr,n);
        for(int i=n-1;i>=0;i--)
        {
            swap(arr,i,0);
            Heapify(arr,i-1);
        }
        return arr;
    }
    private static int MaxIndex(List<int> arr,int i, int j)
    {
        return arr[i] >= arr[j] ? i : j;
    }
    private void Heapify(List<int> arr, int n)
    {
        int k = n;
        while(k > 0)
        {
            if(arr[k] >= arr[2*k] && arr[k] >= arr[2*k+1])
            {
                k/=2;
                continue;
            }
            else
            {
                swap(arr,k,MaxIndex(arr,k*2,k*2+1));
                k/=2;
            }
        }
    }
    private void Build_Heap(List<int> arr, int n)
    {
        for(int j = n/2; j >=0; j--)
        {
            if((arr[j] >= arr[2*j]) && (arr[j] >= arr[2*j+1]))
                continue;
            else
                Heapify(arr,j);
        }
    }

    public override void Sort(List<int> arr)
    {
        Heap_sort(arr);
    }
}
