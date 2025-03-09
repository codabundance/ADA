// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Sorting.SortingAlgos;

Console.WriteLine("Please selecte a sorting methodology:");
Console.WriteLine("1. Bubble Sort");
Console.WriteLine("2. Selection Sort");
Console.WriteLine("3. Merge Sort");
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
sorting = value switch
{
    1 => new BubbleSort(),
    2 => new SelectionSort(),
    3 => new MergeSort(),
    _ => default,
};

sorting?.Sort(list);
sorting?.PrintSortedList(list);
