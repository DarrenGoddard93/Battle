using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    public class Grid
    {
        char[,] grid = new char[10, 10]
        {
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'}
        };

        char[,] ocean = new char[10, 10]
        {
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0','0'}
        };

        public void DrawOcean()
        {
            Console.WriteLine("Guess the co-ordinates: \n");
            Console.WriteLine("0   1   2   3   4   5   6   7   8   9 |");
            Console.WriteLine("--------------------------------------|--");

            for (int x = 0; x < 10; x++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(ocean[x, i] + " | ");
                }
                Console.WriteLine(x);
            }    
        }

         List<Ship> Ships = new List<Ship>
         {
            new Ship("Destroyer", 5, 'D'),    //Ship[0]
            new Ship("Battleship", 4, 'B'),   //Ship[1]
            new Ship("Submarine", 3, 'S'),    //Ship[2]
         };

        public bool CanPlaceShip(int direction, int randomCol, int randomRow)
        {
            int c;
            int r;

            foreach (var Ship in Ships)
            {
                if (direction == 0)
                {
                    for (c = randomCol; c < randomCol + Ship.Length; c++)
                    {
                        if (grid[randomRow, c] == Ship.Symbol)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (r = randomRow; r < randomRow + Ship.Length; r++)
                    {
                        if (grid[r, randomCol] == Ship.Symbol)
                        {
                            return false;
                        }
                    }                 
                }          
            }
            return true;
        }


        public void PlaceShipsOnGrid()
        {
            foreach (var Ship in Ships)
            {
                bool isOpen = true;
                while (isOpen)
                {
                    Random rand = new Random();
                    int randomCol = rand.Next(0, 10);
                    int randomRow = rand.Next(0, 10);
                    int direction = rand.Next(0, 2); //0 for Horizontal
                    int c;
                    int r;

                    if (direction == 0)
                    {
                        if (randomCol + Ship.Length > 10)
                        {
                            isOpen = true;
                            continue;
                        }
                        else if(CanPlaceShip(direction,randomCol,randomRow) == false)
                        {
                            isOpen = true;
                                continue;
                        }
                        else
                        {
                            for (c = randomCol; c < randomCol + Ship.Length; c++)
                            {
                               grid[randomRow, c] = Ship.Symbol;                              
                            }                          
                        }
                        isOpen = false;
                    }

                    else
                    {
                        if (randomRow + Ship.Length > 10)
                        {
                            isOpen = true;
                            continue;
                        }
                        else if (CanPlaceShip(direction, randomCol, randomRow) == false)
                        {
                            isOpen = true;
                            continue;
                        }
                        else
                        {
                            for (r = randomRow; r < randomRow + Ship.Length; r++)
                            {
                                grid[r, randomCol] = Ship.Symbol;
                            }
                        }
                        isOpen = false;
                    }            
                }
            }
        }

        int fireX;
        int fireY;

        public void PlayerTurn()
        {
            int hitCount = 0;
            int TotalShipLength = Ships[0].Length + Ships[1].Length + Ships[2].Length;

            while (hitCount < TotalShipLength)
            {
                AskXCoordinate();
                AskYCoordinate();

                Console.WriteLine($"Your co-ordinates for firing are {fireX} and {fireY}");
                Console.ReadLine();

                if (grid[fireY, fireX] == '0')
                {
                    Console.WriteLine("You missed, try again");
                    Console.ReadLine();
                    ocean[fireY, fireX] = 'X';
                    Console.Clear();
                    DrawOcean();

                }
                else if (grid[fireY, fireX] == Ships[2].Symbol)
                {
                    hitCount++;
                    Console.WriteLine($"You hit a {Ships[2].Name}");
                    Console.ReadLine();
                    grid[fireY, fireX] = '-';
                    ocean[fireY, fireX] = Ships[2].Symbol;
                    Console.Clear();
                    DrawOcean();
                }
                else if (grid[fireY, fireX] == Ships[1].Symbol)
                {
                    hitCount++;
                    Console.WriteLine($"You hit a {Ships[1].Name}");
                    Console.ReadLine();
                    grid[fireY, fireX] = '-';
                    ocean[fireY, fireX] = Ships[1].Symbol;
                    Console.Clear();
                    DrawOcean();
                }
                else if (grid[fireY, fireX] == Ships[0].Symbol)
                {
                    hitCount++;
                    Console.WriteLine($"You hit a {Ships[0].Name}");
                    Console.ReadLine();
                    grid[fireY, fireX] = '-';
                    ocean[fireY, fireX] = Ships[0].Symbol;
                    Console.Clear();
                    DrawOcean();
                }           
            }           
            Console.WriteLine("\n" + "You hit all the ships! YOU WIN!");
            Console.ReadLine();            
        }

        

        public void AskXCoordinate()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Enter x co-ordinate: ");
            string fireXasString = Console.ReadLine();
            
            bool ValidationSuccess = int.TryParse(fireXasString, out fireX);
            if (ValidationSuccess)
            {
                if (fireX > 9 || fireX < 0)
                {
                    Console.WriteLine("Error, enter a value between 0 and 9");
                    AskXCoordinate();
                }
            }
            else
            {
                Console.WriteLine("This is not a number! Enter a number between 0 and 9!");
                AskXCoordinate();
            }
        }


        public void AskYCoordinate()
        {
            Console.WriteLine("Enter y co-ordinate: ");
            string fireYasString = Console.ReadLine();

            bool ValidationSuccess = int.TryParse(fireYasString, out fireY);
            if (ValidationSuccess)
            {
                if (fireY > 9 || fireY < 0)
                {
                    Console.WriteLine("Error, enter a value between 0 and 9");
                    AskYCoordinate();
                }
            }
            else
            {
                Console.WriteLine("This is not a number! Enter a number between 0 and 9!");
                AskYCoordinate();
            }           
        }
    }
}
