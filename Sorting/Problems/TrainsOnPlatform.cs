using System;

namespace Sorting.Problems;

public class TrainsOnPlatform
{
    List<int> arrivals = [900, 940, 950, 1100, 1500, 1800];
    List<int> departures = [910, 1200, 1120, 1130, 1900, 2000] ;
    public int Solve()
    {
        arrivals.Sort();
        departures.Sort();
        int arr = 0;
        int dep = 0;
        int maxPlatformRequired = 0;
        int platform_count = 0;
        while(arr < arrivals.Count && dep < departures.Count)
        {
            if(arrivals[arr] < departures[dep])
            {
                platform_count++;
                if(platform_count > maxPlatformRequired)
                {
                    maxPlatformRequired = platform_count;
                }
                arr++;
            }
            else
            {
                platform_count--;
                dep++;
            }
        }
        return maxPlatformRequired;
    }
}
