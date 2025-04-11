using System;

namespace Sorting;

using System;
using System.Collections.Generic;

public class MaxHeap
{
    private List<int> heap;
    public int Count => heap.Count;
    public MaxHeap()
    {
        heap = new List<int>();
    }

    private int Parent(int i) => (i - 1) / 2;
    private int Left(int i) => 2 * i + 1;
    private int Right(int i) => 2 * i + 2;

    private void Swap(int i, int j)
    {
        int tmp = heap[i];
        heap[i] = heap[j];
        heap[j] = tmp;
    }

    public void Insert(int key)
    {
        heap.Add(key);
        int i = heap.Count - 1;

        // Bubble up
        while (i != 0 && heap[Parent(i)] < heap[i])
        {
            Swap(i, Parent(i));
            i = Parent(i);
        }
    }

    public int Peek()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");
        return heap[0];
    }

    public int ExtractMax()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");

        int root = heap[0];

        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        Heapify(0);
        return root;
    }

    private void Heapify(int i)
    {
        int largest = i;
        int l = Left(i);
        int r = Right(i);

        if (l < heap.Count && heap[l] > heap[largest])
            largest = l;

        if (r < heap.Count && heap[r] > heap[largest])
            largest = r;

        if (largest != i)
        {
            Swap(i, largest);
            Heapify(largest);
        }
    }

    public void BuildHeap(int[] array)
    {
        heap = new List<int>(array);
        for (int i = heap.Count / 2 - 1; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    public void IncreaseKey(int i, int newVal)
    {
        if (newVal < heap[i])
            throw new ArgumentException("New value is less than current value");

        heap[i] = newVal;
        while (i != 0 && heap[Parent(i)] < heap[i])
        {
            Swap(i, Parent(i));
            i = Parent(i);
        }
    }

    public void DecreaseKey(int i, int newVal)
    {
        if (newVal > heap[i])
            throw new ArgumentException("New value is greater than current value");

        heap[i] = newVal;
        Heapify(i);
    }
}

