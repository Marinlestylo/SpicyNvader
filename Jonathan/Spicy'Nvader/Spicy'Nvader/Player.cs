using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Nvader
{
    public class Player
    {
        private const int TOP_POSITION = Program.HEIGHT_OF_WINDOWS - 10;
        private const int MARGIN = 1;
        //private const string PLAYER1 = "├Ö┤";
        private readonly string[] PLAYER = new string[10] { "     _     ", "    / \\    ", "   | o |   ", "   |   |   ", "   | o |   ", "   |   |   ", "  /| o |\\  ", " / |___| \\ ", "| / |@| \\ |", "|/  |@|  \\|" };
        private const string ERASE = "           ";
        private const int VALUE_OF_MOVEMENT = 1;

        private int _playerPreviousPosition;
        private int _playerPosition;
        private int _playerLives;
        private bool _playerShoot;
        private int _playerScore;

        public Player()
        {
            _playerPosition = Program.WIDTH_OF_WIDOWS / 2;
            _playerPreviousPosition = _playerPosition;
            _playerLives = 3;
            _playerShoot = true;
        }

        public void DrawPlayer()
        {
            for (int i = 0; i < PLAYER.Length; i++)
            {
                Console.SetCursorPosition(_playerPreviousPosition - PLAYER[0].Length / 2, TOP_POSITION + i);
                Console.Write(ERASE);
            }
            Console.SetCursorPosition(_playerPosition - PLAYER[0].Length / 2, TOP_POSITION);
            for (int i = 0; i < PLAYER.Length; i++)
            {
                Console.SetCursorPosition(_playerPosition - PLAYER[0].Length / 2, TOP_POSITION + i);
                Console.Write(PLAYER[i]);
            }
            Console.SetCursorPosition(_playerPosition, TOP_POSITION);
        }

        public void Move(int movement)
        {
            _playerPreviousPosition = _playerPosition;
            _playerPosition += movement;
        }

        public void Shoot()
        {
            _playerShoot = false;
        }

        public void GetShot()
        {
            if (_playerLives > 1)
            {
                _playerLives--;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vous avez perdu ! Quel dommage . . . ");
                Console.WriteLine("Voici votre score : " + _playerScore);
            }
        }

        public void PlayerAction()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.RightArrow:                     // 80 - 1                         11 / 2 = 5             1    TOT : 73 position max
                    /*if (_playerPosition + VALUE_OF_MOVEMENT > (Program.WIDTH_OF_WIDOWS - 1) - (PLAYER[4].Length / 2) - MARGIN)
                    {
                        _playerPosition = (Program.WIDTH_OF_WIDOWS - 1) - (PLAYER[4].Length / 2) - MARGIN;
                    }*/
                    if (_playerPosition < (Program.WIDTH_OF_WIDOWS - 1) - PLAYER[4].Length / 2 - (1 * VALUE_OF_MOVEMENT))//Le - 1 c'est la marge (le -1 a la taille de la console sert car le 80eme caractère est la 79eme case car on commence à 0)
                    {
                        Move(VALUE_OF_MOVEMENT);
                        DrawPlayer();
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_playerPosition > PLAYER[4].Length/2 + (1 * VALUE_OF_MOVEMENT))//Le + 1 c'est la marge
                    {
                        Move(-1 * VALUE_OF_MOVEMENT);
                        DrawPlayer();
                    }
                    break;
                case ConsoleKey.Spacebar:
                    if (_playerShoot)
                    {
                        Shoot();
                    }
                    break;
            }
        }
    }
}
