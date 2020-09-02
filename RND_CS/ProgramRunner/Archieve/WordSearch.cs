using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class WordSearch : Runner
    {
        public class Solution
        {
            public bool exist(char[][] board, string word)
            {

                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[0].Length; j++)
                    {
                        if (dfs(board, word, 0, i, j))
                            return true;
                    }
                }
                return false;
            }

            bool dfs(char[][] board, string word, int index, int row, int col)
            {

                if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length || board[row][col] == '\0')
                    return false;

                char ch = board[row][col];

                board[row][col] = '\0'; // empty the cell

                if (ch != word[index])
                {
                    board[row][col] = ch;
                    return false;
                }

                if (ch == word[index] && index == word.Length - 1)
                    return true;

                bool found;
                found = dfs(board, word, index + 1, row, col + 1)
                    || dfs(board, word, index + 1, row + 1, col)
                    || dfs(board, word, index + 1, row, col - 1)
                    || dfs(board, word, index + 1, row - 1, col);

                if (!found)
                {
                    board[row][col] = ch;// revert
                }
                return found;
            }
        };
        public override void Run(string[] args)
        {
            var board = new char[][] { new char[] { 'a', 'b' } };
            var sol = new Solution();
            Debug.Assert(() => sol.exist(board, "ba"), true);
        }
    }
}
