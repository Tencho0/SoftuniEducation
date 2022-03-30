using System;
using System.Linq;

namespace T7.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string lane = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = lane[col];
                }
            }

            int removedKnights = 0;
            while (true)
            {
                int maxAttack = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == '0')
                        {
                            continue;
                        }
                        int currAttack = 0;
                        // UpLeft UpRight
                        if (IsInRange(board, row -2 , col -1) && board[row - 2, col - 1] == 'K')
                        {
                            currAttack++;
                        }

                        if (IsInRange(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currAttack++;
                        }

                        if (IsInRange(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currAttack++;
                        }

                        if (IsInRange(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currAttack++;
                        }

                        if (IsInRange(board, row + 2, col - 1) && board[row + 2 , col - 1] == 'K')
                        {
                            currAttack++;
                        }

                        if (IsInRange(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currAttack++;
                        }

                        if (IsInRange(board, row + 1 , col +2) && board[row + 1, col +2] == 'K')
                        {
                            currAttack++;
                        }

                        if (IsInRange(board, row - 1, col +2) && board[row - 1, col + 2] == 'K')
                        {
                            currAttack++;
                        }

                        if (currAttack > maxAttack)
                        {
                            maxAttack = currAttack;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if (maxAttack > 0)
                {
                    board[knightRow, knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedKnights);



            //int removedCount = 0;
            //while (true)
            //{
            //    int maxAttack = 0;
            //    int maxAttackRow = 0;
            //    int MaxAttackCol = 0;
            //    for (int row = 0; row < board.GetLength(0); row++)
            //    {
            //        for (int col = 0; col < board.GetLength(1); col++)
            //        {
            //            if (board[row, col] == '0')
            //            {
            //                continue;
            //            }
            //            int currAttack = 0;
            //            for (int innerRow = 0; innerRow < board.GetLength(0); innerRow++)
            //            {
            //                for (int innerCol = 0; innerCol < board.GetLength(1); innerCol++)
            //                {
            //                    // TopLeft
            //                    if (innerRow - 2 > 0 && innerCol - 1 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }

            //                    // MidTopLeft
            //                    if (innerRow - 1 > 0 && innerCol - 2 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }

            //                    // TopRight
            //                    if (innerRow - 2 > 0 && innerCol +1 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }

            //                    //MidTopRight
            //                    if (innerRow - 1 > 0 && innerCol + 2 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }

            //                    // MidBotLeft
            //                    if (innerRow + 1 > 0 && innerCol - 2 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }

            //                    // BotLeft
            //                    if (innerRow + 2 > 0 && innerCol - 1 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }

            //                    //MidBotRight
            //                    if (innerRow + 1 > 0 && innerCol + 2 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }

            //                    // BotRight
            //                    if (innerRow + 2 > 0 && innerCol + 1 > 0)
            //                    {
            //                        if (board[innerRow, innerCol] == 'K')
            //                        {
            //                            currAttack++;
            //                        }
            //                    }
            //                }
            //            }
            //            if (currAttack > maxAttack)
            //            {
            //                maxAttackRow = row;
            //                MaxAttackCol = col;
            //            }
            //        }
            //    }
            //    if (maxAttack == 0)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        board[maxAttackRow, MaxAttackCol] = '0';
            //        removedCount++;
            //    }
            //}
            //Console.WriteLine(removedCount);
        }

        private static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
