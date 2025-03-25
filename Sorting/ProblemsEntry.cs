using System;
using Sorting.Problems;

namespace Sorting;

public class ProblemsEntry
{
    /*
    {
"p_x": 1,
"p_y": 1,
"k": 1,
"n_points": [
[0, 0],
[1, 0]
]
}
    */
    public void EnterProblems()
    {
        //var nearest = new NearestPoints();
        //nearest.nearest_neighbours(1,1,1,[[0,0],[1,0]]);
        var JuliusCaesar = new AndOrImplementationDictionary();
        JuliusCaesar.AND([1,3,4,11,13,15,22,31,34,53], [1,3,5,17,18,21,22,33,34,51]);
        JuliusCaesar.OR([1,3,4,11,13,15,22,31,34,53], [1,3,5,17,18,21,22,33,34,51]);
    }
}
