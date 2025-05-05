using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DP.Problems;
/*
Consider you have n distinct elements, find the number of ways through which you can choose exactly r number of elements out of those.

Example One
{
"n": 5,
"r": 3
}
Output:

10
There is a set of 5 elements {1, 2, 3, 4, 5}. You need to pick a subset of size 3. Eligible subsets are {1, 2, 3}, {1, 2, 4}, {1, 2, 5}, {1, 3, 4}, {1, 3, 5}, {1, 4, 5}, {2, 3, 4}, {2, 3, 5}, {2, 4, 5}, {3, 4, 5}. There are 10 subsets of size 3.

Example Two
{
"n": 3,
"r: 5
}
Output:

0
There is a set of 3 elements {1, 2, 3}. You need to pick a subset of size 5. Which is not possible, that's why the answer is 0.
*/
public class NChooseR
{
    public static int ncr(int n, int r) 
    {
        // Write your code here.
        // f(n,r) = f(n-1,r) + f(n-1,r-1);
        // base case - c(n,n)=1 & c(n,0)=1

        // Here we are building the entire matrxi, but we can choose to build only diagonally lower matrix which is required.
        if(n < r)
            return 0;
        if(n ==r || r==0)
            return 1;
        int[,] dp = new int[n+1, r+1]; // Because our solution resides at [n,r] and this is a 0 based index so total size will be n+1 and r+1
        for(int i=0;i<n;i++)
        {
           dp[i,0] = 1;
        }
        for(int j=0;j< r;j++)
        {
            dp[j,j] = 1;
        }
        //row starts from 2 bcause we don't want any computation on 0th and 1st row. See matrix diagram
        for(int row = 2; row <= n; row++)
        {
            // We dont have to go to the entire k because after diagonal value the value of k is illegal. So, it can only vary till row
            // but once row is greater than r, it will be r only. So, min of (row,r)

            //col starts from 1 because we want to do some operation on 1st column
            for(int col = 1; col <= Math.Min(r,row); col++)
            {
                dp[row,col] = (dp[row-1,col] + dp[row-1,col-1])%1000000007;
            }
        }
        return dp[n,r];
    }
}
