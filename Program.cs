
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.cs
{
    class Program
    {
        // Array that contains board positions, 0 isnt used --------------------------------
        static string[] pos = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        static void DrawBoard() // Draw board method ==========================================
        {
            Console.WriteLine();
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[1], pos[2], pos[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[4], pos[5], pos[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[7], pos[8], pos[9]);
        }

        static void Main(string[] args) // Main ==============================================
        {

            do
            {
                try
                {
                    string player1 = "", player2 = "";
                    int choice = 0, turn = 1, score1 = 0, score2 = 0;
                    bool playing = true, correctInput = false;
                    int winFlag = 2;

                    Console.Title = ("Chup ChupKe's Tic Tac Toe Game");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("1. Mechanics");
                    Console.WriteLine("2. Leave");
                    Console.WriteLine("3. Play");
                    Console.Write("Enter your option: ");
                    int mechanics = int.Parse(Console.ReadLine());
                    if (mechanics == 2)
                    {
                        Console.WriteLine("\nGame has stopped");
                        break;
                    }
                    else
                    {
                        if (mechanics == 1)
                            Console.WriteLine("======The object of Tic Tac Toe is to get three in a row.\nYou play on a three by three game board.\nThe first player is known as O and the second is X.\nPlayers alternate placing Xs and Os on the game board until either\noppent has three in a row or all nine squares are filled.\nX always goes first, and in the event that no one has three in a row, the stalemate is called a cat game.======");

                        Console.WriteLine("\nHELLO PLAYERS ! WELCOME!! This is Tic Tac Toe.\n ");
                        Console.Write("What is the name of player 1? ");
                        player1 = Console.ReadLine();
                        Console.Write("\nVery good. What is the name of player 2? ");
                        player2 = Console.ReadLine();
                        Console.WriteLine("\nOkay good. {0} is X and {1} is O.", player1, player2);
                        Console.WriteLine("\n{0} goes first.", player1);
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    while (playing == true)
                    {
                        while (winFlag == 2)
                        {
                            DrawBoard();
                            Console.WriteLine();

                            Console.WriteLine("Score: {0} - {1}     {2} - {3}\n", player1, score1, player2, score2);
                            if (turn == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("{0}'s (X) turn", player1);
                            }
                            if (turn == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("{0}'s (O) turn", player2);
                            }

                            while (correctInput == false)
                            {
                                Console.Write("Which position would you like to take?");
                                choice = int.Parse(Console.ReadLine());
                                if (choice > 0 && choice < 10)
                                {
                                    correctInput = true;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            correctInput = false; // Reset -------

                            if (turn == 1)
                            {
                                if (pos[choice] == "O") // Checks to see if spot is taken already --------------------
                                {
                                    Console.WriteLine("You can't steal positions! ");
                                    Console.Write("Try again.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                    pos[choice] = "X";
                                }
                            }
                            if (turn == 2)
                            {
                                if (pos[choice] == "X") // Checks to see if spot is taken already -------------------
                                {
                                    Console.WriteLine("You can't steal positions! ");
                                    Console.Write("Try again.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                    pos[choice] = "O";
                                }
                            }

                            winFlag = CheckWin();

                            if (winFlag == 2)
                            {
                                if (turn == 1)
                                {
                                    turn = 2;
                                }
                                else if (turn == 2)
                                {
                                    turn = 1;
                                }
                                Console.Clear();
                            }
                        }

                        Console.Clear();

                        DrawBoard();

                        for (int i = 1; i < 10; i++) // Resets board ------------------------
                        {
                            pos[i] = i.ToString();
                        }

                        if (winFlag == 3) // No one won ---------------------------
                        {
                            Console.WriteLine("It's a draw!");
                            Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                            Console.WriteLine("");
                            Console.WriteLine("What would you like to do now?");
                            Console.WriteLine("1. Play again");
                            Console.WriteLine("2. Leave");
                            Console.WriteLine("");

                            while (correctInput == false)
                            {
                                Console.WriteLine("Enter your option: ");
                                choice = int.Parse(Console.ReadLine());

                                if (choice > 0 && choice < 3)
                                {
                                    correctInput = true;
                                }
                            }

                            correctInput = false; // Reset -------------

                            switch (choice)
                            {
                                case 1:
                                    Console.Clear();
                                    winFlag = 2;
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Thanks for playing!");
                                    Console.ReadLine();
                                    playing = false;
                                    break;
                            }
                        }

                        if (winFlag == 1) // Someone won -----------------------------
                        {
                            if (turn == 1)
                            {
                                score1++;
                                Console.WriteLine("{0} wins!", player1);
                                Console.WriteLine("What would you like to do now?");
                                Console.WriteLine("1. Play again");
                                Console.WriteLine("2. Leave");

                                while (correctInput == false)
                                {
                                    Console.WriteLine("Enter your option: ");
                                    choice = int.Parse(Console.ReadLine());

                                    if (choice > 0 && choice < 3)
                                    {
                                        correctInput = true;
                                    }
                                }

                                correctInput = false; // Reset --------------

                                switch (choice)
                                {
                                    case 1:
                                        Console.Clear();
                                        winFlag = 2;
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Thanks for playing!");
                                        Console.ReadLine();
                                        playing = false;
                                        break;
                                }
                            }

                            if (turn == 2)
                            {
                                score2++;
                                Console.WriteLine("{0} wins!", player2);
                                Console.WriteLine("What would you like to do now?");
                                Console.WriteLine("1. Play again");
                                Console.WriteLine("2. Leave");

                                while (correctInput == false)
                                {
                                    Console.WriteLine("Enter your option: ");
                                    choice = int.Parse(Console.ReadLine());

                                    if (choice > 0 && choice < 3)
                                    {
                                        correctInput = true;
                                    }
                                }

                                correctInput = false; // Reset -----------------

                                switch (choice)
                                {
                                    case 1:
                                        Console.Clear();
                                        winFlag = 2;
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Thanks for playing!");
                                        Console.ReadLine();
                                        playing = false;
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input\nGame has stopped.....");
                }
            }
            while (false);
        }

        static int turncount = 1;

        static int CheckWin() // Win checker method ================================================
        {
            if (turncount != 9)
            {
                turncount++;
                if (pos[1] == "O" && pos[2] == "O" && pos[3] == "O") // Horizontal ----------------------------------------
                {
                    turncount = 1;
                    return 1;

                }
                else if (pos[4] == "O" && pos[5] == "O" && pos[6] == "O")
                {
                    turncount = 1;
                    return 1;

                }
                else if (pos[7] == "O" && pos[8] == "O" && pos[9] == "O")
                {
                    turncount = 1;
                    return 1;
                }

                else if (pos[1] == "O" && pos[5] == "O" && pos[9] == "O") // Diagonal -----------------------------------------
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[7] == "O" && pos[5] == "O" && pos[3] == "O")
                {
                    turncount = 1;
                    return 1;
                }

                else if (pos[1] == "O" && pos[4] == "O" && pos[7] == "O")// Columns ------------------------------------------
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[2] == "O" && pos[5] == "O" && pos[8] == "O")
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[3] == "O" && pos[6] == "O" && pos[9] == "O")
                {
                    turncount = 1;
                    return 1;
                }

                if (pos[1] == "X" && pos[2] == "X" && pos[3] == "X") // Horizontal ----------------------------------------
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[4] == "X" && pos[5] == "X" && pos[6] == "X")
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[7] == "X" && pos[8] == "X" && pos[9] == "X")
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[1] == "X" && pos[5] == "X" && pos[9] == "X") // Diagonal -----------------------------------------
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[7] == "X" && pos[5] == "X" && pos[3] == "X")
                {
                    turncount = 1;
                    return 1;
                }

                else if (pos[1] == "X" && pos[4] == "X" && pos[7] == "X") // Columns ------------------------------------------
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[2] == "X" && pos[5] == "X" && pos[8] == "X")
                {
                    turncount = 1;
                    return 1;
                }
                else if (pos[3] == "X" && pos[6] == "X" && pos[9] == "X")
                {
                    turncount = 1;
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if (turncount == 9)
            {
                {

                    if (pos[1] == "O" && pos[2] == "O" && pos[3] == "O") // Horizontal ----------------------------------------
                    {
                        turncount = 1;
                        return 1;

                    }
                    else if (pos[4] == "O" && pos[5] == "O" && pos[6] == "O")
                    {
                        turncount = 1;
                        return 1;

                    }
                    else if (pos[7] == "O" && pos[8] == "O" && pos[9] == "O")
                    {
                        turncount = 1;
                        return 1;
                    }

                    else if (pos[1] == "O" && pos[5] == "O" && pos[9] == "O") // Diagonal -----------------------------------------
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[7] == "O" && pos[5] == "O" && pos[3] == "O")
                    {
                        turncount = 1;
                        return 1;
                    }

                    else if (pos[1] == "O" && pos[4] == "O" && pos[7] == "O")// Columns ------------------------------------------
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[2] == "O" && pos[5] == "O" && pos[8] == "O")
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[3] == "O" && pos[6] == "O" && pos[9] == "O")
                    {
                        turncount = 1;
                        return 1;
                    }

                    if (pos[1] == "X" && pos[2] == "X" && pos[3] == "X") // Horizontal ----------------------------------------
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[4] == "X" && pos[5] == "X" && pos[6] == "X")
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[7] == "X" && pos[8] == "X" && pos[9] == "X")
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[1] == "X" && pos[5] == "X" && pos[9] == "X") // Diagonal -----------------------------------------
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[7] == "X" && pos[5] == "X" && pos[3] == "X")
                    {
                        turncount = 1;
                        return 1;
                    }

                    else if (pos[1] == "X" && pos[4] == "X" && pos[7] == "X") // Columns ------------------------------------------
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[2] == "X" && pos[5] == "X" && pos[8] == "X")
                    {
                        turncount = 1;
                        return 1;
                    }
                    else if (pos[3] == "X" && pos[6] == "X" && pos[9] == "X")
                    {
                        turncount = 1;
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Draw");
                        Console.ReadLine();
                        turncount = 1;
                        return 3;
                    }
                }
            }
            else
            {
                return 1;
            }
        }
    }
}