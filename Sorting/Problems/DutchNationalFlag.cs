using System;

namespace Sorting.Problems;
/**************************************************************
Given some balls of three colors arranged in a line, rearrange them such that all the red balls go first, then green and then blue 
ones.

Do rearrange the balls in place. A solution that simply counts colors and overwrites the array is not the one we are looking for.

This is an important problem in search algorithms theory proposed by Dutch computer scientist Edsger Dijkstra. Dutch national 
flag has three colors (albeit different from ones used in this problem)
**************************************************************/
public class DutchNationalFlag
{

    public static List<char> Dutch_flag_sort_1(List<char> balls) {
        // Write your code here.
        // We will have 3 pointers - red, green, blue
        // We will make red as the border for Red color elements and similarly for others
        int red=0;
        int green=0;
        int blue = balls.Count-1;
        while(green <= blue)
        {
            if(balls[green] == 'R')
            {
                swap(balls,green,red);
                red++;
                green++;
            }
            else if(balls[green] =='G')
                green++;
            else
            {
                swap(balls,blue,green);
                blue--;
            }
        }
        return balls;
    }
    private static void swap(List<char> arr, int i, int j)
    {
        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static List<char> dutch_flag_sort_2(List<char> balls) {
        // We can do 2 iterations of the array because there are only 3 types of balls.
        // First iteration - group all the Rs
        // second iteration - group all the Gs
        // But what if there are more than 3 types even 10 tyoes. We cannot create 9 iterations
        int left = 0;
        int right = balls.Count - 1;
        while(left <= right)
        {
            if(balls[right] == 'R')
            {
                swap(balls,left,right);
                left++; 
            }
            else
            {
                right--;
            }
        }
        //left = left-1;
        //left is already at one position beyond R array stops, so no need to maniplate left
        // Right needs to be set again to n-1
        // We are rrepeating the same steps once we have put all Rs in correct place but not touching any R this time.
        right = balls.Count - 1;
        while(left <= right)
        {
            if(balls[right] == 'G')
            {
                swap(balls,left,right);
                left++;
            }
            else
            {
                right--;
            }
        }
        return balls;
    }
}
