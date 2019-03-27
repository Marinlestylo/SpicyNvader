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

        public Player() : base(3, new Point(44, 55))
        {
            _design = Sprites.Player;
            Score = 0;
            _touched = new List<Point>();
        }

        public override void Update()
        {
            BaseUpdate();
            Debug.WriteLine("Player : Update()");
        }

        /// <summary>
        /// Permet de bouger la position du joueur (que latéralement)
        /// </summary>
        /// <param name="direction">1 ou -1 en fonction de si on va à gauche ou a droite</param>
        public override void Move(int direction)
        {
            _position.X += direction;
            //Actualise la hitbox
            foreach (Point p in _touched)
            {
                p.X += direction;
            }
        }

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
