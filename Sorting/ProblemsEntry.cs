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
        var nearest = new NearestPoints();
        nearest.nearest_neighbours(1,1,1,[[0,0],[1,0]]);
    }
}
