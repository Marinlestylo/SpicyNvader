using deSPICYtoINVADER.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deSPICYtoINVADER.Characters
{
    public class Player : Character
    {
        /* Propriétés */
        public int Score;

        /* Attributs */
        private List<Point> _touched;
        private bool _autoMove;

        /// <summary>
        /// Constructeur de la classe, il reprend le constructeur de "Character"
        /// </summary>
        public Player() : base(9, new Point(Game.WIDTH_OF_WIDOWS / 2, Game.HEIGHT_OF_WINDOWS - Sprites.Player.Length - 1 ))
        {
            _design = Sprites.Player;
            Score = 0;
            _touched = new List<Point>();
            _autoMove = false;
        }

        public override void Update()
        {
            Draw();
            Input();
        }

        /// <summary>
        /// Permet de bouger la position du joueur (que latéralement)
        /// </summary>
        /// <param name="direction">1 ou -1 en fonction de si on va à gauche ou a droite</param>
        protected override void Move(int direction)
        {
            _position.X += direction;
            //Actualise la hitbox
            foreach (Point p in _touched)
            {
                p.X += direction;
            }
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)//Lis la touche du clavier sur laquelle on appuie
                {
                    case ConsoleKey.RightArrow://Flèche de droite
                        _direction = 1;
                        if (!_autoMove && CanIMove())
                        {
                           Move(_direction); 
                        }
                        break;
                    case ConsoleKey.LeftArrow://Flèche de gauche
                        _direction = -1;
                        if (!_autoMove && CanIMove())
                        {
                            Move(_direction);
                        }
                        break;
                    case ConsoleKey.DownArrow://Stoper le vaisseau
                        _direction = 0;
                        break;
                    case ConsoleKey.Spacebar://set le tir sur la touche espace
                        Shoot();
                        break;
                    case ConsoleKey.M://Active ou désactive le mode auto
                        if (_autoMove)
                        {
                            _autoMove = false;
                        }
                        else
                        {
                            _autoMove = true;
                            _direction = 0;
                        }
                        break;
                }
            }
            AutoMove();//Si le mode auto est on
            CanIMove();//Vérifie si on peut bouger
        }

        public void Shoot()
        {
            Game.allBullets.Add(new Bullet(new Point(_position.X, _position.Y), -1));
        }

        /// <summary>
        /// Si le joueur arrive dans la marge, il ne peut plus avancer
        /// </summary>
        /// <returns>return true si le joueur peut encore avancer, false sinon</returns>
        private bool CanIMove()
        {
            if (_direction == 1 && _position.X == Game.WIDTH_OF_WIDOWS - 1 - Game.MARGIN - (Sprites.Player[9].Length / 2))
            {
                return false;
            }
            else if (_direction == -1 && _position.X == Game.MARGIN + (Sprites.Player[9].Length / 2))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Si le mode autoMove est a true, le vaisseau bouge tout seul tous les 5 tics (Dans la direction définie)
        /// </summary>
        private void AutoMove()
        {
            if (_autoMove && Game.tics % 2 == 0 && CanIMove())
            {
                Move(_direction);
            }
        }

        /// <summary>
        /// Probablement la pire méthode du monde mais on a rien trouvé de mieux pour faire une hitbox précise
        /// </summary>
        private void GetHitBox()
        {
            //De gauche à droite
            _touched.Add(new Point(_position.X - 5, _position.Y + 8));
            _touched.Add(new Point(_position.X - 4, _position.Y + 7));
            _touched.Add(new Point(_position.X - 3, _position.Y + 6));
            _touched.Add(new Point(_position.X - 2, _position.Y + 2));
            _touched.Add(new Point(_position.X - 2, _position.Y + 3));
            _touched.Add(new Point(_position.X - 2, _position.Y + 4));
            _touched.Add(new Point(_position.X - 2, _position.Y + 5));
            _touched.Add(new Point(_position.X - 1, _position.Y + 1));
            _touched.Add(new Point(_position.X, _position.Y));
            _touched.Add(new Point(_position.X + 1, _position.Y + 1));
            _touched.Add(new Point(_position.X + 2, _position.Y + 2));
            _touched.Add(new Point(_position.X + 2, _position.Y + 3));
            _touched.Add(new Point(_position.X + 2, _position.Y + 4));
            _touched.Add(new Point(_position.X + 2, _position.Y + 5));
            _touched.Add(new Point(_position.X + 3, _position.Y + 6));
            _touched.Add(new Point(_position.X + 4, _position.Y + 7));
            _touched.Add(new Point(_position.X + 5, _position.Y + 8));
        }

    }
}
