using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Nvader
{
    public class Player
    {
        private const int MARGIN = 1;//Marge de chaque de côté          //Le tableau contient les string de la fusée du joueur chaque string représente une ligne
        private static readonly string[] PLAYER = new string[10] { "     _     ", "    / \\    ", "   | o |   ", "   |   |   ", "   | o |   ", "   |   |   ", "  /| o |\\  ", " / |___| \\ ", "| / |@| \\ |", "|/  |@|  \\|" };
        private const string ERASE = "           ";//string de 11 espace pour effacer le joueur
        private const int VALUE_OF_MOVEMENT = 2;//Nombre de case que parcourt le joueur à chaque fois
        private readonly int topPosition = Program.HEIGHT_OF_WINDOWS - PLAYER.Length;//Position top en fonction de la hauteur de la console - la taille du joueur


        private int _playerPreviousPosition;//Ancienne position du joueur
        private int _playerPosition;//Nouvelle position du joueur
        private int _playerLives;//Le nombe de vie du joueur
        private bool _playerShoot;//variable pour savoir si le joueur pourra tier des missiles
        private int _playerScore;//Valeur du score du joueur

        /// <summary>
        /// Constructeur de Player. Crée un joueur avec une position et une position précédente qui sont égale, set le nombre de vie a 3 et set le booléen de shoot à true
        /// </summary>
        public Player()
        {
            _playerPosition = Program.WIDTH_OF_WIDOWS / 2;
            _playerPreviousPosition = _playerPosition;
            _playerLives = 3;
            _playerShoot = true;
        }

        /// <summary>
        /// Dessine 2 choses : Va a la position précédente du joueur et écris sur toute la hauteur du joueur des lignes d'espace pour effacer "l'ancien" joueur.
        /// Puis va a la nouvelle position du joueur et le dessine via une boucle
        /// </summary>
        public void DrawPlayer()
        {
            for (int i = 0; i < PLAYER.Length; i++)//Boucle pour effacer l'ancien joueur
            {
                Console.SetCursorPosition(_playerPreviousPosition - PLAYER[0].Length / 2, topPosition + i);//Vu que la position du joueur est au milieu du dessin du joueur et tout en haut du dessin, on revient toujours de la moitié de la largueur pour dessiner le joueur
                Console.Write(ERASE);
            }
            for (int i = 0; i < PLAYER.Length; i++)//Boucle pour dessiner le nouveau joueur
            {
                Console.SetCursorPosition(_playerPosition - PLAYER[0].Length / 2, topPosition + i);
                Console.Write(PLAYER[i]);//On va écrire la string du tableau PLAYER
            }
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
            _playerShoot = false;
            Bullet shoot = new Bullet(_playerPosition, topPosition - 1, 1);
            shoot.MoveTop();
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
        /// Permet de gérer les actions du joueur via un switch. Il peut faire 3 choses : Aller à droite, aller à gauche et tirer.
        /// </summary>
        public void PlayerAction()
        {
            switch (Console.ReadKey(true).Key)//Lis la touche du clavier sur laquelle on appuie
            {
                case ConsoleKey.RightArrow:                     // 80 - 1                         11 / 2 = 5             1    TOT : 73 position max
                    if (_playerPosition + VALUE_OF_MOVEMENT <= (Program.WIDTH_OF_WIDOWS - 1) - (PLAYER[4].Length / 2) - MARGIN)//Si la position est plus petite que la valeur max, le joueur se déplace normalement
                    {
                        Move(VALUE_OF_MOVEMENT);
                    }
                    else//Si la position du joueur va plus loin que la valeur max, on lui donne la valeur max
                    {
                        Move(((Program.WIDTH_OF_WIDOWS - 1) - (PLAYER[4].Length / 2) - MARGIN) - _playerPosition);//La forumule calcule la différence entre la positon actuelle et la valeur max et donne le résultat à la méthode Move
                    }
                    break;
                case ConsoleKey.LeftArrow:                   //         11/2 = 5   + 1 TOT : 6 position minimale
                    if (_playerPosition - VALUE_OF_MOVEMENT >=  PLAYER[4].Length/2 + MARGIN)
                    {
                        Move(-1 * VALUE_OF_MOVEMENT);
                    }
                    else
                    {
                        Move(-1 * (_playerPosition - (PLAYER[4].Length / 2 + MARGIN)));//Formule qui permet, quelque soit la valeur de mouvement, d'aller le plus à gauche possible au lieu de bloquer avant la marge
                    }
                    break;
                case ConsoleKey.Spacebar:
                    if (_playerShoot)
                    {
                        Shoot();
                    }
                    break;
            }
        }
    }
}
