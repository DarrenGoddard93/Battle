using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Introduction();
            
            Grid grid = new Grid();
          
            grid.PlaceShipsOnGrid();
            grid.DrawOcean();
            grid.PlayerTurn();

        }



        static void Introduction()
        {
            Console.Title = "Battleships C# Game";
            Console.WriteLine("Welcome to my Battleships Game!\n"+
            "There are 3 ships hidden in the grid ... Find all 3 ships to win!\n\n"+
            "Submarine has a length of 3.\n" +
            "Battleship has a length of 4.\n" +
            "Destroyer has a length of 5.\n\n" +
            "Press enter to play");
            Console.ReadLine();
            Console.Clear();
        }

    }

}
