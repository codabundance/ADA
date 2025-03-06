
public class SelectionSort : Sorting
{
    public override void Sort(List<int> arr)
    {
        for(int i=0;i<arr.Count;i++)
        {
            int minIndex = i;
            //find the smallest element in each subarray starting at i.
            for(int j=i;j<arr.Count;j++)
            {
                if(arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            //Once smallest element is found put it in right position by swapping it with i.
            swap(arr,i,minIndex);
        }
    }
}