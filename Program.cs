// My name  : Hossien Molladarband
// My Gmail : hossienprogrammer@gmail.com

// XO game :D


// Use Matrice !
/*
   --           --
  | a11  a12  a13 |
  | a21  a22  a23 |
  | a31  a32  a33 |
   --           --
 */
namespace HossienMolladarband_p1
{
    public static class Extension 
    {
        public static bool find<T>(this T[] array, T target) // Search in array for value
        {
            try
            {
                array.Where(i => i.Equals(target)).First();
                // or
                // array.First(i => i.Equals(target));
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
    
    class Program
    {
        static string[,] Help() // Show how to chose numbers
        {
            string[,] xo =
            {
                {" 1 ", " 2 ", " 3 " },
                {" 4 ", " 5 ", " 6 " },
                {" 7 ", " 8 ", " 9 " }
            };

            return xo;
        }

        static void WriteBoard(string[,] xo)  // creat a nice board for play
        {
            Console.WriteLine("- - - - - - -");
            for (int i = 0; i < xo.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < xo.GetLength(1); j++)
                {
                    Console.Write(xo[i, j]);
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine("- - - - - - -");
            }
        }

        static int Aij_Linear(string[,] xo) // cheak win modes
        {
            /*
               --           --
              | a11  a12  a13 |
              | a21  a22  a23 |
              | a31  a32  a33 |
               --           --
             */
            string a11 = xo[0, 0];
            string a12 = xo[0, 1];
            string a13 = xo[0, 2];

            string a21 = xo[1, 0];
            string a22 = xo[1, 1];
            string a23 = xo[1, 2];

            string a31 = xo[2, 0];
            string a32 = xo[2, 1];
            string a33 = xo[2, 2];

            if ((a11 == a12) && (a12 == a13))
            {
                return 1;
            }
            else if ((a21 == a22) && (a22 == a23))
            {
                return 2;
            }
            else if ((a31 == a32) && (a32 == a33))
            {
                return 3;
            }
            else if ((a11 == a21) && (a21 == a31))
            {
                return 4;
            }
            else if ((a12 == a22) && (a22 == a32))
            {
                return 5;
            }
            else if ((a13 == a23) && (a23 == a33))
            {
                return 6;
            }
            else
            {
                return -1;
            }

        }

        static int Aij_Diagonal(string[,] xo) // cheak win modes
        {
            /*
               --           --
              | a11       a13 |
              |      a22      |
              | a31       a33 |
               --           --
             */
            string a11 = xo[0, 0];
            string a13 = xo[0, 2];

            string a22 = xo[1, 1];

            string a31 = xo[2, 0];
            string a33 = xo[2, 2];

            if ((a11 == a22) && (a22 == a33)) // and -> &&      or -> ||
            {
                return 1;
            }
            else if ((a13 == a22) && (a22 == a31))
            {
                return 2;
            }
            else
            {
                return -1;
            }

        }

        static bool CheakEqual(string[,] x) // cheak equal mode
        {
            string a11 = x[0, 0];
            string a12 = x[0, 1];
            string a13 = x[0, 2];

            string a21 = x[1, 0];
            string a22 = x[1, 1];
            string a23 = x[1, 2];

            string a31 = x[2, 0];
            string a32 = x[2, 1];
            string a33 = x[2, 2];

            if ((a11 == " X ") || (a11 == " O "))
            {
                if ((a12 == " X ") || (a12 == " O "))
                {
                    if ((a13 == " X ") || (a13 == " O "))
                    {
                        if ((a21 == " X ") || (a21 == " O "))
                        {
                            if ((a22 == " X ") || (a22 == " O "))
                            {
                                if ((a23 == " X ") || (a23 == " O "))
                                {
                                    if ((a31 == " X ") || (a31 == " O "))
                                    {
                                        if ((a32 == " X ") || (a32 == " O "))
                                        {
                                            if ((a33 == " X ") || (a33 == " O "))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static bool Add(string[,] x,int n,string xo) // x = board, n = number, xo = " X " or  " O " 
        {
            if (n == 1)
            {
                x[0, 0] = xo;
                return true;
            }
            else if (n == 2)
            {
                x[0, 1] = xo;
                return true;
            }
            else if (n == 3)
            {
                x[0, 2] = xo;
                return true;
            }
            else if (n == 4)
            {
                x[1, 0] = xo;
                return true;
            }
            else if (n == 5)
            {
                x[1, 1] = xo;
                return true;
            }
            else if (n == 6)
            {
                x[1, 2] = xo;
                return true;
            }
            else if (n == 7)
            {
                x[2, 0] = xo;
                return true;
            }
            else if (n == 8)
            {
                x[2, 1] = xo;
                return true;
            }
            else if (n == 9)
            {
                x[2, 2] = xo;
                return true;
            }
            else
            {
                return false;
            }
        }

        static void WriteWinnerLoserPlayer1(string[] player1, string[] player2) // when player1 is winner
        {
            player1[2] = Convert.ToString(Convert.ToInt32(player1[2]) + 10);
            player1[3] = Convert.ToString(Convert.ToInt32(player1[3]) + 1);
            player2[2] = Convert.ToString(Convert.ToInt32(player2[2]) - 5);
            player2[4] = Convert.ToString(Convert.ToInt32(player2[4]) + 1);
            Console.WriteLine("Winner Winner , {0} has {1}points, win: {2}, lose: {3}, equal: {4} :)", player1[1], player1[2], player1[3], player1[4], player1[5]);
            Console.WriteLine("Loser  Loser  , {0} has {1}points, win: {2}, lose: {3}, equal: {4} :)", player2[1], player2[2], player2[3], player2[4], player2[5]);
        }

        static void WriteWinnerLoserPlayer2(string[] player1, string[] player2) // when player2 is winner
        {
            player1[2] = Convert.ToString(Convert.ToInt32(player1[2]) - 5);
            player1[4] = Convert.ToString(Convert.ToInt32(player1[4]) + 1);
            player2[2] = Convert.ToString(Convert.ToInt32(player2[2]) + 10);
            player2[3] = Convert.ToString(Convert.ToInt32(player2[3]) + 1);
            Console.WriteLine("Winner Winner , {0} has {1}points, win: {2}, lose: {3}, equal: {4} :)", player2[1], player2[2], player2[3], player2[4], player2[5]);
            Console.WriteLine("Loser  Loser  , {0} has {1}points, win: {2}, lose: {3}, equal: {4} :)", player1[1], player1[2], player1[3], player1[4], player1[5]);
        }

        static void WriteEqualplayers(string[] player1, string[] player2) // when both is equal
        {
            player1[5] = Convert.ToString(Convert.ToInt32(player1[5]) + 1);
            player1[2] = Convert.ToString(Convert.ToInt32(player1[2]) + 1);
            player2[5] = Convert.ToString(Convert.ToInt32(player2[5]) + 1);
            player2[2] = Convert.ToString(Convert.ToInt32(player2[2]) + 1);
            Console.WriteLine("Wow :0 you are equal! , {0} has {1}points, win: {2}, lose: {3}, equal: {4} :)", player1[1], player1[2], player1[3], player1[4], player1[5]);
            Console.WriteLine("Wow :0 you are equal! , {0} has {1}points, win: {2}, lose: {3}, equal: {4} :)", player2[1], player2[2], player2[3], player2[4], player2[5]);
        }

        static void Main(string[] args)
        {
            // set cmd colors
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            //               0          1       2       3       4       5
            // player = {"X" or "O", "name", "point", "win", "lose", "equal"}
            string[] player1 = new string[6] { "X", "", "0", "0", "0", "0" };
            string[] player2 = new string[6] { "O", "", "0", "0", "0", "0" };

            // Get name 
            Console.WriteLine("What's your name? (Player 1)");
            player1[1] = Console.ReadLine();
            Console.WriteLine("What's your name? (Player 2)");
            player2[1] = Console.ReadLine();

            // Rules
            Console.WriteLine();
            WriteBoard(Help());
            Console.WriteLine("\nNote:");
            Console.WriteLine("Use number for replace X or O");
            Console.WriteLine("Win   = +10 point");
            Console.WriteLine("Lose  = -5  point");
            Console.WriteLine("Equal = +1  point\n");

            
            Console.WriteLine("How many times do you want to play?");
            int playtime = Convert.ToInt32(Console.ReadLine());


            while (playtime != 0)
            {
                string[,] main_board =
                {
                    {" 1 ", " 2 ", " 3 " },
                    {" 4 ", " 5 ", " 6 " },
                    {" 7 ", " 8 ", " 9 " }
                };
                int[] cheak_used_numbers = new int[] { -1 }; // Check for duplicate numbers in game
                bool game = true;
                int i = 2; // For change player 
                while (game == true)
                {
                    // player1
                    if ((i % 2) == 0)
                    {
                        WriteBoard(main_board);
                        Console.Write("{0} number : ", player1[1]);

                        int number = Convert.ToInt32(Console.ReadLine()); // read number
                        bool cheak = cheak_used_numbers.find(number); // Check for duplicate number 
                        if (cheak == false)
                        {
                            Console.Clear();
                            cheak_used_numbers = cheak_used_numbers.Concat(new int[] { number }).ToArray();    // add to array
                            Add(main_board, number, " X ");
                            i += 1;
                            // cheak win, lose, equal
                            if (Aij_Diagonal(main_board) == 1)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;   
                            }
                            else if (Aij_Diagonal(main_board) == 2)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 1)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 2)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 3)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 4)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 5)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 6)
                            {
                                WriteWinnerLoserPlayer1(player1, player2);
                                game = false;
                            }
                            else if (CheakEqual(main_board) == true)
                            {
                                WriteEqualplayers(player1, player2);
                                game = false;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Chose another number pleas :) ");
                        }
                    }

                    // player2
                    else
                    {
                        WriteBoard(main_board);
                        Console.Write("{0} number : ", player2[1]);

                        int number = Convert.ToInt32(Console.ReadLine()); // read number
                        bool cheak = cheak_used_numbers.find(number); // Check for duplicate number 
                        if (cheak == false)
                        {
                            Console.Clear();
                            cheak_used_numbers = cheak_used_numbers.Concat(new int[] { number }).ToArray();    // add to array
                            Add(main_board, number, " O ");
                            i += 1;
                            // cheak win, lose, equal
                            if (Aij_Diagonal(main_board) == 1)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else if (Aij_Diagonal(main_board) == 2)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 1)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 2)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 3)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 4)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 5)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else if (Aij_Linear(main_board) == 6)
                            {
                                WriteWinnerLoserPlayer2(player1, player2);
                                game = false;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Chose another number pleas :) ");
                        }
                    }
                }
                playtime -= 1;
            }
            Console.WriteLine("\n       \tHaave\ta\tgood\tday\t:) ");
            Console.Write("Press any key ... ");
            Console.ReadKey();
        }
    }
}
