using System;
using System.Runtime.InteropServices;

namespace Sorting.Problems;

public class NearestPoints
{
    /**********************************
    Given coordinates of a point p and n other points on a two-dimensional surface, find k points out of n which are the nearest to point p.
    **********************************/
    public List<List<int>> nearest_neighbours(int p_x, int p_y, int k, List<List<int>> n_points) {
        // Write your code here.
        List<List<int>> result = []; 
        // form an array with all the distances for each point from p_x, p_y
        // Map the values in each with 
        List<Point> points = [];
        for(int i=0; i<n_points.Count; i++)
        {
            double dist = Math.Sqrt(Math.Pow(p_x - n_points[i][0],2)+ Math.Pow(p_y - n_points[i][1],2));
            points.Add(new Point(i, dist));
        }
        Kth_Smallest_Element(points,k);
        for(int i=0; i<=k-1;i++)
        {
            result.Add(n_points[points[i].index]);
        }
        return result;
    }
    public static void Kth_Smallest_Element(List<Point> arr, int k)
    {
        int idx = k-1;
        int n = arr.Count;
        Helper(arr,idx,0,n-1);
    }
    private static void Helper(List<Point> arr, int idx, int start, int end)
    {
        if(start > end)
            return;
        //Lomuto's partitioning.
        int pivot = new Random().Next(start,end+1); // Not randomized pivot, but first element as the pivot
        Swap(arr,pivot,end);
        int g = start;
        int r = start+1;
        while(r <= end)
        {
            if(arr[r].distance < arr[pivot].distance)
            {
                g++;
                Swap(arr,g,r);
            }
            r++;
        }
        Swap(arr, pivot, g);// Bring the pivot at it's correct position, because after every partitioning, the pivot will be frozen
        if(g == idx) // If pivot is the index we are looking for return. idx will be the index of pivot i.e. g
            return;
        if(g < idx) // Else if pivot's index i.e. g is less than idx, then search on right side of pivot
        {
            Helper(arr, idx, g+1, end);
        }
        else // if pivot's index i.e. g is greater than idx, then search on the left side of pivot.
        {
            Helper(arr, idx, start, g-1);
        }
    }
    private static void Swap(List<Point> arr, int a, int b)
    {
        (arr[b], arr[a]) = (arr[a], arr[b]);
    }
}

public class Point
{
    public double distance;
    public int index;
    public Point(int idx, double dist)
    {   
        distance = dist;
        index = idx;
    }
}
