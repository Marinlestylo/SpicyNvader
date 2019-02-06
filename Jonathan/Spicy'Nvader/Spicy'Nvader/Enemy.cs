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
        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public bool GonnaDelete { get; private set; }

        private int _currentTopPos;//Tout en haut de l'ennemi

        private int _currentLeftPos;
        private int _previousTopPos;
        private int _previousLeftPos;
        private int _direction;
        private const string ERASE = "           ";

       
        private Bullet bull;

        private static readonly string[] ENEMY = new string[8]
        {
            "  ▄     ▄  ",
            "   █   █   ",
            "  ███████  ",
            " ██ ███ ██ ",
            "███████████",
            "█ ███████ █",
            "█ █     █ █",
            "   ██ ██   " }; //Design du monstre

        public Enemy(int topPos, int leftPos)
        {
            _currentTopPos = topPos;
            _currentLeftPos = leftPos;
            _previousTopPos = _currentTopPos;
            _previousLeftPos = _currentLeftPos;
            _direction = 1;
            GonnaDelete = false;
        }

        public void DrawEnemy()
        {
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            for (int i = 0; i < ENEMY.Length; i++)//Boucle pour effacer l'ancienne position de l'ennemi
            {
                Console.SetCursorPosition(_previousLeftPos - ENEMY[0].Length / 2, _previousTopPos + i);
                Console.Write(ERASE);
            }
            for (int i = 0; i < ENEMY.Length; i++)//Boucle pour dessiner l'ennemi
            {
                Console.SetCursorPosition(_currentLeftPos - ENEMY[0].Length / 2, _currentTopPos + i);
                Console.Write(ENEMY[i]);
            }

            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        public void MoveEnemy()
        {
            if (_currentLeftPos == (Program.WIDTH_OF_WIDOWS - 1) - (ENEMY[0].Length / 2) - Program.MARGIN && _direction == 1)//Aller à droite
            {
                _currentTopPos += 5;
                _direction *= -1;
            }
            else if(_currentLeftPos == ENEMY[0].Length / 2 + Program.MARGIN && _direction == -1)//Gauche
            {
                _currentTopPos += 5;
                _direction *= -1;
            }
            else
            {
                _previousTopPos = _currentTopPos;
            }
            _previousLeftPos = _currentLeftPos;
            _currentLeftPos += _direction;

            MinX = _currentLeftPos - ENEMY[0].Length / 2;
            MaxX = _currentLeftPos + ENEMY[0].Length / 2;
            MaxY = _currentTopPos + ENEMY.Length; ;

            DrawEnemy();
        }

        public void EnemyGetShot(Bullet bull)
        {
            if (bull.PosX > MinX && bull.PosX < MaxX && bull.PosY > _currentTopPos && bull.PosY < MaxY)
            {
                GonnaDelete = true;
                int cursorLeft = Console.CursorLeft;
                int cursorTop = Console.CursorTop;
                bull.GonnaDelete = true;

                for (int i = 0; i < ENEMY.Length; i++)//Boucle pour effacer l'ancienne position de l'ennemi
                {
                    Console.SetCursorPosition(_currentLeftPos - ENEMY[0].Length / 2, _previousTopPos + i);
                    Console.Write(ERASE);
                }
            }
        }

        public void EnemyShoots()
        {
            if (bull == null)
            {
                bull = new Bullet(_currentLeftPos, _currentTopPos + ENEMY.Length + 1, Program.HEIGHT_OF_WINDOWS - 1, -1);
                bull.DrawBullet();
            }
        }

        public void EnemyUpdate()
        {
            if (Program.rnd.Next(1, 500001) == 666)
            {
                EnemyShoots();
            }
            if (bull != null)
            {
                bull.UpdateBullet();
                if (bull.GonnaDelete)
                {
                    bull = null;
                }
            }
            if (Program.tics % 10000 == 0)//pour bouger pas trop vite on bouge une fois tous les 10000 tics
            {
                MoveEnemy();
            }
        }
    }
}
