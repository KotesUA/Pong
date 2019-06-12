using System;
using System.Threading;

namespace Ping_Pong
{
    class Program
    {
        #region vars
        static int BallX, BallY;
        static int PrevBallX, PrevBallY;
        static bool balldirectionup, balldirectionright;
        static int FirstPlayerY = 0;
        static int SecondPlayerY = 0;
        static int firstplayerscore = 0;
        static int secondplayerscore = 0;
        static bool score = false;
        static int SetInitPoints = 0;
        static int gamemode = 2;
        static int fps = 30;
        static int firstplayerx = 0;
        static int secondplayerx = 119;
        static int ConsoleWidth = 120;
        static int ConsoleHeight = 33;
        static int LowerBarrierY = 24;
        static int SkinX, SkinY;
        static int SkinValue = 0;
        static bool SkinOnField = false;
        static Random randomGenerator = new Random();
        #endregion

        static void Main(string[] args)
        {
            SetConsole();
            Greeting();
            Menu();
        }

        #region misc
        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void SetConsole()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void SetBorder()
        {
            for (int x = 0; x < ConsoleWidth; x++)
            {
                PrintAtPosition(x, LowerBarrierY, '█');
            }
        }

        static void SetInitialPoints()
        {
            switch (SetInitPoints)
            {
                case 0:
                    FirstPlayerY = 15;
                    SecondPlayerY = 15;
                    SetBall(59, randomGenerator.Next(10) + 10);
                    SetBorder();
                    break;
                case 1:
                    FirstPlayerY = randomGenerator.Next(15) + 5;
                    SecondPlayerY = 15;
                    SetBall(2, FirstPlayerY + randomGenerator.Next(2) - 1);
                    SetBorder();
                    break;
                case 2:
                    FirstPlayerY = 15;
                    SecondPlayerY = randomGenerator.Next(15) + 5;
                    SetBall(117, SecondPlayerY + randomGenerator.Next(2) - 1);
                    SetBorder();
                    break;
            }
        }

        static void PrintResult()
        {
            int FirstPlayerScoreX = 54;
            int FirstPlayerScoreY = 27;
            int SecondPlayerScoreX = 62;
            int SecondPlayerScoreY = 27;
            PrintNum(FirstPlayerScoreX, FirstPlayerScoreY, firstplayerscore);
            PrintAtPosition(FirstPlayerScoreX + 4, FirstPlayerScoreY + 1, '▀');
            PrintAtPosition(FirstPlayerScoreX + 5, FirstPlayerScoreY + 1, '▀');
            PrintAtPosition(FirstPlayerScoreX + 6, FirstPlayerScoreY + 1, '▀');
            PrintNum(SecondPlayerScoreX, SecondPlayerScoreY, secondplayerscore);
        }

        static void ClearFieldNearPlayers()
        {
            for (int y = 0; y <= LowerBarrierY - 1; y++)
            {
                PrintAtPosition(firstplayerx + 2, y, ' ');
                PrintAtPosition(secondplayerx - 2, y, ' ');
            }
            for (int i = firstplayerx + 2; i < ConsoleWidth - 3; i++)
            {
                PrintAtPosition(i, LowerBarrierY - 1, ' ');
            }
        }

