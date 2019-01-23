using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Nvader
{
    public class Player
    {
        private const int TOP_POSITION = 20;
        private const char PLAYER = '█';
        private const int MAX_POS = 84;
        private const int VALUE_OF_MOVEMENT = 1;

        private int _playerPreviousPosition;
        private int _playerPosition;
        private int _playerLives;
        private bool _playerShoot;

        public Player()
        {
            _playerPosition = 42;
            _playerLives = 3;
            _playerShoot = true;
        }

        public void DrawPlayer()
        {
            Console.CursorLeft = _playerPreviousPosition;
            Console.WriteLine(' ');
            Console.CursorLeft = _playerPosition;
            Console.Write(PLAYER);
        }

        public void Move(int movement)
        {
            _playerPreviousPosition = _playerPosition;
            _playerPosition += movement;
        }

        public void Shoot()
        {

        }

        public void PlayerAction()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.RightArrow:
                    if (_playerPosition != MAX_POS)
                    {
                        Move(VALUE_OF_MOVEMENT);
                        DrawPlayer();
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_playerPosition != 0)
                    {
                        Move(-1 * VALUE_OF_MOVEMENT);
                    }
                    break;
                case ConsoleKey.Spacebar:
                    Shoot();
                    break;
            }
        }
    }
}
