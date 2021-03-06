﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Nvader
{
    public class Enemy
    {
        //Pour la hitbox de l'ennemy
        public bool GonnaDelete { get; private set; }
        public int MinX { get; private set; }//tout à gauche
        public int MaxX { get; private set; }//tout à droite
        public int MaxY { get; private set; }//tout en bas
        private int _currentTopPos;//Tout en haut de l'ennemi
        private int _currentLeftPos;
        //private int _direction;

        private static readonly string[] ENEMY = new string[8]
        /*{
            "  ▄     ▄  ",
            "   █   █   ",
            "  ███████  ",
            " ██ ███ ██ ",
            "███████████",
            "█ ███████ █",
            "█ █     █ █",
            "   ██ ██   " }; //Design du monstre*/
            {
            "▄     ▄",
            "█   █",
            "███████",
            "██ ███ ██",
            "███████████",
            "█ ███████ █",
            "█ █     █ █",
            "██ ██" }; //Design du monstre

        public Enemy(int topPos, int leftPos)
        {
            _currentTopPos = topPos;
            _currentLeftPos = leftPos;
            //_direction = 1;
            GonnaDelete = false;
        }

        public void DrawEnemy()
        {
            for (int i = 0; i < ENEMY.Length; i++)//Boucle pour dessiner l'ennemi
            {
                for (int j = 0; j < ENEMY[i].Length; j++)
                {
                    Program.allChars[_currentTopPos + i][_currentLeftPos - ENEMY[i].Length / 2 + j] = ENEMY[i][j];
                }
            }
        }

        public void MoveEnemy(int direction)
        {
            /*if (_currentLeftPos == (Program.WIDTH_OF_WIDOWS - 1) - (ENEMY[0].Length / 2) - Program.MARGIN && _direction == 1)//Aller à droite
            {
                _currentTopPos += 5;
                _direction *= -1;
            }
            else if(_currentLeftPos == ENEMY[0].Length / 2 + Program.MARGIN && _direction == -1)//Gauche
            {
                _currentTopPos += 5;
                _direction *= -1;
            }

            _currentLeftPos += _direction;*/

            _currentLeftPos += direction;

            MinX = _currentLeftPos - ENEMY[4].Length / 2;
            MaxX = _currentLeftPos + ENEMY[4].Length / 2;
            MaxY = _currentTopPos + ENEMY.Length - 1;//Sinon c'est trop bas
        }

        public void GoDown(int val)
        {
            _currentTopPos += val;
        }

        /// <summary>
        /// Pour debug
        /// </summary>
        public void GetHitBox()
        {
            Program.allChars[_currentTopPos][MinX] = '╔';
            Program.allChars[_currentTopPos][MaxX] = '╗';
            Program.allChars[MaxY][MinX] = '╚';
            Program.allChars[MaxY][MaxX] = '╝';
        }

        public bool EnemyGetShot(Bullet bull)
        {
            if (bull.PosX >= MinX && bull.PosX <= MaxX && bull.PosY >= _currentTopPos && bull.PosY <= MaxY)
            {
                GonnaDelete = true;
                bull.GonnaDelete = true;
                return true;
            }
            return false;
        }

        public void EnemyShoots()
        {
            for (int i = 0; i < Program.allBullets.Length - 1; i++)//La dernière pos est pour le joueur
            {
                if (Program.allBullets[i] == null)//Si le tableau a une place vide on crée la bullet dans cette case sinon on ne crée pas de bullet
                {
                    Program.allBullets[i] = new Bullet(_currentLeftPos, _currentTopPos + ENEMY.Length + 1, Program.HEIGHT_OF_WINDOWS - 3, -1);
                    return;
                }
            }
        }

        public void EnemyUpdate()
        {
            if (Program.rnd.Next(1, 1000) > 990 && Program.tics % 5 == 0)
            {
                EnemyShoots();
            }
            /*if (Program.tics % 10 == 0)//pour bouger pas trop vite on bouge une fois tous les 10 tics
            {
                MoveEnemy(_direction);
            }*/
            DrawEnemy();
            //GetHitBox();//DEBUG
        }
    }
}
