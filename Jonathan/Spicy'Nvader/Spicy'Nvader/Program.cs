using System;

namespace Spicy_Nvader
{
    class Program
    {
        public const int WIDTH_OF_WIDOWS = 150;
        public const int HEIGHT_OF_WINDOWS = 60;
        static void Main (string[] args)
        {
            Console.WindowHeight = HEIGHT_OF_WINDOWS;
            Console.WindowWidth = WIDTH_OF_WIDOWS;
            Console.BufferHeight = HEIGHT_OF_WINDOWS;
            Console.BufferWidth = WIDTH_OF_WIDOWS;
            Console.CursorVisible = false;
            Player p1 = new Player();
            p1.DrawPlayer();
            while (true)
            {
                p1.PlayerAction();
            }
        }
    }
}
