using System;

namespace DP.Problems;

public class Fibonnacci
{
    public static int Fib(int n)
    {
        int[] table = new int[n+1];
        table[0] = 0;
        table[1] = 1;
        for (int i = 0; i<n;i++)
        {
            table[i] = table[i-1] + table[i-2];
        }
        return table[n];
    }
}
