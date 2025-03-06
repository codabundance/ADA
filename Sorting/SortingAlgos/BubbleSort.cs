
public class BubbleSort : Sorting
{
    public override void Sort(List<int> arr)
    {
        int n = arr.Count;
        for(int i=0;i<n;i++) // This for loop does not do any wrk, it's just there to iterate over array
        {
            for(int j=n-1; j >=1;j--) // All the work is done by this for loop, where it goes through as many times through the array 
            //as defined by outer loop and fixes the "kth" largest element with "kth" iteration to it's correct place.
            {
                if(arr[j] < arr[j-1])
                {
                    swap(arr,j,j-1);
                }
            }
        }
    }
}