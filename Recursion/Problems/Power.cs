using System;

namespace Recursion;
/* Given a base a and an exponent b. Your task is to find ab. The value could be large enough. So, calculate ab % 1000000007.*/
public class Power
{
    // Naie approach. We can also convert below code into recursive call.
    public static int calculate_power(long a, long b) {
        // Write your code here.
        long answer = 1L;
        for(int i=0;i<b;i++)
        {
            answer *= a;
        }
        int retvalue =(int) (answer % 1000000007);
        return retvalue;
    }

    public static long calculate_power_recur(long a, long b) {
        // Write your code here.
        if(b == 0)  return 1;
        if(b == 1) return a;
        var temp = a % 1000000007;
        if(b % 2 == 0) // b is even
            return calculate_power_recur(a, b/2) % 1000000007 * calculate_power_recur(a,b/2) % 1000000007 % 1000000007;
        else
            return calculate_power_recur(a, b/2) % 1000000007 * calculate_power_recur(a,b/2) % 1000000007 % 1000000007 * (a % 1000000007);
    }
}
