using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Nvader
{
    class Program
    {

        static int positionMenu = 1;

        static void Main(string[] args)
        {

            int margeLeftTitle = 10;
            int margeTopTitle = 1;
            const int SPACE_MENU = 3;


            int margeLeftMenu = 24;
            int margeTopMenu = 10;
            
            //Console.CursorVisible = false;


            WriteTitle(margeLeftTitle, margeTopTitle);



            Console.SetCursorPosition(margeLeftMenu, margeTopMenu);
            Console.WriteLine("Start");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu += SPACE_MENU);
            Console.WriteLine("Options");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu += SPACE_MENU);
            Console.WriteLine("HighScores");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu += SPACE_MENU);
            Console.WriteLine("About");
            Console.SetCursorPosition(margeLeftMenu, margeTopMenu += SPACE_MENU);
            Console.WriteLine("Leave Game");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(margeLeftMenu - 2, 10);
            WriteTriangle();

            MenuMouvement(SPACE_MENU);

            Console.Read();


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
            } while (true);
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
                    // Lancer le jeu
                    break;
                case 2:
                    Erase();
                    Options();
                    break;
                case 3:
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
            Console.Write("Sound : ON");
            Console.CursorLeft += 7;
            Console.Write("Difficulty : Padawan");
            Console.CursorLeft = currentLeft - 2;
            WriteTriangle();

            bool navigation = true;
            bool end = false;
            while (end)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (!navigation)
                        {
                            Erase();
                            Console.CursorLeft += 22;
                            WriteTriangle();
                            navigation = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (navigation)
                        {
                            Erase();
                            Console.CursorLeft -= 22;
                            WriteTriangle();
                            navigation = false;
                        }
                        break;
                    case ConsoleKey.Escape:
                        end = true;
                        break;
                }
            }
        }
    }
}
