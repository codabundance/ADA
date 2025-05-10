using System;

namespace Graph.Problems;
/*
Snakes And Ladders Matrix
Find the minimum number of die rolls necessary to reach the final cell of the given Snakes and Ladders board game.

Rules are as usual. Player starts from cell one, rolls a die and advances 1-6 (a random number of) steps at a time. Should they land on a cell where a ladder starts, the player immediately climbs up that ladder. Similarly, having landed on a cell with a snake’s mouth, the player goes down to the tail of that snake before they roll the die again. Game ends when the player arrives at the last cell.

The function has two input arguments:

n, size of the board, and
moves, array of integers defining the snakes and ladders:
moves[i] = -1: no ladder or snake starts at i-th cell
moves[i] < i: snake from i down to moves[i]
moves[i] > i: ladder from i up to moves[i]
The indices and values in moves array are zero-based, for example moves[1] = 18 means there is a ladder from cell 2 up to cell 19.

Example One
{
"n": 20,
"moves": [-1, 18, -1, -1, -1, -1, -1, -1, 2, -1, -1, -1, 15, -1, -1, -1, -1, -1, -1, -1]
}
Output:

2
*/


// Approach : We can consider this whole board as a directed graph
// Each node with value = -1 will have 6 adjacent edges equivalent to values on the dice
// For each snake and ladder node replace the value of that node with the node it points to.
// Now once we have formed the directed graph. We need to find the minimum number of edges required to reach from 1 to n i.e shortest path.
// Remember the board starts with index 1 but our case it starts with 0.
// Shortest Path - We always ue BFS because it goes level by level. The shortest path is given by number of levels we move to reach from src to dest.
// Because if with every edge we also move a level down, that has to be the shortest path.
// We cannot add edges as shortest path because there can be edges between nodes on the same level
// So, ideally to find shortest path, we maintain an array distance which will contain distance of each node from the source i.e. level of each node
// The shortest path length to the destination will be given by disance[dest].
public class SnakeAndLadder
{
    public static int minimum_number_of_rolls(int n, List<int> moves) 
    {
        // Write your code here.
        bool[] visited = new bool[n];
        int[] distance = new int[n];
        for(int i = 0; i < n;i++)
           distance[i] = -1;
        // Outer loop not required here because we know where to start i.e. 0.
        // If we dont know where to start and we have to try starting from every node, we need outer loop.
        BFS(n,moves,visited, distance);
        return distance[n-1];
    }

    private static void BFS(int n, List<int> moves,bool[] visited, int[] distance)
    {
        int dist = 0;
        Queue<int> queue = new();
        queue.Enqueue(0);
        visited[0] = true;
        distance[0] = dist;
        while (queue.Count > 0) 
        {
            // dist = dist+1; We cannot do this because while loop does not necessarily correspond to every layer
            // Once we have added the next 6 adjacents for 1st element in a layer1 (It adjacent has layer2)
            // we move to add adjacents of next element in layer1. This while loop will be executed everytime we move to next element in same layer.
            // if we do dist+1, then the next elements' (level1) adjacents will be on level3 instead of level 2 which is wrong. 
            // They should also be on level 2
            var current = queue.Dequeue();
            //All possible dice values or all possible adjacent edges. These will be on same level so set distance as same for them
            for(int i = 1; i <= 6;i++)
            {
                int dest = current+i;
                if(dest < n)
                {
                    // snake or ladder.
                    if(moves[dest] != -1)
                    {
                        dest = moves[dest];
                    }
                    if(!visited[dest])
                    {
                        visited[dest] = true;
                        // we need to increase the level everytime.
                        distance[dest] = distance[current] + 1;
                        queue.Enqueue(dest);
                    }
                }
            }
        }
    }

    public static int minimum_number_of_rolls_v2(int n, List<int> moves) {
        var visited = new bool[n];
		var que = new Queue<(int,int)>();
		que.Enqueue((0,0));
		visited[0]=true;

		while (que.Count>0)
		{
			var (current,steps) = que.Dequeue();
			if (current==n-1)
			{
				return steps;
			}

			for (int i=1;i<=6;i++)
			{
				var next = Math.Min(current+i,n-1);
				if (moves[next]!=-1)
				{
					next = moves[next];
				}

				if (!visited[next])
				{
					visited[next]=true;
					que.Enqueue((next,steps+1));
				}
			}
		}
		return -1;
    }
}
