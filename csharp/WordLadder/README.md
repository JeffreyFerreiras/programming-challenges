# Word Ladder

[LeetCode 127 — Word Ladder](https://leetcode.com/problems/word-ladder/)

## Problem Statement

Transform `beginWord` into `endWord` by changing one letter at a time. Every resulting word must belong to `wordList`; the starting word does not have to appear there.

Return the fewest words needed in a valid sequence, counting both endpoints. Return `0` when no sequence is possible.

## Examples

```text
Input: beginWord = "hit", endWord = "cog"
       wordList = ["hot", "dot", "dog", "lot", "log", "cog"]
Output: 5

Input: beginWord = "hit", endWord = "cog"
       wordList = ["hot", "dot", "dog", "lot", "log"]
Output: 0
```

## Constraints

- Word lengths range from 1 to 10; all inputs use the same word length.
- The dictionary contains between 1 and 5,000 unique words.
- All words contain only lowercase English letters.
- The starting and ending words are different.

## Running

Implement `LadderLength` in `Solution.cs`, then run from the C# repository directory:

```powershell
dotnet run --project WordLadder/WordLadder.csproj
```

The runner discovers public methods with the same signature, prints timing and expected results, and reports unimplemented methods as `PENDING`.
