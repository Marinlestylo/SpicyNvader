using System;
using System.Collections.Generic;

namespace Spicy_Nvader
{
    class Program
    {
        public const int WIDTH_OF_WIDOWS = 150;
        public const int HEIGHT_OF_WINDOWS = 80;
        public const int MARGIN = 1;//Marge de chaque de côté     
        public static int tics = 0;
        public static List<Bullet> allBullet = new List<Bullet>();
        public static Enemy[,] enemySwarm;
        public static Random rnd = new Random();
        static void Main (string[] args)
        {
            Console.WindowHeight = HEIGHT_OF_WINDOWS;
            Console.WindowWidth = WIDTH_OF_WIDOWS;
            Console.BufferHeight = HEIGHT_OF_WINDOWS;
            Console.BufferWidth = WIDTH_OF_WIDOWS;
            Console.SetWindowPosition(0,0);
            Console.CursorVisible = false;
            Player p1 = new Player();
            p1.DrawPlayer();
            CreateEnemySwarm(1, 1);
            /*Enemy e1 = new Enemy(15, 10);
            e1.DrawEnemy();*/
            while (true)
            {
                if (tics == int.MaxValue)
                    tics = 0;
                p1.PlayerUpdate();
                Collision();
                UpdateEnnemy();
                
                //e1.EnemyUpdate();
                tics++;
            }
        }

        public static void CreateEnemySwarm(int width, int height)
        {
            enemySwarm = new Enemy[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    enemySwarm[i, j] = new Enemy(i * 8, 5 + j * 12);
                }
            }
        }

        public static void UpdateEnnemy()
        {
            for (int i = 0; i < enemySwarm.GetLength(0); i++)
            {
                for (int j = 0; j < enemySwarm.GetLength(1); j++)
                {
                    if (enemySwarm[i, j] != null && enemySwarm[i, j].GonnaDelete)
                    {
                        enemySwarm[i, j] = null;
                    }
                    else if (enemySwarm[i, j] != null)
                    {
                        enemySwarm[i, j].EnemyUpdate();
                    }

                }
            }
        }

        public static void Collision()
        {
            for(int k = 0; k < allBullet.Count; k++)
            {
                if (allBullet[k].Direction == 1)
                {
                    for (int i = 0; i < enemySwarm.GetLength(0); i++)
                    {
                        for (int j = 0; j < enemySwarm.GetLength(1); j++)
                        {
                            if (enemySwarm[i, j] != null)
                            {
                                enemySwarm[i, j].EnemyGetShot(allBullet[k]);
                            }
                        }
                    }
                }
                if (allBullet[k].GonnaDelete)
                {
                    allBullet.RemoveAt(k);
                    allBullet[k].EraseBullet();
                    k--;//Pour ne pas aller trop loin dans la boucle
                }
            }
        }
    }
}
