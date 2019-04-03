using deSPICYtoINVADER.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deSPICYtoINVADER.Characters
{
    public class Enemy : Character
    {
        /* Propriétés */
        public Point TopLeftCorner { get; private set; }
        public Point BottomRightCorner { get; private set; }
        private List<Point> _hitbox;

        public Enemy(Point position) : base(1, position)
        {
            _design = Sprites.Enemy;
            _hitbox = new List<Point>();
            Hitbox();
        }

        protected override void Move(int direction)
        {
            _position.X += _direction;
            Hitbox();
        }

        public override void Update()
        {
            Draw();
        }

        /// <summary>
        /// Méthode pour mettre à jour le Coin Haut Gauche et le Coin Bas Droit
        /// </summary>
        public void Hitbox()
        {
            _hitbox.Clear();
            _hitbox.Add(new Point(_position.X - Sprites.Enemy[5].Length / 2, _position.Y));
            _hitbox.Add(new Point(_position.X - Sprites.Enemy[5].Length / 2, _position.Y + Sprites.Enemy.Length - 1));
        }
    }
}
