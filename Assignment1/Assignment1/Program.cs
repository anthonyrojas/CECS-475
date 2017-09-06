/************************************************************
 *                      Anthony Rojas                       *
 *                      ID#011819338                        *
 *                      CECS 475                            *
 *                      Assignment 1                        *
 ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.PrintBoard();
            game.Play();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }//end main class Program

    public class TicTacToe
    {
        private const int BOARDSIZE = 3;
        private int[,] board;
        private int player1;
        private int player2;
        public TicTacToe()
        {
            board = new int[BOARDSIZE, BOARDSIZE];
            InitializeBoard();
            player1 = 0;
            player2 = -1;
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    if (i > 0)
                    {
                        board[i, j] = board[i - 1, BOARDSIZE - 1] + (j + 1);
                    }
                    else
                    {
                        board[i, j] = (j + 1) * (i + 1);
                    }
                }
            }
        }



        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == player1)//player 1 = X
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\tX\t");
                    }
                    else if (board[i, j] == player2)//player 2 = O
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\tO\t");
                    }
                    else//space has not been allocated by either player 1 or player 2
                    {
                        Console.Write("\t" + board[i, j] + "\t");
                    }
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n");
        }

        public Boolean CheckWinner(int player)
        {
            if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player)
            {//row 0
                return true;
            }
            else if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player)
            {//row 2
                return true;
            }
            else if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player)
            {//row 3
                return true;
            }
            else if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player)
            {//column 1
                return true;
            }
            else if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player)
            {//column 2
                return true;
            }
            else if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player)
            {//column 3
                return true;
            }
            else if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {//foward diagonal
                return true;
            }
            else if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {//backward diagonal
                return true;
            }
            return false;//default has not won
        }

        public void Play()
        {
            int moveCount = 0;
            bool gameOver = false;
            Console.WriteLine("Player 1: X \t\t Player 2: O");
            while (!gameOver)
            {
                moveCount++;
                if (moveCount % 2 != 0)
                {//player 1
                    MakeMove(player1);
                    if (CheckWinner(player1) == true)
                    {
                        Console.WriteLine("\nPlayer 1 Wins!");
                        PrintBoard();
                        return;
                    }
                }
                else
                {
                    MakeMove(player2);
                    if (CheckWinner(player2) == true)
                    {
                        Console.WriteLine("\nPlayer 2 Wins!");
                        PrintBoard();
                        return;
                    }
                }
                if (moveCount == (BOARDSIZE*BOARDSIZE))
                {
                    gameOver = true;
                    if (CheckTie(moveCount) == true)
                    {
                        gameOver = true;
                        Console.WriteLine("It's a tie!");
                    }
                }
                PrintBoard();
            }
        }

        public void MakeMove(int player)
        {
            string moveSelect;
            string playerIndicator = "";
            if (player == 0)
            {//player 1 turn
                playerIndicator = "Player 1 (X)";
            }
            else
            {//player 2 turn
                playerIndicator = "Player 2 (O)";
            }
            do
            {
                Console.WriteLine(playerIndicator + " turn.");
                Console.WriteLine("Enter an integer corresponding to the location on the board you would like to move to. (1-9)");
                moveSelect = Console.ReadLine();
            } while (ValidateInput(moveSelect) == false);
            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    if (Convert.ToInt32(moveSelect) == board[i, j])
                    {
                        board[i, j] = player;
                        i = BOARDSIZE;
                        j = BOARDSIZE;
                    }
                }
            }
        }

        public Boolean ValidateInput(object moveSelect)
        {
            int move = 0;
            try
            {
                move = Convert.ToInt32(moveSelect);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Entry must be an integer. Try again.");
                PrintBoard();
                return false;

            }
            Console.WriteLine("Move: " + move);
            if (move <= 0 || move > (BOARDSIZE * BOARDSIZE))
            {
                Console.WriteLine("Move selection is out of bounds. Try again");
                PrintBoard();
                return false;
            }
            if (move > 0 && move <= (BOARDSIZE * BOARDSIZE) && ValueExists(move) == false)
            {
                Console.WriteLine("That space is taken. Please select a space with an available value from 1-9 on the board.");
                PrintBoard();
                return false;
            }
            return true;
        }

        public Boolean ValueExists(int moveSelect)
        {
            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    if (board[i, j] == moveSelect)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean CheckTie(int numMoves)
        {
            if (numMoves == (BOARDSIZE * BOARDSIZE))//checks if there are no places to make a move to
            {
                return true;
            }
            return false;
        }
    }//end class TicTacToe
}