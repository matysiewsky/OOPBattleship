using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class BoardFactory
    {
        public List<string> takenSpots;


        
        public readonly List<Square> ShipsNeighbors = new List<Square>();
        //public void RandomPlacement()
        //{
        //    
        //}


        // this method returns ship, if board property isPlacementOk is true then it should be added to player's fleet 
        public Ship ManualPlacement(Tuple<int, int> startCoordinates, string direction, ShipInfo.ShipType shiptype, Board board)
        {

            int x = startCoordinates.Item1;
            int y = startCoordinates.Item2;
            int shipLength = (int) shiptype;
            List<Square> shipSquares = new List<Square>();
            Tuple<int, int> coordinates;
            board.isPlacementOk = false;




            for (int i = 0; i < shipLength; i++)
            {   
                
                if (direction == "horizontal" || direction == "h")
                {
                coordinates = new Tuple<int, int>(x, y+i);
                }
                else 
                {
                coordinates = new Tuple<int, int>(x+i, y);
                }
                     
                Square shipSquare = new Square(coordinates, SquareStatus.Ship);
                shipSquares.Add(shipSquare);
            }

            Ship ship = new Ship(shipSquares, shiptype);
            // if placement is possible
            return ship;

        }

        public bool PlacementValidation(Ship ship, Board board)
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
                    foreach(Ship fleetShip in board.ships)
                    {
                        if (fleetShip.SquaresPosition.Contains(square))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
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

        private void lookForNeighborCells(Ship ship, Board board)
        {
                
            var neighborsPattern = new List<(int, int)>
            { (-1, 0),
                (1, 0),
                (0, -1),
                (0, 1) };
             
            foreach (Square shipSquare in ship.SquaresPosition)
            {
                int shipX = shipSquare.Position.Item1;
                int shipY = shipSquare.Position.Item2;


                foreach ((int, int) neighbor in neighborsPattern)
                {
                    if ((board.Size > shipX + neighbor.Item1
                        && shipX + neighbor.Item1 >= 0)
                        && (board.Size > shipY + neighbor.Item2
                        && shipY + neighbor.Item2 >= 0))
                    {

                        Tuple<int, int> neighborPosition = new Tuple<int, int>(neighbor.Item1 + shipX, neighbor.Item2 + shipY);
                        // ma zostaæ dodany je¿eli nie jest fragmentem statku oraz nie znajduje siê ju¿ w ShipNeighbors
                        //if(!ShipsNeighbors.Contains())
                        ShipsNeighbors.Add(new Square(neighborPosition, SquareStatus.Empty));
                    }
                }
            }
            
        }
        
        public void PlaceShipOnBoard(Board board, Ship ship)
        {
            if (ship != null)
            {
                foreach (Square square in ship.SquaresPosition)
                {
                    board.ocean[square.Position.Item1, square.Position.Item2] = new Square(square.Position, SquareStatus.Ship);
                    board.ships.Add(ship);
                }
            }
           
        }
        
        
        
    }
}