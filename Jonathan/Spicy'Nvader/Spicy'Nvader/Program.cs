using System;

namespace Spicy_Nvader
{
    class Program
    {

        static int positionMenu = 1;
        static int tempos = 24;
        static bool sound = true;
        static bool difficulty = false;
        static int currentLeft = 0;
        static bool IsGameNotLaunched = true;
        static int margeLeftMenu = 24;
        static int margeTopMenu = 10;
        static int margeLeftTitle = 10;
        static int margeTopTitle = 1;
        const int SPACE_MENU = 3;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            LaunchMenu();
            Console.Read();
        }

        public static void LaunchMenu()
        {
            CreateMenu();
            MenuMouvement(SPACE_MENU);
        }

        public static void CreateMenu()
        {
            WriteTitle(margeLeftTitle, margeTopTitle);

            Console.SetCursorPosition(margeLeftMenu, margeTopMenu);
            Console.WriteLine("Start");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu + 1 * SPACE_MENU);
            Console.WriteLine("Options");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu + 2 * SPACE_MENU);
            Console.WriteLine("HighScores");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu + 3 * SPACE_MENU);
            Console.WriteLine("About");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu + 4 * SPACE_MENU);
            Console.WriteLine("Leave Game");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(margeLeftMenu - 2, 10);
            WriteTriangle();
        }

        public static void WriteTitle(int margeLeftTitle, int margeTopTitle)
        {
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine("   _____       _            _ _   _                _");
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine("  / ____|     (_)          ( ) \\ | |              | |           ");
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine(" | (___  _ __  _  ___ _   _|/|  \\| |_   ____ _  __| | ___  _ __ ");
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine("  \\___ \\| '_ \\| |/ __| | | | | . ` \\ \\ / / _` |/ _` |/ _ \\| '__|");
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine("  ____) | |_) | | (__| |_| | | |\\  |\\ V / (_| | (_| | (_) | |   ");
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine(" |_____/| .__/|_|\\___|\\__, | |_| \\_| \\_/ \\__,_|\\__,_|\\___/|_|   ");
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine("        | |            __/ |                                    ");
            Console.SetCursorPosition(margeLeftTitle, margeTopTitle++);
            Console.WriteLine("        |_|           |___/                                     ");
        }

        public static void MenuMouvement(int space)
        {
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (positionMenu != 1)
                        {
                            positionMenu--;
                            Erase();
                            Console.CursorTop -= space;
                            WriteTriangle();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (positionMenu != 5)
                        {
                            positionMenu++;
                            Erase();
                            Console.CursorTop += space;
                            WriteTriangle();
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Selection();
                        break;
                }
            } while (IsGameNotLaunched);
        }

        public static void Erase()
        {
            Console.Write(" ");
            Console.CursorLeft--;
        }

        public static void WriteTriangle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("►");
            Console.CursorLeft--;
            Console.ResetColor();
        }


        public static void Selection()
        {
            switch (positionMenu)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("LE JEU EST EN COURS DE DEVELOPEMENT");
                    IsGameNotLaunched = false;
                    // Lancer le jeu
                    break;
                case 2:
                    Erase();
                    Options();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Les Highscores sont en cours de dev");

                    if(Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        positionMenu = 1;
                        Console.Clear();
                        LaunchMenu();
                    }
                    // HighScore
                    break;
                case 4:
                    About(30, 19);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void About(int left, int top)
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("Créé par Jonathan & Filipe");
            Console.SetCursorPosition(currentLeft, currentTop);
        }

        public static void Options()
        {
            int currentLeft = Console.CursorLeft + 15;
            Console.CursorLeft = currentLeft;
            if (sound)
            {
                Console.Write("Sound : ON");
                Console.CursorLeft += 7;
            }
            else
            {
                Console.Write("Sound : OFF");
                Console.CursorLeft += 6;
            }

            if (difficulty)
            {
                Console.Write("Difficulty : Francis");
            }
            else
            {
                Console.Write("Difficulty : Lazar");
            }
            Console.CursorLeft = currentLeft - 2;
            WriteTriangle();

            bool navigation = true;
            bool end = true;
            while (end)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (!navigation)
                        {
                            Erase();
                            Console.CursorLeft -= 17;
                            WriteTriangle();
                            navigation = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (navigation)
                        {
                            Erase();
                            Console.CursorLeft += 17;
                            WriteTriangle();
                            navigation = false;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        if (navigation)
                        {
                            MenuSound();
                        }
                        else
                        {
                            MenuDifficulty();
                        }
                        break;
                    case ConsoleKey.Escape:
                        end = false;
                        Erase();
                        Console.CursorLeft = tempos -2;
                        WriteTriangle();
                        break;
                }
            }
        }

        public static void MenuDifficulty()
        {
            currentLeft = Console.CursorLeft;
            Console.CursorLeft += 15;
            Erase(8);
            if (difficulty)
            {
                difficulty = false;
                Console.Write("Lazar");
                Console.CursorLeft = currentLeft;
            }
            else
            {
                difficulty = true;
                Console.Write("Francis");
                Console.CursorLeft = currentLeft;
            }
        }

        public static void MenuSound()
        {
            currentLeft = Console.CursorLeft;
            Console.CursorLeft += 10;
            Erase(3);
            if (sound)
            {
                sound = false;
                Console.Write("OFF");
                Console.CursorLeft = currentLeft;
            }
            else
            {
                sound = true;
                Console.Write("ON");
                Console.CursorLeft = currentLeft;
            }
        }

        public static void Erase(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft -= number;
        }
    }
}
