using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class BoardFactory
    {
        public List<string> takenSpots;

        // only for testing (to be deleted)
        Dictionary<string, string> shipInfo = new Dictionary<string, string>();

        //public void RandomPlacement()
        //{
        //    
        //}

        public bool ManualPlacement(Dictionary<string, string> info, Player player, ShipType shiptype)
        {
            int x = Int32.Parse(info["x"]);
            int y = Int32.Parse(info["y"]);
            int shipLength = ShipInfo.ShipsSizes[shiptype];
            List<Square> shipSquares;
            Tuple<int, int> position;

            
            for (int i = 0; i < shipLength; i++)
            {   
                
                if (shipInfo["position"] == "horizontal")
                {
                position = new Tuple<int, int>(x, y+i);
                }
                else if (shipInfo["position"] == "vertical")
                {
                position = new Tuple<int, int>(x, y+i);
                }
                     
                Square shipSquare = new Square(position, SquareStatus.Ship);
                shipSquares.Add(shipSquare);
            }
            Ship ship = new Ship(shipSquares, shiptype);
            // if placement is possible
            bool isPlacementOk = PlacementValidation(player, ship);

            if (isPlacementOk)
            {
                player.AddAShipToFleet(ship);
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool PlacementValidation(Player player, Ship ship)
        {
            // placement is possible if:
            // all squares of ship are not in player's fleet already
            // any square touch another square
            foreach (Square square in ship.SquaresPosition)
            {
                foreach(Ship ship in player.fleet)
                {
                    if (ship.Contains(square))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
            /*private void lookForNeighborCells(int x, int y)
            {

            }*/        
               
    }
}