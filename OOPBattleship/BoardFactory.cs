using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class BoardFactory
    {
        public List<string> takenSpots;

        // only for testing (to be deleted)
        Dictionary<string, string> shipInfo = new Dictionary<string, string>();
        public List<Ship> ships { get; private set;}
        public readonly List<Square> ShipsNeighbors = new List<Square>();
        //public void RandomPlacement()
        //{
        //    
        //}


        // this method returns ship, if board property isPlacementOk is true then it should be added to player's fleet 
        public Ship ManualPlacement(Dictionary<string, string> info, Player player, ShipInfo.ShipType shiptype, Board board)
        {
            int x = Int32.Parse(info["x"]);
            int y = Int32.Parse(info["y"]);
            string position = shipInfo["position"];
            int shipLength = ShipInfo.ShipsSizes[shiptype];
            List<Square> shipSquares = new List<Square>();
            Tuple<int, int> coordinates;
            

            
            for (int i = 0; i < shipLength; i++)
            {   
                
                if (position == "horizontal")
                {
                coordinates = new Tuple<int, int>(x, y+i);
                }
                else 
                {
                coordinates = new Tuple<int, int>(x-i, y);
                }
                     
                Square shipSquare = new Square(coordinates, SquareStatus.Ship);
                shipSquares.Add(shipSquare);
            }

            Ship ship = new Ship(shipSquares, shiptype);
            // if placement is possible
            bool board.isPlacementOk = PlacementValidation(ships, ship, board);
            return ship
            
        }

        private bool PlacementValidation(List<Ship> ships, Ship ship, Board board)
        {
            // placement is possible if:
            // all squares of ship are not in player's fleet already
            // any square touch another square

            foreach (Square square in ship.SquaresPosition)
            {
                if (square.Position.Item1 >= 0 
                    && square.Position.Item2 >=0 
                    && !ShipsNeighbors.Contains(square))
                {
                    foreach(Ship fleetShip in ships)
                    {
                    if (fleetShip.SquaresPosition.Contains(square))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                
            }
            return true;
        }

        private void lookForNeighborCells(Square shipSquare, Board board)
        {
                
            var neighborsPattern = new List<(int, int)>
            { (-1, 0),
                (1, 0),
                (0, -1),
                (0, 1) };
                
            int shipX = shipSquare.Position.Item1;
            int shipY= shipSquare.Position.Item2;


            foreach ((int, int) neighbor in neighborsPattern)
            {
                if ((board.Size > shipX + neighbor.Item1 
                    && shipX + neighbor.Item1 >= 0)
                    && (board.Size > shipY + neighbor.Item2 
                    && shipY + neighbor.Item2 >= 0))
                {
                        
                    Tuple<int, int> neighborPosition = new Tuple<int, int>(neighbor.Item1 + shipX, neighbor.Item2 + shipY);
                    ShipsNeighbors.Add(new Square(neighborPosition, SquareStatus.Empty));
                }
            }
        } 
        
               
        
    }
}