using System;

class Program
{

    static int turns = 0; //Will count each turn  If == 10 then the game is a draw

    static char[] board =
    {'1', '2', '3','4', '5', '6','7', '8', '9'}; //Char array to store the players input

    public static char playerSignature = ' ';


    public static void ResetBoard() //When called the game resets  
    {
        char[] boardInitialize =
        {'1', '2', '3','4', '5', '6','7', '8', '9'};

        board = boardInitialize;
        DrawBoard();
        turns = 0;
    }

    public static void Welcome()
    {
        Console.WriteLine("\nWelcome to Tic Tac Toe, please press a key to begin");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("RULES");
        Console.WriteLine("Tic Tac Toe is a two player turn based game." +
                          "\nIt's you vs your opponent..." +
                          "\nPress any key to continue");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("RULES");
       
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Players are represented with a unique signature" +
                          "\nPlayer 1 = x  Player 2 = o");
        Console.WriteLine("\nThe first player to score three signatures in a row is the winner" +
                          "\nGood luck players! \nNow press any key to begin...");
        Console.ReadKey();
        Console.Clear();
    } //This method covers the game rules.

    public static void 
        DrawBoard()
    {
        Console.Clear();
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[0], board[1], board[2]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[3], board[4], board[5]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[6], board[7], board[8]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
    } //When called draws the playing board to the terminal.

    static void Main(string[] args)
    {
        int player = 2; 
        int input = 0;
        bool isInputCorrect = true;

        Welcome();

        Console.WriteLine("Please enter your names below!");
        Console.WriteLine("Player 1 (x):");
        Console.WriteLine("Player 2 (o):");

        Console.SetCursorPosition(14, 1);
        string firstPlayer = Console.ReadLine();

        Console.SetCursorPosition(14, 2);
        string secondPlayer = Console.ReadLine();
        string currentPlayer = string.Empty;

        do 
        {
            if (player == 2)
            {
                player = 1;
                XorO(player, input);
            }
            else if (player == 1)
            {
                player = 2;
                XorO(player, input);
            }
            
            if (turns % 2 != 0)
            {
                currentPlayer = secondPlayer;
            }
            else
            {
                currentPlayer = firstPlayer;
            }
            DrawBoard();

            
            CheckHorizontalWin(firstPlayer, secondPlayer);
            CheckDiagonalWin(firstPlayer, secondPlayer);
            CheckVerticalWin(firstPlayer, secondPlayer);

            turns++;

            if (turns == 10)
            {
                Draw();
            }

            do
            {
                
                Console.WriteLine($"\nReady, {currentPlayer}? It's your move!");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("You can only enter a number! Try again");
                }

                if ((input == 1) && (board[0] == '1'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 2) && (board[1] == '2'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 3) && (board[2] == '3'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 4) && (board[3] == '4'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 5) && (board[4] == '5'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 6) && (board[5] == '6'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 7) && (board[6] == '7'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 8) && (board[7] == '8'))
                {
                    isInputCorrect = true;
                }
                else if ((input == 9) && (board[8] == '9'))
                {
                    isInputCorrect = true;
                }
                else
                {
                    Console.WriteLine("Invalid number!  \nPlease try again...");
                    isInputCorrect = false;
                }


            } while (!isInputCorrect);
        } while (true);

    }


    public static void CheckVerticalWin(string firstPlayer, string secondPlayer)
    {
        char[] playerSignatures = { 'x', 'o' };

        foreach (char playerSignature in playerSignatures)
        {
            if (((board[0] == playerSignature) && (board[3] == playerSignature) && (board[6] == playerSignature))
                || ((board[1] == playerSignature) && (board[4] == playerSignature) && (board[7] == playerSignature))
                || ((board[2] == playerSignature) && (board[5] == playerSignature) && (board[8] == playerSignature)))
            {
                Console.Clear();
                if (playerSignature == 'x')
                {
                    Console.WriteLine($"Good job, {secondPlayer}!\nA vertical win!");
                }
                else
                {
                    Console.WriteLine($"Good job, {firstPlayer}\nA vertical win!\n");
                }

                Console.WriteLine("Please press a key compared to the action you want to take!" +
                                   "\n1.Play again\n2.Close the game");
                char input = char.Parse(Console.ReadLine());
                if (input == '1')
                {
                    ResetBoard();
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter a valid action");
                    input = char.Parse(Console.ReadLine());
                }

                break;
            }
        }
    } //When called checks for a vertical win 

    public static void CheckDiagonalWin(string firstPlayer, string secondPlayer)
    {
        char[] playerSignatures = { 'x', 'o' };

        foreach (char playerSignature in playerSignatures)
        {
            if (((board[0] == playerSignature) && (board[4] == playerSignature) && (board[8] == playerSignature))
                || ((board[6] == playerSignature) && (board[4] == playerSignature) && (board[2] == playerSignature)))
            {
                Console.Clear();
                if (playerSignature == 'x')
                {
                    Console.WriteLine($"Great job, {firstPlayer} that's a diagonal win! \n \n \n" +
                                      "\nReally well played! \n \n \n");
                }
                else
                {
                    Console.WriteLine($"Great job, {secondPlayer} that's a diagonal win! \n \n \n" +
                                      "\nReally well played! \n \n \n");
                }


                Console.WriteLine("Please press a key compared to the action you want to take!" +
                                  "\n1.Play again\n2.Close the game");
                char input = char.Parse(Console.ReadLine());
                if (input == '1')
                {
                    ResetBoard();
                }
                else if(input == '2')
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter a valid action");
                    input = char.Parse(Console.ReadLine());
                }

                break;
            }
        }
    } //When called checks for a diagonal win

    public static void CheckHorizontalWin(string firstPlayer, string secondPlayer)
    {
        char[] playerSignatures = { 'x', 'o' };

        foreach (char playerSignature in playerSignatures)
        {
            if (((board[0] == playerSignature) && (board[1] == playerSignature) && (board[2] == playerSignature))
                || ((board[3] == playerSignature) && (board[4] == playerSignature) && (board[5] == playerSignature))
                || ((board[6] == playerSignature) && (board[7] == playerSignature) && (board[8] == playerSignature)))
            {
                Console.Clear();
                if (playerSignature == 'x')
                {
                    Console.WriteLine($"Congratulations {secondPlayer}.\nYou have a achieved a horizontal win in {turns} turns");
                }
                else if (playerSignature == 'o')
                {
                    Console.WriteLine($"Congratulations {firstPlayer}.\nYou have a achieved a horizontal win in {turns} turns");
                }


                Console.WriteLine("Please press a key compared to the action you want to take!" +
                                  "\n1.Play again\n2.Close the game");
                char input = char.Parse(Console.ReadLine());
                if (input == '1')
                {
                    ResetBoard();
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter a valid action");
                    input = char.Parse(Console.ReadLine());
                }

                break;
            }
        }
    } //Method is called to check for a horizontal win.

    public static void Draw()
    {

        {
            Console.WriteLine("Dang! it's a draw..." +
                              "\nPlease press a key compared to the action you want to take!" +
                              "\n1.Play again\n2.Close the game");
            char input = char.Parse(Console.ReadLine());

            if (input == '1')
            {
                ResetBoard();
                
            }
            else if (input == '2')
            {
                Console.Clear();
                Environment.Exit(0);
                
            }
            else
            {
                Console.WriteLine("Error \n Enter a valid action!");
                input = char.Parse(Console.ReadLine());
                
            }




        }
    } //When called checks if the game is a draw
    public static void XorO(int player, int input)
    {

        if (player == 1) playerSignature = 'o';
        else if (player == 2) playerSignature = 'x';

        switch (input)
        {
            case 1:
                board[0] = playerSignature;
                break;
            case 2:
                board[1] = playerSignature;
                break;
            case 3:
                board[2] = playerSignature;
                break;
            case 4:
                board[3] = playerSignature;
                break;
            case 5:
                board[4] = playerSignature;
                break;
            case 6:
                board[5] = playerSignature;
                break;
            case 7:
                board[6] = playerSignature;
                break;
            case 8:
                board[7] = playerSignature;
                break;
            case 9:
                board[8] = playerSignature;
                break;
        }

    } //Controls if the player is x or o.

}