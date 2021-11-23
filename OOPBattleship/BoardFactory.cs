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

        //public void RandomPlacement()
        //{
        //    
        //}

        public bool ManualPlacement(Dictionary<string, string> info, Player player, ShipInfo.ShipType shiptype)
        {
            int x = Int32.Parse(info["x"]);
            int y = Int32.Parse(info["y"]);
            int shipLength = ShipInfo.ShipsSizes[shiptype];
            List<Square> shipSquares = new List<Square>();
            Tuple<int, int> position;

            
            for (int i = 0; i < shipLength; i++)
            {   
                
                if (shipInfo["position"] == "horizontal")
                {
                position = new Tuple<int, int>(x, y+i);
                }
                else 
                {
                position = new Tuple<int, int>(x, y+i);
                }
                     
                Square shipSquare = new Square(position, SquareStatus.Ship);
                shipSquares.Add(shipSquare);
            }
            Ship ship = new Ship(shipSquares, shiptype);
            // if placement is possible
            bool isPlacementOk = PlacementValidation(ships, ship);

            if (isPlacementOk)
            {
                ships.Add(ship);
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public bool PlacementValidation(List<Ship> ships, Ship ship)
        {
            // placement is possible if:
            // all squares of ship are not in player's fleet already
            // any square touch another square
            foreach (Square square in ship.SquaresPosition)
            {
                foreach(Ship fleetShip in ships)
                {
                    if (fleetShip.SquaresPosition.Contains(square))
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