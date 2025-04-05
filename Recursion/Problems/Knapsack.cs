using System;
using System.Runtime.CompilerServices;

namespace Recursion;
/*
There are n itens with their weight and prices. We have to pick the items which would yield the maximum price within a given weight limit 
say capacity. Return the items which would give maximum price. If we cannot find 
*/
public class Knapsack
{
    public int max_profit;
    public List<Item> items_with_max_profit = [];
    public void GetItems(List<Item> items, int capacity)
    {
        Helper(items, capacity,0,[],0,0);
    }
    private void Helper(List<Item> items, int capacity, int index, List<Item> slate, int rw, int rp)
    {
        // rw increases capacity, we dont add this to our solution
        if(rw > capacity)
            return;
        // running weight is border line, we check if the max sum of prices of items in slate is greater than
        // max profit, then replace max profit with the slate sum and also copy slate items as items having max profit.
        if(rw == capacity)
        {
            if(rp >  max_profit )
            {
                items_with_max_profit = [..slate];
                max_profit = rp;
            }
            return;
        }
        // If capacity is never reached, e.g. capacity = 100 and weight of items is 10,15,20,25,30.
        // Whatever we have added to the slate by the time we exhaust all the items becomes max profit
        // BTW we can combine this with the previus if condition.
        if(index == items.Count)
        {
            if(rp >  max_profit )
            {
                items_with_max_profit = [..slate];
                max_profit = rp;
            }
            return;
        }
        //If NOTA satisfies, we will include the current item and then exclude it
        //Include
        slate.Add(items[index]);
        Helper(items, capacity, index + 1,slate , rw + items[index].weight, rp + items[index].price);
        slate.RemoveAt(slate.Count - 1); // Popping the last element

        //Exclude
         Helper(items, capacity, index + 1,slate , rw, rp);
    }
}

public class Item
{
    public string Name;
    public int weight;
    public int price;
    public Item(string name, int weight, int price)
    {
        this.Name = name;
        this.weight = weight;
        this.price = price;
    }
}
