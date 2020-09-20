# Battle
Battleships Game C#

RULES

Battleships is a game which is played on a two-dimensional grid. 
Each point on the grid represents a space on a map of the ocean where a ship might be. 
In this single player game, the AI will place 3 different types of ships randomly onto the grid which are hidden. 
The program ensures the ships are placed within the boundaries of the grid and that they will not overlap each other.
The user will need to guess the co-ordinates of each ship. 
If a ship is hit, it the console will display the symbol of the type of ship that is hit. A miss will show as a 'X'.
The game is over when all ships of full length are hit.


The 3 types of ships are:

•	Destroyer – Length = 5, Symbol = D

•	Battleship – Length = 4, Symbol = B

•	Submarine – Length = 3, Symbol = S




My Aims for Coding and Techniques Used

•	Use 2D array to display the Grid. – There are x2 arrays used. 1. To store the hidden ships on the grid. 2. To display if the user attach was a hit or miss.

•	Classes – create a Ship class – Decided here to use 1 ship class instead of each ship having it’s own class. This was because all attributes of each ship are the same ie – they all have a name, length and symbol. 

•	Created a List of Ship objects to represent each individual ship.

•	Using the Random Class – To generate random co-ordinates of each ship and random direction.

•	Using For loop to iterate through the ocean array to display the grid as an output to console.

•	Using Foreach Loop to loop through each ship in the list and place \ store the position on the grid array.

•	At this point, the program ensures the ships are placed within the boundaries of the grid and that they will not overlap each other.

•	Using range of data types including string, int, bool, var.

•	Storing user inputs in a variable.

•	Using if\else statements to determine which type of ship is hit.

•	Calling a variety of methods throughout the project to reduce code duplication and perform operations.

•	Trying to break methods down so that each method will have only have 1 key purpose.
