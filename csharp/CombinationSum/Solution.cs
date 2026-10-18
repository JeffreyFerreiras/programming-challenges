namespace CombinationSum;

public class Solution
{
    /// <summary>
    /// Finds all unique combinations in candidates where the candidate numbers sum to target.
    /// </summary>
    /// <param name="candidates">An array of unique integers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>A list of all unique combinations that sum to the target.</returns>
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        //[2,3,6,7] 7
        List<IList<int>> combinations = new(target);
        FindCombinations([], target, 0);
        return combinations;

        void FindCombinations(List<int> addends, int remainingTarget, int startIndex)
        {
            if (remainingTarget == 0)
            {
                combinations.Add([.. addends]); // if 0 is reached then its a valid combination
            }
            else if (remainingTarget > 0)
            {
                for (int i = startIndex; i < candidates.Length; i++)
                {
                    if (candidates[i] > remainingTarget) continue;
                    addends.Add(candidates[i]);
                    // reduce the target by the current elem,
                    // dont increment index since the next loop
                    // deeper in the stack will increment it,
                    // but the same number can be reused towards the answer.
                    FindCombinations(
                        addends,
                        remainingTarget - candidates[i],
                        i);
                    addends.RemoveAt(addends.Count - 1); //backtrack
                }
            }
        }
    }
}
