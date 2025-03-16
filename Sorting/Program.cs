// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Sorting.SortingAlgos;

Console.WriteLine("Please selecte a sorting methodology:");
Console.WriteLine("1. Bubble Sort");
Console.WriteLine("2. Selection Sort");
Console.WriteLine("3. Merge Sort");
Console.WriteLine("4. Heap Sort");
Console.WriteLine("5. Quick Sort");
var value = int.Parse(Console.ReadLine());
Console.WriteLine("Please enter the array elements separated by comma");
var arr = Console.ReadLine();
var temp = arr?.Split(',');
List<int> list = [];
foreach(var item in temp)
{
    list.Add(int.Parse(item));
}
SortingBase sorting;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
sorting = value switch
{
    1 => new BubbleSort(),
    2 => new SelectionSort(),
    3 => new MergeSort(),
    4 => new HeapSort(),
    5 => new QuickSort(),
    _ => default,
};
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

sorting?.Sort(list);
sorting?.PrintSortedList(list);
