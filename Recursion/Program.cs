// See https://aka.ms/new-console-template for more information
using Recursion;
using Recursion.Problems;

/*PalindromicSubstring palindromicSubstring= new();
var result = palindromicSubstring.generate_palindromic_decompositions("abaca");
for(int i=0; i<result.Count; i++)
{
    Console.WriteLine(result[i]);
}*/
/*Parantheses perm = new();
var result = perm.BalancedParantheses(3);
foreach(var res in result)
{
    Console.WriteLine(string.Join(",",res));
}*/
/*SubarraySum sum = new();
var result = sum.Subarray_Sum([1,1,1],2);
Console.WriteLine(result);
*/
//PowerSet set = new();
//var result = set.GetPowerSet([1,2,3]);
//var result = Combinations.GetCombinations([1,2,3,4,5], 2);
//result.ForEach(x =>Console.WriteLine(string.Join(",",x)));
// List<Item> items = [new Item("Macbook",3,3), new Item("Iphone",2,2), new Item("Jewellery",3,2), new Item("Handbag",4,5), new Item("Watch",1,2)];
// Knapsack sack = new();
// sack.GetItems(items, 7);
// Console.WriteLine($"Max Profit is:{sack.max_profit}");
// sack.items_with_max_profit.ForEach(x => Console.WriteLine($"Name:{x.Name}, Weight:{x.weight}, Price:{x.price}"));
var result = StringsWithWildCharachter.find_all_possibilities("1?10");
foreach (var result_item in result)
{
    Console.WriteLine(result_item);
}


