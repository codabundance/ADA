using System;

namespace Sorting.SortingAlgos;

public class CountingSort : SortingBase
{
    public override void Sort(List<int> arr)
    {
        Counting_sort(arr);
    }

    public static List<int> Counting_sort(List<int> arr) {
    /*Approach 
    -------------
    - We will add all elements in the array to a dictionary for manitaining count
    - We will find the min element and max element in the array
    - starting from min element till max element we will keep adding all the values present in the input
      array based on the frequency of each element
    -------------*/
        Dictionary<int,int> frequency = new Dictionary<int,int>();
        List<int> result = new List<int>();
        for(int i=0;i<arr.Count;i++)
        {
            if(frequency.ContainsKey(arr[i]))
                frequency[arr[i]]++;
            else
                frequency.Add(arr[i],1);
        }
        int minelement = arr[0];
        int maxelement = arr[0];
        foreach(int item in arr)
        {
            minelement = Math.Min(item,minelement);
            maxelement = Math.Max(item,maxelement);
        }
        for(int k = minelement; k<=maxelement; k++)
        {
            frequency.TryGetValue(k, out var freq);
            int count = 0;
            while(count < freq)
            {
                result.Add(k);
                count++;
            }
        }
        return result;
    }

}
