using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testEnemy
{
    class Program
    {
        private const int HEIGHT_OF_WINDOWS = 80;
        private const int WIDTH_OF_WIDOWS = 150;
        private const char H = '█';
        //private static readonly string[] ENEMY = new string[3] { "███", "███", "███",};
        private static string[] ENEMY;
        private static int _topPos = 2;
        private static int _leftPos = 5;
        private static int[][] bigOne = new int[][] {
            new int[] {0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
            new int[] {0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0},
            new int[] {0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0},
            new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1},
            new int[] {1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1},
            new int[] {0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0},
        };

        static void Main(string[] args)
        {
            Console.WindowHeight = HEIGHT_OF_WINDOWS;
            Console.WindowWidth = WIDTH_OF_WIDOWS;
            Console.BufferHeight = HEIGHT_OF_WINDOWS;
            Console.BufferWidth = WIDTH_OF_WIDOWS;
            METHODE(7);
            Toucher();
            //Draw(_leftPos, _topPos);
            Console.Read();
        }

        public static void METHODE(int number)
        {
            ENEMY = new string[number] /*{ "███████", "███████", "███████", "███████", "███████", "███████", "███████" }*/;
            for (int i = 0; i < number; i++)
            {
                string S = "".PadLeft(number, '█');
                ENEMY[i] = S;
            }
        }

        public static void Toucher()
        {
            for (int i = 0; i < bigOne.Length; i++)
            {
                for (int j = 0; j< bigOne[i].Length; j++)
                {
                    if (bigOne[i][j] == 1)
                    {
                        Draw(_leftPos + ENEMY[0].Length * j, _topPos + ENEMY[0].Length * i);
                        /*Console.SetCursorPosition(_leftPos * j, _topPos * i);
                        Console.Write(A);*/
                    }
                }
            }
        }

        public static void Draw(int x, int y)
        {
            for (int i = 0; i < ENEMY.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(ENEMY[i]);
            }

        }
    }
}
