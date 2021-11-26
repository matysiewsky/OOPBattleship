using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class BoardFactory
    {
        
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
            bool isPlacementOk = true;

            foreach(Square shipSquare in ship.SquaresPosition)
            {
                int shipX = shipSquare.Position.Item1;
                int shipY = shipSquare.Position.Item2;
                if (shipX > board.Size - 1 || shipY > board.Size - 1 
                    || board.ocean[shipX, shipY].Status == SquareStatus.Ship || board.ocean[shipX, shipY].Status == SquareStatus.Neighbor)
                {
                    isPlacementOk = false;
                }
            }
            
            return isPlacementOk;
        }

        public void LookForNeighborCells(Board board, Ship ship)
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
                    if ((board.Size-1 > shipX + neighbor.Item1
                        && shipX + neighbor.Item1 >= 0)
                        && (board.Size-1 > shipY + neighbor.Item2
                        && shipY + neighbor.Item2 >= 0))
                    {

                        Tuple<int, int> neighborPosition = new Tuple<int, int>(neighbor.Item1 + shipX, neighbor.Item2 + shipY);
                        // ma zostać dodany jeżeli nie jest fragmentem statku oraz nie znajduje się już w ShipNeighbors
                        if(board.ocean[neighborPosition.Item1, neighborPosition.Item2].Status == SquareStatus.Empty)
                        {
                            board.ocean[neighborPosition.Item1, neighborPosition.Item2].Status = SquareStatus.Neighbor;
                        }
                       
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
                }
            }
           
        }
        
        
        
    }
}