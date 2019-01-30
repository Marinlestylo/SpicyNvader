using System;

namespace Spicy_Nvader
{
    public class Menu
    {
        private static bool _sound;
        private static bool _difficulty;
        private bool _startPressed;
        private int _positionMenu;
        private int _currentLeft;
        private int _margeTopTitle;
        private const int SPACE_BETWEEN_OPTION = 24;
        private const int MARGE_LEFT_MENU = 24;
        private const int MARGE_TOP_MENU = 10;
        private const int MARGE_LEFT_TITLE = 10;
        private const int SPACE_MENU = 3;

        public Menu()
        {
            _sound = true;
            _difficulty = false;
            _startPressed = true;
            _positionMenu = 1;
            _currentLeft = 0;
            _margeTopTitle = 0;
        }

        public void LaunchMenu()
        {
            CreateMenu();
            MenuMouvement(SPACE_MENU);
        }

        public void CreateMenu()
        {
            WriteTitle();

            Console.SetCursorPosition(MARGE_LEFT_MENU, MARGE_TOP_MENU);
            Console.WriteLine("Start");
            Console.SetCursorPosition(MARGE_LEFT_MENU, MARGE_TOP_MENU + 1 * SPACE_MENU);
            Console.WriteLine("Options");
            Console.SetCursorPosition(MARGE_LEFT_MENU, MARGE_TOP_MENU + 2 * SPACE_MENU);
            Console.WriteLine("HighScores");
            Console.SetCursorPosition(MARGE_LEFT_MENU, MARGE_TOP_MENU + 3 * SPACE_MENU);
            Console.WriteLine("About");
            Console.SetCursorPosition(MARGE_LEFT_MENU, MARGE_TOP_MENU + 4 * SPACE_MENU);
            Console.WriteLine("Leave Game");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(MARGE_LEFT_MENU - 2, 10);
            WriteTriangle();
        }

        public void WriteTitle()
        {
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+1);
            Console.WriteLine("   _____       _            _ _   _                _           ");
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+2);
            Console.WriteLine("  / ____|     (_)          ( ) \\ | |              | |          ");
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+3);
            Console.WriteLine(" | (___  _ __  _  ___ _   _|/|  \\| |_   ____ _  __| | ___ _ __ ");
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+4);
            Console.WriteLine("  \\___ \\| '_ \\| |/ __| | | | | . ` \\ \\ / / _` |/ _` |/ _ \\ '__|");
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+5);
            Console.WriteLine("  ____) | |_) | | (__| |_| | | |\\  |\\ V / (_| | (_| |  __/ |   ");
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+6);
            Console.WriteLine(" |_____/| .__/|_|\\___|\\__, | |_| \\_| \\_/ \\__,_|\\__,_|\\___|_|   ");
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+7);
            Console.WriteLine("        | |            __/ |                                   ");
            Console.SetCursorPosition(MARGE_LEFT_TITLE, _margeTopTitle+8);
            Console.WriteLine("        |_|           |___/                                    ");
        }

        public void MenuMouvement(int space)
        {
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_positionMenu != 1)
                        {
                            _positionMenu--;
                            Erase();
                            Console.CursorTop -= space;
                            WriteTriangle();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (_positionMenu != 5)
                        {
                            _positionMenu++;
                            Erase();
                            Console.CursorTop += space;
                            WriteTriangle();
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Selection();
                        break;
                }
            } while (_startPressed);
        }

        public void WriteTriangle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("►");
            Console.CursorLeft--;
            Console.ResetColor();
        }

        public void Erase()
        {
            Console.Write(" ");
            Console.CursorLeft--;
        }

        public void Selection()
        {
            switch (_positionMenu)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("LE JEU EST EN COURS DE DEVELOPEMENT");
                    _startPressed = false;
                    // Lancer le jeu
                    break;
                case 2:
                    Erase();
                    Options();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Les Highscores sont en cours de dev");

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        _positionMenu = 1;
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

        public void About(int left, int top)
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            Console.SetCursorPosition(left + 8, top);
            Console.WriteLine("Created by Jonathan & Filipe");
            Console.SetCursorPosition(currentLeft, currentTop);
        }

        public void Options()
        {
            int currentLeft = Console.CursorLeft + 15;
            Console.CursorLeft = currentLeft;
            if (_sound)
            {
                Console.Write("Sound : ON");
                Console.CursorLeft += 7;
            }
            else
            {
                Console.Write("Sound : OFF");
                Console.CursorLeft += 6;
            }

            if (_difficulty)
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
                        Console.CursorLeft = SPACE_BETWEEN_OPTION - 2;
                        WriteTriangle();
                        break;
                }
            }
        }

        public void MenuDifficulty()
        {
            _currentLeft = Console.CursorLeft;
            Console.CursorLeft += 15;
            Erase(8);
            if (_difficulty)
            {
                _difficulty = false;
                Console.Write("Lazar");
                Console.CursorLeft = _currentLeft;
            }
            else
            {
                _difficulty = true;
                Console.Write("Francis");
                Console.CursorLeft = _currentLeft;
            }
        }

        public void MenuSound()
        {
            _currentLeft = Console.CursorLeft;
            Console.CursorLeft += 10;
            Erase(3);
            if (_sound)
            {
                _sound = false;
                Console.Write("OFF");
                Console.CursorLeft = _currentLeft;
            }
            else
            {
                _sound = true;
                Console.Write("ON");
                Console.CursorLeft = _currentLeft;
            }
        }

        public void Erase(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft -= number;
        }
    }
}
