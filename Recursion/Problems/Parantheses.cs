using System;

namespace Recursion;

public class Parantheses
{
    public List<string> BalancedParantheses(int n)
    {
        List<string> result = new List<string>();
        Helper(n,result,"",0,0);
        return result;
    }
    private static void Helper(int n, List<string> result, string slate, int open, int close)
    {
        // These are 2 cases where recursion should stop
        // 1. When we have added more open parantheses than 'n'. In that case even if we add
        // more close parantheses we can add max n-1, so it will never be balanced
        // 2. If the count of open parantheses is less than close, this means we have added
        // more close parantheses, so balancing is not possible. This includes the case where
        // the first added parantheses is ")"
        if(open > n || open < close)
           return;
        if(slate.Length == 2*n)
        {
            result.Add(slate);
            return;
        }
        Helper(n, result, slate + "(", open + 1, close);
        Helper(n, result, slate + ")", open, close + 1);
    }

    // One more approach where instead of returning, we restrict the recursion tree itself
    private static void Helper_1(int n, List<string> result, string slate, int openCount, int closeCount)
    {
        if(slate.Length == 2*n)
        {
            result.Add(slate);
            return;
        }
        // We restrict the Open parantheses recursion tree if the number of open paranthesese
        // already added is more than "n".
        if(openCount < n)
            Helper_1(n, result, slate + "(", openCount + 1, closeCount);
        // We restrict the Close parantheses recursion tree if the number of close paranthesese
        // already more than open count.
        if(closeCount < openCount)
            Helper_1(n, result, slate + ")", openCount, closeCount + 1);
    }
}
