using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Nvader
{
    public class Player
    {     
        private static readonly string[] PLAYER = new string[10]//Le tableau contient les string de la fusée du joueur chaque string représente une ligne
        {
            "     ▄     ",
            "    / \\    ",
            "   | o |   ",
            "   |   |   ",//UN GRAND MERCI A KALINVA POUR l'AVIS CRITIQUE APPORTÉ LORS DU DESIGN DU VAISSEAU
            "   | o |   ",
            "   |   |   ",
            "  /| o |\\  ",
            " / |___| \\ ",
            "| / |@| \\ |",
            "|/  |@|  \\|"
        };
        private const string ERASE = "           ";//string de 11 espace pour effacer le joueur
        private const int VALUE_OF_MOVEMENT = 2;//Nombre de case que parcourt le joueur à chaque fois
        private readonly int topPosition = Program.HEIGHT_OF_WINDOWS - PLAYER.Length;//Position top en fonction de la hauteur de la console - la taille du joueur
        //public Bullet shoot;


        private int _playerPreviousPosition;//Ancienne position du joueur
        private int _playerPosition;//Nouvelle position du joueur
        private int _playerLives;//Le nombe de vie du joueur
        private int _playerScore;//Valeur du score du joueur

        /// <summary>
        /// Constructeur de Player. Crée un joueur avec une position et une position précédente qui sont égale, set le nombre de vie a 3 et set le booléen de shoot à true
        /// </summary>
        public Player()
        {
            _playerPosition = Program.WIDTH_OF_WIDOWS / 2;
            _playerPreviousPosition = _playerPosition;
            _playerLives = 3;
        }

        /// <summary>
        /// Dessine 2 choses : Va a la position précédente du joueur et écris sur toute la hauteur du joueur des lignes d'espace pour effacer "l'ancien" joueur.
        /// Puis va a la nouvelle position du joueur et le dessine via une boucle
        /// </summary>
        public void DrawPlayer()
        {
            //Random color = new Random();//POUR LE FLASHY
            for (int i = 0; i < PLAYER.Length; i++)//Boucle pour effacer l'ancien joueur
            {
                Console.SetCursorPosition(_playerPreviousPosition - PLAYER[0].Length / 2, topPosition + i);//Vu que la position du joueur est au milieu du dessin du joueur et tout en haut du dessin, on revient toujours de la moitié de la largueur pour dessiner le joueur
                Console.Write(ERASE);
            }
            for (int i = 0; i < PLAYER.Length; i++)//Boucle pour dessiner le nouveau joueur
            {
                Console.SetCursorPosition(_playerPosition - PLAYER[0].Length / 2, topPosition + i);
                //int cool = color.Next(10, 16);//POUR LE FLASHY
                //Console.ForegroundColor = (ConsoleColor)cool;//POUR LE FLASHY
                Console.Write(PLAYER[i]);//On va écrire la string du tableau PLAYER
            }
            //Console.ResetColor();//Enlever les couleurs FLASHY
            Console.SetCursorPosition(_playerPosition, topPosition);//On se remet au centre du joueur
        }

        /// <summary>
        /// Méthode pour déplacer la positon du joueur. Set l'ancienne position à la position du joueur puis set la position du joueur a sa nouvelle positon et utilise la méthode Draw pour le redessiner instantanément
        /// </summary>
        /// <param name="movement">valeur de déplacement</param>
        public void Move(int movement)
        {
            _playerPreviousPosition = _playerPosition;
            _playerPosition += movement;
            DrawPlayer();
        }

        /// <summary>
        /// Set le booléen du joueur a false pour éviter de spamm les tirs
        /// </summary>
        public void Shoot()
        {
            if (Program.allBullets[Program.allBullets.Length - 1] == null)//Si il n'y a pas d'autre bullet, on peut tirer sinon non
            {
                Program.allBullets[Program.allBullets.Length - 1] = new Bullet(_playerPosition, topPosition - 2, 1, 1);
            }
        }

        /// <summary>
        /// Si le joueur se fait tirer dessus, on regarde si il lui reste plusieurs vies ou non. Si oui, il perd une vie et le jeu continue. Sinon le jeu s'arrête et affiche un message.
        /// </summary>
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

        /// <summary>
        /// Gère les update des bullets ainsi que le timing auquel le joueur pour tirer.
        /// Permet de gérer les actions du joueur via un switch. Il peut faire 3 choses : Aller à droite, aller à gauche et tirer.
        /// </summary>
        public void PlayerUpdate()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)//Lis la touche du clavier sur laquelle on appuie
                {
                    case ConsoleKey.RightArrow:                     // 80 - 1  (car 80eme char = pos 79 )    11 / 2 = 5             1    TOT : 73 position max
                        if (_playerPosition + VALUE_OF_MOVEMENT <= (Program.WIDTH_OF_WIDOWS - 1) - (PLAYER[4].Length / 2) - Program.MARGIN)//Si la position est plus petite que la valeur max, le joueur se déplace normalement
                        {
                            Move(VALUE_OF_MOVEMENT);//Se déplace (vers la droite)
                        }
                        else//Si la position du joueur va plus loin que la valeur max, on lui donne la valeur max
                        {
                            Move(((Program.WIDTH_OF_WIDOWS - 1) - (PLAYER[4].Length / 2) - Program.MARGIN) - _playerPosition);//La forumule calcule la différence entre la positon actuelle et la valeur max et donne le résultat à la méthode Move
                        }
                        break;
                    case ConsoleKey.LeftArrow:                   //         11/2 = 5   + 1 TOT : 6 position minimale
                        if (_playerPosition - VALUE_OF_MOVEMENT >= PLAYER[4].Length / 2 + Program.MARGIN)
                        {
                            Move(-1 * VALUE_OF_MOVEMENT);//Se déplace (vers la gauche)
                        }
                        else
                        {
                            Move(-1 * (_playerPosition - (PLAYER[4].Length / 2 + Program.MARGIN)));//Formule qui permet, quelque soit la valeur de mouvement, d'aller le plus à gauche possible au lieu de bloquer avant la marge
                        }
                        break;
                    case ConsoleKey.Spacebar://set le tir sur la touche espace
                        Shoot();
                        break;
                }
            }
        }
    }
}
