using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spicy_Nvader
{
    public class Bullet
    {
        private const char BULLET_DESIGN = '♦';

        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Direction { get; }


        private int _firstYPos;
        private int _maxPositionY;
        

        public bool GonnaDelete { get; set; }
        

        public Bullet(int posX, int posY, int maxPosY, int direction)
        {
            PosX = posX;
            PosY = posY;
            _maxPositionY = maxPosY;
            _firstYPos = posY;
            Direction = direction;
            GonnaDelete = false;
        }

        public void DrawBullet()
        {
            //Random color = new Random();//POUR LE FLASHY
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            Console.SetCursorPosition(PosX, PosY + Direction);
            Console.Write(' ');
            Console.SetCursorPosition(PosX, PosY);
            //int cool = color.Next(10, 16);//POUR LE FLASHY
            //Console.ForegroundColor = (ConsoleColor)cool;//POUR LE FLASHY
            Console.Write(BULLET_DESIGN);
            Console.SetCursorPosition(currentLeft, currentTop);
        }

        public void EraseBullet()
        {
            if (GonnaDelete)
            {
                Console.Write('K');
            }
        }

        public void UpdateBullet()
        {
            if (Program.tics % 2291 == 0 && Direction == 1)
            {
                if (PosY >= _maxPositionY)
                {
                    DrawBullet();
                    PosY -= Direction;
                }
                else
                {
                    int currentLeft = Console.CursorLeft;
                    int currentTop = Console.CursorTop;
                    Console.SetCursorPosition(PosX, _maxPositionY);
                    Console.Write(' ');
                    Console.SetCursorPosition(currentLeft, currentTop);
                    GonnaDelete = true;
                }
            }
            else if (Program.tics % 2291 == 0 && Direction == -1)
            {
                if (PosY <= _maxPositionY)
                {
                    DrawBullet();
                    PosY -= Direction;
                }
                else
                {
                    int currentLeft = Console.CursorLeft;
                    int currentTop = Console.CursorTop;
                    Console.SetCursorPosition(PosX, _maxPositionY);
                    Console.Write(' ');
                    Console.SetCursorPosition(currentLeft, currentTop);
                    GonnaDelete = true;
                }
            }
        }
    }
}
