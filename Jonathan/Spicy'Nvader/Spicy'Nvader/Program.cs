using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Spicy_Nvader
{
    class Program
    {
        public const int WIDTH_OF_WIDOWS = 150;
        public const int HEIGHT_OF_WINDOWS = 80;
        public const int MARGIN = 1;//Marge de chaque de côté     
        public static int tics = 0;
        public static Bullet[] allBullets;
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
            allBullets = new Bullet[5 + 1];//+ 1 car le joueur doit pouvoir tirer sa bullet
            Player p1 = new Player();
            p1.DrawPlayer();
            CreateEnemySwarm(5, 5);
            /*Enemy e1 = new Enemy(15, 10);
            e1.DrawEnemy();*/
            Stopwatch s = new Stopwatch();
            while (true)
            {
                s.Restart();
                if (tics == int.MaxValue)
                    tics = 0;
                p1.PlayerUpdate();
                Collision();
                UpdateEnnemy();
                
                //e1.EnemyUpdate();
                tics++;
                int ts = (int)s.ElapsedMilliseconds;
                Debug.WriteLine(ts);
                Thread.Sleep(10);
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
            for(int k = 0; k < allBullets.Length; k++)
            {
                if (allBullets[k] != null)
                {
                    allBullets[k].UpdateBullet();
                    if (allBullets[k].Direction == 1)
                    {
                        for (int i = 0; i < enemySwarm.GetLength(0); i++)
                        {
                            for (int j = 0; j < enemySwarm.GetLength(1); j++)
                            {
                                if (enemySwarm[i, j] != null)
                                {
                                    enemySwarm[i, j].EnemyGetShot(allBullets[k]);
                                }
                            }
                        }
                    }
                    if (allBullets[k].GonnaDelete)
                    {
                        allBullets[k].EraseBullet();
                        allBullets[k] = null;
                    }
                }
            }
        }
    }
}
