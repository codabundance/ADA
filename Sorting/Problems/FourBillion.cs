using System;
using System.Collections;

namespace Sorting.Problems;
/**************************************************************
Given four billion of 32-bit integers, return any one that’s not among them. Assume you have 1 GiB (10243 bytes) of memory.
The numbers would all appear one after consecutively and then one of them will not be available.
Follow up: what if you only have 10 MiB of memory?
***************************************************************/
public class FourBillion
{
     public static long find_integer(List<int> arr) {
        // Write your code here.
        // For storing 4 billion integers, we need  4 billion*4 bytes = 4*2pow(32)*4 = 16GB
        // So we can use bitmaps to represent each number instead of 4 bytes or 32 bits. Thus space required gets
        // divided by 32 i.e. 1/2 GiB
        //int size = (int)Math.Pow(2, 32)/8;
        int size = (int)(arr.Count/8)+1;
        byte[] byteArr = new byte[size];
        
        for(int i = 0; i < arr.Count; ++i) {
            if (arr[i] > arr.Count) {
                continue;
            }
            int idx = (int)(arr[i] / 8);
            int offset = (int)(arr[i] % 8);
            
            byte temp = (byte)(1 << offset);
            byteArr[idx] |= temp;
        }
        
        for(int i = 0; i < size; ++i) {
            for (int j = 0; j < 8; ++j) {
                //byte temp = 1 << j;
                if ((byteArr[i] & (1 << j)) == 0) {
                    return i * 8 + j;
                }
            }
        }
        
        // Write your code here.
        return -1;
    }
}
