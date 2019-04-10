using deSPICYtoINVADER.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deSPICYtoINVADER
{
    public class Swarm
    {
        /* Propriétés */
        /// <summary>
        /// Liste de tous les ennemis dans l'essaim
        /// </summary>
        public List<Enemy> Enemies { get; }

        /* Attributs */
        private int _direction;//Direction de l'essaim
        private int _lastDirection;//Comme l'essaim n'a pas de position, on détecte que l'on doit descendre les Enemy 
        //quand _direction et _LastDirection ne sont plus pareil

        /// <summary>
        /// Constructeur de la classe Swarm
        /// </summary>
        public Swarm()
        {
            Enemies = new List<Enemy>();
            _direction = 1;
            _lastDirection = _direction;
        }

        /// <summary>
        /// Update l'essaim
        /// </summary>
        public void Update()
        {
            foreach (Enemy e in Enemies)
            {
                e.Update();
            }
            if (Game.tics % 7 == 0)
            {
                //move
            }
        }

        /// <summary>
        /// Permet de créer un nouveal essaim de "row" ligne et de "col" colonne
        /// </summary>
        /// <param name="row">nombre de ligne</param>
        /// <param name="col">nombre de colonne</param>
        private void Create(int row, int col)
        {
            _direction = 1;//Set la direction à 1 (vers la droite)
            _lastDirection = _direction;
            if (row < 9 && col < 9)//obligation d'avoir maximum 8 Enemy par ligne et 8 par colonne
            {
                for (int i = 0; i < col; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        Enemies.Add(new Enemy(new Point(2 + i * 9, 8 + j * 13)));
                    }
                }
            }
        }

        private int ChangeDirection()
        {
            if (_direction == 1)
            {
                foreach (Enemy e in Enemies)
                {
                    if (e.BottomRightCorner.X == Game.WIDTH_OF_WIDOWS - 1 - Game.MARGIN)
                    {
                        return _direction = -1;
                    }
                }
                return _direction = 1;
            }
            else
            {
                foreach (Enemy e in Enemies)
                {
                    if (e.TopLeftCorner.X == Game.MARGIN)
                    {
                        return _direction = 1;
                    }
                }
                return _direction = -1;
            }
        }
    }
}
