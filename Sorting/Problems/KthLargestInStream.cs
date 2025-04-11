using System;
using System.Reflection.Metadata.Ecma335;

namespace Sorting.Problems;
/*
Find kth largest element in a stream
{
"k": 2,
"initial_stream": [4, 6],
"append_stream": [5, 2, 20]
}
*/
public class KthLargestInStream
{
    public static List<int> kth_largest_max(int k, List<int> initial_stream, List<int> append_stream) {
        // Write your code here.
        //MaxHeap approach
        List<int> result = new();
        MaxHeap maxHeap= new();
        foreach (int i in initial_stream)
            maxHeap.Insert(i);
        //stream comes here.
        foreach(int val in append_stream)
        {
            maxHeap.Insert(val);
            for(int m = 0; m < k; m++)
                result.Add(maxHeap.ExtractMax());
        }
        return result;
    }

    public static List<int> kth_largest_min(int k, List<int> initial_stream, List<int> append_stream) 
    {
        // Write your code here.
        //Min Heap approach
        List<int> result = new();
        MinHeap minHeap = new();
        int i= 0;
        while(i < k)
        {
            minHeap.Insert(initial_stream[i]);
            i++;
        }
        while(i < initial_stream.Count)
        {
            if(minHeap.Peek() < initial_stream[i])
            {
                minHeap.ExtractMin();
                minHeap.Insert(initial_stream[i]);
            }
        }
        //stream comes here.
        foreach(int val in append_stream)
        {
            if(minHeap.Peek() < val)
            {
                minHeap.ExtractMin();
                minHeap.Insert(val);
            }
            var v = minHeap.ExtractMin();
            result.Add(v);
            minHeap.Insert(v); // Reinstert the extracted value
        }
        return result;
    }

}
