using System;

namespace DP.Problems;
/*
Cut The Rod To Maximize Profit
Given the prices for rod pieces of every size between 1 inch and n inches, find the maximum total profit that can be made by cutting an n inches long rod inch into pieces.

Example
{
"price ": [1, 5, 8, 9]
}
Output:

10
The rod can be cut in the ways given below:

1 + 1 + 1 + 1 inches will cost price[0] + price[0] + price[0] + price[0] = 4
1 + 1 + 2 inches will cost price[0] + price[0] + price[1] = 7
1 + 3 inches will cost price[0] + price[2] = 9
2 + 2 inches will cost price[1] + price[1] = 10
One piece of 4 inches will cost price[3] = 9
The maximum profit is obtained by cutting it into two pieces 2 inches each.
*/
public class RodCutting
{
    public static int Get_maximum_profit(List<int> price)
    {
        //We need to have the max profit that can be obtained by cutting a rod of size N
        // Let's say f(i) = max profit obtained by cutting a rod of size i
        // Then for reaching the ith cut, we could have either added  i-1, i-2, i-3,...,1 to the last cut.
        // So the f(i) = Max(price[1]+f(i-1),price[2]+ f(i-2), price[3]+f(i-3),...price[i-1]+f(1))
        // f(i) = Max(price[k] + f(i-k)) where k from 1 to i-1. 
        int n = price.Count;
        int[] dp = new int[n + 1];
        dp[0] = 0;
        for (int i = 1; i < dp.Length; i++)
        {
            dp[i] = dp[i - 1]; // We initialize the max profilt at length i as max profit at length i-1.
            for (int k = 1; k < i; k++)
            {
                dp[i] = Math.Max(dp[i], price[k - 1] + dp[i - k]);
            }
        }
        return dp[n];
    }

    private static int Helper(List<int> price, List<int> slate, int current, int runningSum)
    {
        if (slate.Count == price.Count)
            return runningSum + price[current];
        // Skip current.
        int left = Helper(price, slate, current + 1, runningSum);
        // Add Current
        slate.Add(current);
        runningSum = runningSum + price[current];
        int right = Helper(price, slate, current + 1, runningSum);
        //Pop after return
        slate.RemoveAt(slate.Count - 1);
        //return max of both left and right.
        return Math.Max(left, right);
    }
    
    public static int get_maximum_profit(List<int> price) {
        // Write your code here.
        List<(List<int>,int)> result = new();
        GenerateAllPossibleLengths(price.Count, price, [],result);
        var maxProfitWay = result.OrderByDescending(x => x.Item2).First();
        return maxProfitWay.Item2; 
    }
    
    private static void GenerateAllPossibleLengths(int N, List<int> prices, List<int> current, List<(List<int>,int)> result)
    {
        if(N==0) // entire rod is cut
        {
            int currentPrice = 0;
            for(int k=0;k<current.Count;k++)
                currentPrice = currentPrice + prices[k];
            result.Add((new List<int>(current),currentPrice));
            return;
        }
        for(int i=1; i<=N;i++)
        {
            current.Add(i);
            GenerateAllPossibleLengths(N-i, prices, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }

    

}
