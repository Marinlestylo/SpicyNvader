using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deSPICYtoINVADER.utils
{
    public static class Sprites
    {
        public static readonly string[] Player = new string[]
        {
            "▄",
            "/ \\",
            "| o |",
            "|   |",//UN GRAND MERCI A KALINVA POUR l'AVIS CRITIQUE APPORTÉ LORS DU DESIGN DU VAISSEAU
            "| o |",
            "|   |",
            "/| o |\\",
            "/ |___| \\",
            "| / |@| \\ |",
            "|/  |@|  \\|"
        };
        /*{
            "     ▄     ",
            "    / \    ",
            "   | o |   ",
            "   |   |   ",
            "   | o |   ",
            "   |   |   ",
            "  /| o |\   ",
            " / |___| \  ",
            "| / |@| \ |",
            "|/  |@|  \|"*/

        public static readonly string[] Enemy = new string[]
        {
            "▄     ▄",
            "█   █",
            "███████",
            "██ ███ ██",
            "███████████",
            "█ ███████ █",
            "█ █     █ █",
            "██ ██"
        }; //Design du monstre
        /*{
            "  ▄     ▄  ",
            "   █   █   ",
            "  ███████  ",
            " ██ ███ ██ ",
            "███████████",
            "█ ███████ █",
            "█ █     █ █",
            "   ██ ██   " }; //Design du monstre*/

        public static readonly string[] Bullet = new string[]
        {
            "▓"
        };
    }
}
