public abstract class Sorting
{
    protected void swap(List<int> arr, int idx1, int idx2)
    {
        var temp = arr[idx1];
        arr[idx1] = arr[idx2];
        arr[idx2] = temp;
    }

    public void PrintSortedList(List<int> arr)
    {
        string Sortedstring = $"[{string.Join(", ", arr)}]";
        Console.WriteLine(Sortedstring);
    }
    public abstract void Sort(List<int> arr);
}