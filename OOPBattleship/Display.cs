using System;

namespace OOPBattleship
{
    
    public class Display
    {
        private char[] _alphabetList = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(@"Welcome to BattleShip game.
            MENU

            1. New game
            2. Rules
            3. Highscore
            4. Quit

            Please press 1, 2, 3 or 4.");
        }

        public void ShowBoard()
        {
            Console.WriteLine("");
        }

        public void ShowRules()
        {
            Console.WriteLine(@"Battleship is a strategy type guessing game for two players. 
            It is played on board on which each player's fleet of ships (including battleships) are marked. 
            The locations of the fleets are concealed from the other player. 
            Players alternate turns calling 'shots' at the other player's ships, and the objective of the game is to destroy the opposing player's fleet.
            
            Starting a New Game
            Each player places the 5 ships somewhere on their board.  The ships can only be placed vertically or horizontally. Diagonal placement is not allowed.
            No part of a ship may hang off the edge of the board.  Ships may not overlap each other.  No ships may be placed on another ship. 

            Once the guessing begins, the players may not move the ships.

            The 5 ships are:  Carrier (occupies 5 spaces), Battleship (4), Cruiser (3), Submarine (3), and Destroyer (2).  

            Playing the Game
            Player's take turns guessing by calling out the coordinates. The opponent responds with 'hit' or 'miss' as appropriate.
            
            When all of the squares that one your ships occupies have been hit, the ship will be sunk.   
            
            As soon as all of one player's ships have been sunk, the game ends.

            Press any key to get back to the menu!"
            );
        }
        
        public void DisplayHighscore()
        {
            Console.WriteLine($@"HIGHSCORE

            Player 1 = {Battleship.FirstPlayerHighscore}
            Player 2 = {Battleship.SecondPlayerHighscore}

            Press any key to get back to the menu!");
        }

        public void AskManualOrRandomShipPlacement()
        {
            Console.WriteLine("Do you want to put your ships manually or randomly? Write random or manual.");
        }

        public void DisplayInfoAboutWrongInput()
        {
            Console.WriteLine("Wrong input.");
        }

        //TODO metoda wyswietlajaca status Staek trafiony, statek zatonoal itd, w zaleznosci w co zamienil sie dany square? 
        public void DisplayInfoShipHit()
        {
            Console.WriteLine("Enemy ship hit! Continue your attack (it's still your turn)");
        }
        public void DisplayInfoShipHitMissed()
        {
            Console.WriteLine("You missed.");
        }
        public void DisplayInfoShipSinked()
        {
            Console.WriteLine("Hit and sink! Continue your attack (it's still your turn)");
        }
        
        
        public void DisplayShipPlacementInfo(string shiptype, int shiplength)
        {
            Console.WriteLine($"You are placing {shiptype}. Lenght: {shiplength} fields.");
            Console.WriteLine("Press v - for vertical or h - for horizontal");
        }
        
        
            
        public void DisplayChoosingCoordinates()
        {
            Console.WriteLine(@"Choose first coordinate eg. A1
IMPORTANT - if you chose vertical placement, ship will show up from the chosen coordinate directed to the bottom of the board.
If you chose horizontal, then from the first coordinate to the right of the board.");
        }


        public void DisplayBoard(Board board, string gamephase)
        {
            // printing alphabetical first row
            for (int x=0; x < board.Size + 3; x++)
            {
                string col = " " + _alphabetList[x].ToString() + " ";
                Console.Write(col);
            }
            Console.WriteLine();


            for (int i=0; i< board.Size; i++)
            {
                int row = i + 1;
                if (row < 10)
                {
                    Console.Write(" " + row.ToString() + " ");
                }
                else
                {
                    Console.Write(row.ToString() + " ");
                }
                for (int j=0; j< board.Size; j++)
                {
                    Square square = board.ocean[i,j];
                    if (gamephase == "placing")
                    {
                        if (square.Status == SquareStatus.Empty || square.Status == SquareStatus.Ship || square.Status == SquareStatus.Neighbor)
                        {
                            Console.Write(square.GetCharacter());
                        }
                    }
                    else if (gamephase == "shooting")
                    {
                        Console.Write(square.GetCharacter());
                    }
                    
                    
                }
                Console.WriteLine();
            }
            
        }
    }
}