using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarCardGame.Interface;
using TheWarCardGame.Services;

namespace TheWarCardGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of players: ");
            int numPlayers = int.Parse(Console.ReadLine());

            Console.Write("Enter number of successive games to run: ");
            int numGames = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numGames; i++)
            {
                IWarGame warGame = new WarGame(numPlayers);
                warGame.Play();
                warGame.DisplayResult();
            }
        }
    }
}