        static void PrintNum (int x, int y, int num)
        {
            switch (num)
            {
                case 0:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, zero[a, b]);
                        }
                    }
                    break;
                case 1:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, one[a, b]);
                        }
                    }
                    break;
                case 2:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, two[a, b]);
                        }
                    }
                    break;
                case 3:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, three[a, b]);
                        }
                    }
                    break;
                case 4:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, four[a, b]);
                        }
                    }
                    break;
                case 5:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, five[a, b]);
                        }
                    }
                    break;
                case 6:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, six[a, b]);
                        }
                    }
                    break;
                case 7:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, seven[a, b]);
                        }
                    }
                    break;
                case 8:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, eight[a, b]);
                        }
                    }
                    break;
                case 9:
                    for (int a = 0; a <= 2; a++)
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            PrintAtPosition(x + b, y + a, nine[a, b]);
                        }
                    }
                    break;
            }
        }

        static void Greeting()
        {
            for (int a = 0; a < 9; a++)
            {
                switch (a)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                for (int x = 0; x < 35; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        PrintAtPosition(40 + x, 13 + y, welcome[y, x]);
                    }
                }
                Thread.Sleep(100);
                if (a == 8)
                {
                    Console.Clear();
                }
            }

            for (int a = 0; a < 9; a++)
            {
                switch (a)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                for (int x = 0; x <= 51; x++)
                {
                    for (int y = 0; y <= 6; y++)
                    {
                        PrintAtPosition(35 + x, 13 + y, Ping_Pong[y, x]);
                    }
                }
                Thread.Sleep(100);
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void Menu()
        {
            int selected = 1;

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            for (int x = 0; x <= ConsoleWidth - 1; x++)
            {
                for (int y = 0; y <= ConsoleHeight - 1; y++)
                {
                    PrintAtPosition(x, y, ' ');
                }
            }

            while (true)
            {
                if (selected == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                for (int x = 20; x <= 100; x++)
                {
                    for (int y = 2; y <= 10; y++)
                    {
                        PrintAtPosition(x, y, button_play[y - 2, x - 20]);
                    }
                }

                if (selected == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                for (int x = 20; x <= 100; x++)
                {
                    for (int y = 12; y <= 20; y++)
                    {
                        PrintAtPosition(x, y, button_mode[y - 12, x - 20]);
                    }
                }
                

                if (selected == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                for (int x = 20; x <= 100; x++)
                {
                    for (int y = 22; y <= 30; y++)
                    {
                        PrintAtPosition(x, y, button_exit[y - 22, x - 20]);
                    }
                }
                

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if ((keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.NumPad8) && selected > 1)
                    {
                        selected--;
                    }
                    if ((keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.NumPad2)&& selected < 3)
                    {
                        selected++;
                    }
                    if (keyInfo.Key == ConsoleKey.Enter && selected == 1)
                    {
                        Console.ResetColor();
                        Console.Clear();
                        Game();

                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        for (int x = 0; x <= ConsoleWidth - 1; x++)
                        {
                            for (int y = 0; y <= ConsoleHeight - 1; y++)
                            {
                                PrintAtPosition(x, y, ' ');
                            }
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter && selected == 2)
                    {
                        selected = 1;

                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        for (int x = 0; x <= ConsoleWidth - 1; x++)
                        {
                            for (int y = 0; y <= ConsoleHeight - 1; y++)
                            {
                                PrintAtPosition(x, y, ' ');
                            }
                        }

                        while (true)
                        {
                            if (selected == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            for (int x = 20; x <= 100; x++)
                            {
                                for (int y = 2; y <= 10; y++)
                                {
                                    PrintAtPosition(x, y, button_easy[y - 2, x - 20]);
                                }
                            }
                            if (selected == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            for (int x = 20; x <= 100; x++)
                            {
                                for (int y = 12; y <= 20; y++)
                                {
                                    PrintAtPosition(x, y, button_normal[y - 12, x - 20]);
                                }
                            }
                            if (selected == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            for (int x = 20; x <= 100; x++)
                            {
                                for (int y = 22; y <= 30; y++)
                                {
                                    PrintAtPosition(x, y, button_hard[y - 22, x - 20]);
                                }
                            }

                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo keyInfo2 = Console.ReadKey();
                                if ((keyInfo2.Key == ConsoleKey.UpArrow || keyInfo2.Key == ConsoleKey.W || keyInfo2.Key == ConsoleKey.NumPad8) && selected > 1)
                                {
                                    selected--;
                                }
                                if ((keyInfo2.Key == ConsoleKey.DownArrow || keyInfo2.Key == ConsoleKey.S || keyInfo2.Key == ConsoleKey.NumPad2) && selected < 3)
                                {
                                    selected++;
                                }
                                if (keyInfo2.Key == ConsoleKey.Enter && selected == 1)
                                {
                                    gamemode = 1;
                                    for (int x = 0; x <= ConsoleWidth - 1; x++)
                                    {
                                        for (int y = 0; y <= ConsoleHeight - 1; y++)
                                        {
                                            PrintAtPosition(x, y, ' ');
                                        }
                                    }
                                    selected = 1;
                                    break;
                                }
                                if (keyInfo2.Key == ConsoleKey.Enter && selected == 2)
                                {
                                    gamemode = 2;
                                    for (int x = 0; x <= ConsoleWidth - 1; x++)
                                    {
                                        for (int y = 0; y <= ConsoleHeight - 1; y++)
                                        {
                                            PrintAtPosition(x, y, ' ');
                                        }
                                    }
                                    selected = 1;
                                    break;
                                }
                                if (keyInfo2.Key == ConsoleKey.Enter && selected == 3)
                                {
                                    gamemode = 3;
                                    for (int x = 0; x <= ConsoleWidth - 1; x++)
                                    {
                                        for (int y = 0; y <= ConsoleHeight - 1; y++)
                                        {
                                            PrintAtPosition(x, y, ' ');
                                        }
                                    }
                                    selected = 1;
                                    break;
                                }
                            }
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter && selected == 3)
                    {
                        EndGame();
                    }
                }
            }
        }

        static void Game()
        {
            for (int a = 0; a < 9;)
            {
                SetInitialPoints();
                if (gamemode == 1)
                {
                    fps = 45;
                }
                if (gamemode == 3)
                {
                    fps = 25;
                }
                while (true)
                {
                    DrawFirstPlayer(SkinValue);
                    DrawSecondPlayer();
                    DrawBall();
                    PrintResult();
                    Skin();
                    MoveBall();

                    int k = randomGenerator.Next(3);
                    if (gamemode == 1 && (k == 0))
                    {
                        SecondPlayerAIMove();
                    }
                    if (gamemode == 2 && (k == 1 || k == 2))
                    {
                        SecondPlayerAIMove();
                    }
                    if (gamemode == 3 && (k == 0 || k == 1 || k == 2))
                    {
                        SecondPlayerAIMove();
                    }

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.NumPad8)
                        {
                            MoveFirstPlayerUp();
                        }
                        if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.NumPad2)
                        {
                            MoveFirstPlayerDown();
                        }
                    }

                    if (score)
                    {
                        break;
                    }

                    
                    ClearFieldNearPlayers();

                    Thread.Sleep(fps);
                }

                SkinOnField = false;
                SkinValue = 0;

                if (firstplayerscore > secondplayerscore)
                {
                    a = firstplayerscore;
                }
                else
                {
                    a = secondplayerscore;
                }
                score = false;
                Console.Clear();
            }
            SetInitPoints = 0;
            firstplayerscore = 0;
            secondplayerscore = 0;
        }

        static void Skin()
        {
            int k = randomGenerator.Next(50);
            if (k > 45 && !SkinOnField)
            {
                int a = randomGenerator.Next(4);
                switch (a)
                {
                    case 0:
                        SkinX = 40;
                        SkinY = 10;
                        break;
                    case 1:
                        SkinX = 80;
                        SkinY = 10;
                        break;
                    case 2:
                        SkinX = 40;
                        SkinY = 20;
                        break;
                    case 3:
                        SkinX = 80;
                        SkinY = 20;
                        break;
                }
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        PrintAtPosition(SkinX + i - 1, SkinY + j - 1, skin_block[j, i]);
                    }
                }
                SkinOnField = true;
            }

            if (BallX > SkinX - 2 && BallX < SkinX + 2 && BallY > SkinY - 2 && BallY < SkinY + 2)
            {
                SkinOnField = false;
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        PrintAtPosition(SkinX + i - 1, SkinY + j - 1, ' ');
                    }
                }
                SkinValue = randomGenerator.Next(2) + 1;
            }
        }

        static void EndGame()
        {
            //TODO thx for playing
            Environment.Exit(0);
        }
        #endregion

        //all about first player (person)
        #region FirstPlayer
        static void DrawFirstPlayer(int SkinValue)
        {
            for (int y = FirstPlayerY - 2; y <= FirstPlayerY + 2; y++)
            {
                switch (SkinValue)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        PrintAtPosition(firstplayerx, y, '█');
                        PrintAtPosition(firstplayerx + 1, y, '█');
                        Console.ResetColor();
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        PrintAtPosition(firstplayerx, y, '█');
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        PrintAtPosition(firstplayerx + 1, y, '█');
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Black;
                        PrintAtPosition(firstplayerx, y, '█');
                        PrintAtPosition(firstplayerx + 1, y, '█');
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void MoveFirstPlayerDown()
        {
            if (FirstPlayerY <= 20)
            {
                FirstPlayerY++;
                PrintAtPosition(0, FirstPlayerY - 3, ' ');
                PrintAtPosition(1, FirstPlayerY - 3, ' ');
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (FirstPlayerY >= 3)
            {
                FirstPlayerY--;
                PrintAtPosition(0, FirstPlayerY + 3, ' ');
                PrintAtPosition(1, FirstPlayerY + 3, ' ');
            }
        }
        #endregion

        //all about second player (AI)
        #region SecondPlayer
        static void DrawSecondPlayer()
        {
            for (int y = SecondPlayerY - 2; y <= SecondPlayerY + 2; y++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                PrintAtPosition(ConsoleWidth - 1, y, '█');
                PrintAtPosition(118, y, '█');
                Console.ResetColor();
            }
        }

        static void SecondPlayerAIMove()
        {
            int MinXForMove = 0;
            switch (gamemode)
            {
                case 1:
                    MinXForMove = 70;
                    break;
                case 2:
                    MinXForMove = 40;
                    break;
                case 3:
                    MinXForMove = 20;
                    break;
            }
            if (balldirectionup && SecondPlayerY >= 3 && BallX > MinXForMove && balldirectionright)
            {
                MoveSecondPlayerUp();
            }
            if (!balldirectionup && SecondPlayerY <= 20 && BallX > MinXForMove && balldirectionright)
            {
                MoveSecondPlayerDown();
            }
        }

        static void MoveSecondPlayerUp()
        {
            SecondPlayerY--;
            PrintAtPosition(ConsoleWidth - 1, SecondPlayerY + 3, ' ');
            PrintAtPosition(118, SecondPlayerY + 3, ' ');
        }

        static void MoveSecondPlayerDown()
        {
            SecondPlayerY++;
            PrintAtPosition(ConsoleWidth - 1, SecondPlayerY - 3, ' ');
            PrintAtPosition(118, SecondPlayerY - 3, ' ');
        }
        #endregion

        //all about ball
        #region Ball
        static void SetBall(int bx, int by)
        {
            BallX = bx;
            BallY = by;
        }

        static void BallRandomDirection()
        {
            int b = randomGenerator.Next(2);
            switch (b)
            {
                case 0:
                    balldirectionup = true;
                    break;
                case 1:
                    balldirectionup = false;
                    break;
            }
        }

        static void DrawBall()
        {
            PrintAtPosition(BallX, BallY, '█');
        }

        static void MoveBall()
        {
            //ball near higher border
            if (BallY == 0)
            {
                balldirectionup = false;
            }

            //ball near lower border
            if (BallY == LowerBarrierY - 1 && balldirectionright)
            {
                balldirectionup = true;
                if (BallX < 100)
                {
                    BallX += randomGenerator.Next(5);
                }
            }
            if (BallY == LowerBarrierY - 1 && !balldirectionright)
            {
                balldirectionup = true;
                if (BallX > 10)
                {
                    BallX -= randomGenerator.Next(5);
                }
            }

            //ball collides first player
            if (BallX == firstplayerx + 2 && !balldirectionright && BallY <= FirstPlayerY + 2 && BallY >= FirstPlayerY - 2)
            {
                balldirectionright = true;
            }

            //ball collides second player
            if (BallX == secondplayerx - 2 && balldirectionright && BallY <= SecondPlayerY + 2 && BallY >= SecondPlayerY - 2)
            {
                balldirectionright = false;
            }

            //ball collides left border - goal for second player
            if (BallX == 0 && !balldirectionright)
            {
                secondplayerscore++;
                balldirectionright = true;
                SetInitPoints = 1;
                score = true;
            }

            //ball collides right border - goal for first player
            if (BallX == ConsoleWidth - 1 && balldirectionright)
            {
                firstplayerscore++;
                balldirectionright = false;
                SetInitPoints = 2;
                score = true;
            }

            //remove previous ball
            PrintAtPosition(PrevBallX, PrevBallY, ' ');

            //move ball
            if (balldirectionright)
            {
                PrevBallX = BallX;
                BallX++;
            }
            else
            {
                PrevBallX = BallX;
                BallX--;
            }
            if (balldirectionup)
            {
                PrevBallY = BallY;
                BallY--;
            }
            else
            {
                PrevBallY = BallY;
                BallY++;
            }
        }
        #endregion

        //needed char arrays
        #region Chars
        static char[,] welcome = new char[,]      {{'█', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', '▀', '▀', ' ', '█', ' ', ' ', ' ', '█', '▀', '▀', ' ', '█', '▀', '█', ' ', '█', '█', ' ', ' ', ' ', '█', '█', ' ', '█', '▀', '▀'},
                                                   {' ', '█', ' ', '█', ' ', '█', ' ', ' ', '█', '▀', '▀', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', '█', ' ', '█', ' ', '█', ' ', '█', ' ', '█', '▀', '▀'},
                                                   {' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', '▄', '▄', ' ', '█', '▄', '▄', ' ', '█', '▄', '▄', ' ', '█', '▄', '█', ' ', '█', ' ', ' ', '█', ' ', ' ', '█', ' ', '█', '▄', '▄'} };

        static char[,] Ping_Pong = new char[,]     { {'█', '▀', '▀', '▀', '▀', '▀', '▄', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▀', '▀', '▀', '▀', '▀', '▄', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', '█', ' ', '▀', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                                     {'█', '▄', '▄', '▄', '▄', '▄', '▀', ' ', '█', ' ', '█', '▄', '▀', '▀', '▄', ' ', '▄', '▀', '▀', '▀', '▄', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '▄', '▄', '▀', ' ', '█', '▀', '█', ' ', '█', '▄', '▀', '▀', '▄', ' ', '▄', '▀', '▀', '▀', '▄'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', '▀', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '▀', '▀', '▀', '▀', '▀', '▀', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', '█', '▀', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '▀', '▄', '▄', '▄', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '▀', '▄', '▄', '▄', '█'},
                                                     {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▄', '▄', '▀', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▄', '▄', '▀'}};

        static char[,] zero = new char[,] { {'█', '▀', '█'},
                                            {'█', ' ', '█'},
                                            {'█', '▄', '█'} };

        static char[,] one = new char[,] { {' ', ' ', '█'},
                                           {' ', ' ', '█'},
                                           {' ', ' ', '█'} };

        static char[,] two = new char[,] { {'█', '▀', '█'},
                                           {'▄', '▄', '█'},
                                           {'█', '▄', '▄'} };

        static char[,] three = new char[,] { {'█', '▀', '█'},
                                             {' ', '▀', '█'},
                                             {'█', '▄', '█'} };

        static char[,] four = new char[,]  { {'█', ' ', '█'},
                                             {'█', '▄', '█'},
                                             {' ', ' ', '█'} };

        static char[,] five = new char[,]  { {'█', '▀', '█'},
                                             {'█', '▄', '▄'},
                                             {'▄', '▄', '█'} };

        static char[,] six = new char[,]   { {'█', '▀', '▀'},
                                             {'█', '▄', '▄'},
                                             {'█', '▄', '█'} };

        static char[,] seven = new char[,] { {'█', '▀', '█'},
                                             {' ', ' ', '█'},
                                             {' ', ' ', '█'} };

        static char[,] eight = new char[,]   { {'█', '▀', '█'},
                                               {'█', '▄', '█'},
                                               {'█', '▄', '█'} };

        static char[,] nine = new char[,]    { {'█', '▀', '█'},
                                               {'█', '▄', '█'},
                                               {'▄', '▄', '█'} };

        static char[,] button_play = new char[,]   { {'█', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▀', '▀', '▀', '▀', '▀', '▄', ' ', '█', ' ', ' ', ' ', ' ', '▄', '▀', '▀', '▀', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '▄', '▄', '▀', ' ', '█', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '█'}};

        static char[,] button_exit = new char[,]   { {'█', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▀', '▀', '▀', '▀', '▀', ' ', '█', ' ', ' ', ' ', '█', ' ', '▀', '█', '▀', ' ', ' ', '█', '▀', '▀', '█', '▀', '▀', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '▄', '▄', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '▄', '▄', ' ', '█', ' ', ' ', ' ', '█', ' ', '▄', '█', '▄', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '█'}};

        static char[,] button_mode = new char[,]   { {'█', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '█', ' ', ' ', ' ', ' ', ' ', '█', '█', ' ', '█', '▀', '▀', '█', ' ', '█', '▀', '▄', ' ', ' ', '█', '▀', '▀', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', '▀', '▀', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', '▄', '▄', '█', ' ', '█', '▄', '▀', ' ', ' ', '█', '▄', '▄', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '█'}};

        static char[,] button_easy = new char[,]   { {'█', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▀', '▀', '▀', '▀', '▀', ' ', '▄', '▀', '▀', '▀', '█', ' ', '▄', '▀', '▀', '▀', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '▄', '▄', ' ', '█', '▄', '▄', '▄', '█', ' ', '▀', '▄', '▄', '▄', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '▄', '▄', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', '▄', '▄', '▄', '▀', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '█'}};

        static char[,] button_normal = new char[,] { {'█', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '█', ' ', ' ', ' ', '█', ' ', '█', '▀', '▀', '█', ' ', '█', '▀', '▀', '▄', ' ', '█', '█', ' ', ' ', ' ', ' ', ' ', '█', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', '▄', '▄', '▀', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', '█', ' ', '█', ' ', ' ', '█', ' ', '█', '▄', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', '█', '▄', '▄', '█', ' ', '█', ' ', '▀', '▄', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '█'} };

        static char[,] button_hard = new char[,]   { {'█', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '▀', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', '▄', '▀', '▀', '▀', '█', ' ', '█', '▀', '▀', '▄', ' ', '█', '▀', '▄', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', '▄', '▄', '▄', '▄', '█', ' ', '█', '▄', '▄', '▄', '█', ' ', '█', '▄', '▄', '▀', ' ', '█', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', '▄', ' ', ' ', ' ', '█', ' ', ' ', '█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█', ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', ' ', '▀', '▄', ' ', '█', '▄', '▀', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '█'},
                                                     {'█', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '▄', '█'}};

        static char[,] skin_block = new char[,] { {'█', '▀', '█'},
                                                  {'█', ' ', '█'},
                                                  {'█', '▄', '█'}  };
        #endregion
    }
}