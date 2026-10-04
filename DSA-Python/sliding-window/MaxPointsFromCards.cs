/* Given an array of integers representing card values, write a function to calculate the maximum score you can achieve by 
picking exactly k cards.

You must pick cards in order from either end. You can take some cards from the beginning, then switch to taking cards from 
the end, but you cannot skip cards or pick from the middle. */



// We can convert this into sliding window by making the problem statement as
// Select a window of size n-k, where the sum of the window is minimum (so that total-sum becomes max)
// Because we can pick any card from starting or from end, it will always leave a continous window of cards in middle which are
// not picked. We apply sliding window on this "not picked" cards, but not max but min.
public class Solution {
  public int maxScore(int[] cards, int k) {
    // Your code goes here
    int maxPoints = 0;
    int state = 0;
    int total = 0;
    int start = 0;
    foreach (var card in cards) total += card;
    int n = cards.Length;
    if (k == n)
      return total;

    for (int end = 0; end < n; end++) {
      state += cards[end];
      if (end - start + 1 == n - k) {
        maxPoints = Math.Max(total - state, maxPoints);
        state -= cards[start];
        start++;
      }
    }
    return maxPoints;
  }
}