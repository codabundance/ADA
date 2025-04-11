using System;

namespace Sorting.Problems;
/*
//STREAM PROBLEMS
Given a list of numbers, the task is to insert these numbers into a stream and find the median of the stream after each insertion. If the median is a non-integer, consider it’s floor value.

The median of a sorted array is defined as the middle element when the number of elements is odd and the mean of the middle two elements when the number of elements is even.

Example
{
"stream": [3, 8, 5, 2]
}
Output:

[3, 5, 5, 4]
Iteration	Stream	Sorted Stream	Median
1	[3]	[3]	3
2	[3, 8]	[3, 8]	(3 + 8) / 2 => 5
3	[3, 8, 5]	[3, 5, 8]	5
4	[3, 8, 5, 2]	[2, 3, 5, 8]	(3 + 5) / 2 => 4
 
 There are following approaches to solve this:
 ============================================
 1. Sorted Array Approach
    - Sort the existing array
    - Insertion of new element coming up - O(n)
    - If number of elements are odd the median is n/2th element
    - If number of elements are even the median is average of middle 2.
Time complexity - O(n*n) - assuming there are 'n' elements in stream.
Auxilliary Space complexity - O(1)
Output Space complexity - O(n)

2. Max Heap approach
    - Build Max Heap from initial array O(nlogn)
    - Insert each new element into the Max Heap O(logn)
    - Extract n/2 elements O(n/2logn)
    - Reinsert n/2 extracted elements O(n/2logn)
Time complexity = O(nlogn)+O(logn)+O(n/2logn)+O(n/2logn) = O(nlogn)
Auxilliary Space complexity = O(n) 
Output Space = O(n)

3. Min Heap approach - We will need to maintain all elements as mean will be shifting based on incoming elements
So, we cannot loose any of the elements. So this becomes same as the Max Heap approach.
    - Build Min Heap from initial array O(nlogn)
    - Insert each new element into the Min Heap O(logn)
    - Extract n/2 elements O(n/2logn)
    - Reinsert n/2 extracted elements O(n/2logn)
Time complexity = O(nlogn)+O(logn)+O(n/2logn)+O(n/2logn) = O(nlogn)
Auxilliary Space complexity = O(n) 
Output Space = O(n)

4. We can tweak the max heap approach. In max heap we are extracting n/2 elements everytime when a new number comes in and then
reinserting those elements again. We repeat this everytime. What if we could store the elements in some other DS so that we would
not need to extract n/2 everytime. Median would be around middle of the array. So we want middle elements of the array to be accesible easily
We can split the array into 2 heaps one max and another min. Max will have all smaller elements and min will have all larger. Thus middle 2
elements would be root of max heap and min heap respectively making them easily accessible in O(1) operations

    - If incoming number is more than median insert into min heap. O(logn)
    - If incoming number is less than median insert into max heap. O(logn)
    - If difference between size of 2 heaps == 2
        Rebalance => Extract the root of larger heap and insert it into smaller heap - Extract O(logn) + Insert O(logn) = O(logN)
    - If Size(max) == Size(Min) median = root(max) + root(min)/2
    - If Size(max) > Size(min) median = root(max)
    - If Size(max) < Size(min) median = root(min)
Implementing this algorithm in this class as this is the most efficient
 */
public class OnlineMedian
{
    public static List<int> online_median(List<int> stream)
    {
        MinHeap minHeap = new MinHeap();
        MaxHeap maxHeap = new MaxHeap();
        int median = 0;
        List<int> result = new List<int>();
        foreach (int i in stream)
        {
            if(i >= median)
            {
                minHeap.Insert(i);
                if(minHeap.Count - maxHeap.Count ==2)
                    Rebalance(minHeap,maxHeap);
            }
            if(i < median)
            {
                maxHeap.Insert(i);
                if(maxHeap.Count - minHeap.Count ==2)
                    Rebalance(maxHeap,minHeap);
            }
            if(minHeap.Count == maxHeap.Count)
                median = (minHeap.Peek() + maxHeap.Peek())/2;
            else if (minHeap.Count > maxHeap.Count)
                median = minHeap.Peek();
            else if(minHeap.Count < maxHeap.Count)
                median = maxHeap.Peek();
            result.Add(median);
        }
        return result;
    }

    private static void Rebalance(MinHeap minHeap, MaxHeap maxHeap)
    {
        var root = minHeap.ExtractMin();
        maxHeap.Insert(root);
    }
    private static void Rebalance(MaxHeap maxHeap, MinHeap minHeap)
    {
        var root = maxHeap.ExtractMax();
        minHeap.Insert(root);
    }
}
