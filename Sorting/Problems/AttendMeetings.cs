using System;

namespace Sorting.Problems;
/**************************************************************
Given a list of meeting intervals where each interval consists of a start and an end time, 
check if a person can attend all the given meetings such that only one meeting can be attended at a time.
***************************************************************/
public class AttendMeetings
{

    public static int Can_attend_all_meetings(List<List<int>> intervals) {
        var SortedByStartDate = intervals.OrderBy(x => x[0]);// sort the list within the list based on Start date i.e x[0];
        return CheckMeeting([.. SortedByStartDate]);
    }
    private static int CheckMeeting(List<List<int>> intervals)
    {
        for(int i=0;i<intervals.Count-1;i++)
        {
            if(intervals[i][1] > intervals[i+1][0]) // end time of current interval is greater than start time of next interval.
                return 0;
        }
        return 1;
    }
}
