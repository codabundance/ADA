using System;

namespace Recursion.Problems;
/*
Tower of Hanoi is a mathematical puzzle where we have three pegs and n disks. The objective of the puzzle is to move the entire stack to another peg, obeying the following simple rules:

Only one disk can be moved at a time.
Each move consists of taking the upper disk from one of the stacks and placing it on top of another stack i.e. a disk can only be moved if it is the uppermost disk on a stack.
No disk may be placed on top of a smaller disk.
Given n denoting the number of disks in the first peg, return all the steps required to move all disks from the first peg to the third peg in minimal number of steps.

Example
{
"n": 4
}
Output:

[
[1, 2],
[1, 3],
[2, 3],
[1, 2],
[3, 1],
[3, 2],
[1, 2],
[1, 3],
[2, 3],
[2, 1],
[3, 1],
[2, 3],
[1, 2],
[1, 3],
[2, 3]
]
Following steps:

[1, 2] = Shift top disk of the first peg to top of the second peg.
Picture after this step will be:
First peg: 2 3 4
Second peg: 1
Third peg: Empty

[1, 3] = Shift top disk of the first peg to top of the third peg.
Picture after this step will be:
First peg: 3 4
Second peg: 1
Third peg: 2

Similarly after following remaining steps, the final configuration will be:
First peg: Empty
Second peg: Empty
Third peg: 1 2 3 4

Hence, our objective is achieved.
*/
public class TowerOfHanoi
{
    public static List<List<int>> Tower_of_hanoi(int n) {
        // Write your code here.
        var results = new List<List<int>>();
        Move(1,2,3,n,results);
        return results;
    }
    
    private static void Move(int source, int aux, int dest, int n, List<List<int>> results)
    {
        if(n == 1)// base case, we just need to move one peg to the destination from source
        {
            results.Add([source, dest]);
            return;
        }
        //move n-1 disk from source to aux. Iterating over n-1 will be taken care by recusrsion
        Move(source, dest, aux, n-1, results);// This keeps one calling until last element
        // move current disk from source to dest
        Move(source, aux, dest, 1, results);
        // move n-1 disks from aux to dest
        Move(aux, source, dest, n-1, results);
    }
}
