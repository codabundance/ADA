using System;

namespace Sorting.Problems;
/**************************************************************
Given k linked lists where each one is sorted in the ascending order, merge all of them into a single sorted linked list.
***************************************************************/
public class MergeKSortedLists
{ 
    public static LinkedListNode Merge_k_lists(List<LinkedListNode> lists)
    {
        if(lists.Count == 0) 
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        return partition_merge(lists,0,lists.Count -1);
    }
    // Partition the list using merge sort algorithm. Once linked is partitioned and becomes null, start merging 2 lists.
    // When merging 2 lists the result list becomes 1st and the other list becomes 2nd.
    private static LinkedListNode partition_merge(List<LinkedListNode> lists, int start, int end)
    {
        if(start == end)//This means we have reached a position where only single nodes are left.
            return lists[start];
        int mid = start +(end-start)/2;
        var L1 = partition_merge(lists, start, mid); // Partition and Merge the 1st half and return the outcome as a list
        var L2 = partition_merge(lists, mid+1,end); // Partition and Mergr the 2nd half and return the outcome as a list
        return Merge2Lists(L1,L2); // Merge both the returned lists so that they are again sorted.
    }
    // Each Linked List is denoted by it's head node.
    private static LinkedListNode Merge2Lists(LinkedListNode L1, LinkedListNode L2)
    {
        if (L1== null) return L2;
        if (L2 == null) return L1;
        if(L1.value <= L2.value)
        {
            L1.next = Merge2Lists(L1.next, L2);
            return L1;
        }
        else
        {
            L2.next = Merge2Lists(L2.next,L1);
            return L2;
        }
    }
}
 public class LinkedListNode {
        public int value;
        public LinkedListNode next;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public LinkedListNode(int value) {
            this.value = value;
            this.next = null;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
