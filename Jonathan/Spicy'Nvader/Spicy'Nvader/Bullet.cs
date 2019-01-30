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

        private int _positionX;
        private int _positionY;
        private int _maxPositionY;
        

        public Bullet(int posX, int posY, int maxPosY)
        {
            _positionX = posX;
            _positionY = posY;
            _maxPositionY = maxPosY;
        }

        public void DrawBullet()
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(BULLET_DESIGN);
            Console.SetCursorPosition(currentLeft, currentTop);
        }

        public void MoveTop()
        {
            DrawBullet();
            if (_positionY > _maxPositionY)
            {
                _positionY--;
            }
        }
    }
}
