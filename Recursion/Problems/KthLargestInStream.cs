using System;

namespace Recursion.Problems;

public class KthLargestInStream
{

    public List<int> kth_largest(int k, List<int> initial_stream, List<int> append_stream) {
        PriorityQueue<int, int> minHeap = new(k);
        initial_stream.Sort();
        int priority = 0;
        foreach (int i in initial_stream) {
            minHeap.Enqueue(i, ++priority);
        }
        for(int j =0; j< append_stream.Count; j++)
        {
            //var smallestElement = 
        }
        return [];
    }
}
