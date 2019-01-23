using System;

namespace Spicy_Nvader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Menu mainMenu = new Menu();
            mainMenu.LaunchMenu();
            Console.Read();
        }
    }
}
