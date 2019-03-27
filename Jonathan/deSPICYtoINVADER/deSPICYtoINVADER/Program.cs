using deSPICYtoINVADER.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deSPICYtoINVADER
{
    class Program
    {
        static void Main(string[] args)
        {
            Player bullet = new Player();
            Game game = new Game();
            bullet.Update();
            bullet.Move(1);
            game.FromArrayToString();

            Console.ReadLine();
        }
    }
}
