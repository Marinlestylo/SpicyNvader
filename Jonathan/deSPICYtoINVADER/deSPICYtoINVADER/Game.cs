using deSPICYtoINVADER.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace deSPICYtoINVADER
{
    public class Game
    {
        /* Constantes */
        public const int WIDTH_OF_WIDOWS = 150;
        public const int HEIGHT_OF_WINDOWS = 80;
        public const int MARGIN = 4;//Marge de chaque de côté

        /* Static */
        public static int tics = 0;
        private static string everyPixel;//String qui va tout afficher
        public static char[][] allChars = new char[HEIGHT_OF_WINDOWS - 1][];
        public static List<Bullet> allBullets = new List<Bullet>();

        /* Attributs */
        private Enemy _enemy = new Enemy(new Point(15, 15));
        private Player _user = new Player();
        private Stopwatch _stopTime = new Stopwatch();

        public Game()
        {
            SetWindow();
            ResetArray();
            FromArrayToString();
        }

        public void GameLoop()
        {
            while (!_user.GonnaDelete)
            {
                /* Début de boucle */
                _stopTime.Restart();
                if (tics == int.MaxValue)//tics (si les tics sont au max, on les remets à 0)
                    tics = 0;
                /* Début de boucle */
                ResetArray();

                GameUpdate();

                FromArrayToString();

                



                /* Fin de boucle */
                tics++;
                int ts = (int)_stopTime.ElapsedMilliseconds;//"Stabiliser" la vitesse, indépendemment des ordis
                if (ts > 10)
                    ts = 10;
                Thread.Sleep(10 - ts);
                /* Fin de boucle */
            }
        }

        private void GameUpdate()
        {
            _user.Update();
            _enemy.Update();
            BulletUpdate();
        }

        public void BulletUpdate()
        {
            foreach (Bullet bull in allBullets)
            {
                bull.Update();
            }
        }

        /// <summary>
        /// Fais les réglages pour la taille de la fenêtre ainsi que pour le curseur
        /// </summary>
        private void SetWindow()
        {
            Console.WindowHeight = HEIGHT_OF_WINDOWS;
            Console.WindowWidth = WIDTH_OF_WIDOWS;
            Console.BufferHeight = HEIGHT_OF_WINDOWS;
            Console.BufferWidth = WIDTH_OF_WIDOWS;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Met tous les chars du tableau allChars en "espace"
        /// </summary>
        public void ResetArray()
        {
            for (int i = 0; i < allChars.Length; i++)//Boucle pour reset le tableau de char
            {
                allChars[i] = "".PadLeft(WIDTH_OF_WIDOWS - 1).ToCharArray();//La ligne entière du tableau sera rempli d'espace. On met le -1 car le 150eme char est à la pos 149
            }
        }

        /// <summary>
        /// Va a la position 0;0
        /// Transforme le tableau en une seule string
        /// Ecris la string
        /// </summary>
        public void FromArrayToString()
        {
            /*Console.SetCursorPosition(0, 0);
            Console.Write(everyPixel);//tableau vide*/
            Console.SetCursorPosition(0, 0);
            everyPixel = "";
            for (int i = 0; i < allChars.Length; i++)
            {
                everyPixel += new string(allChars[i]) + " ";
            }
            Console.Write(everyPixel);
        }
    }
}
