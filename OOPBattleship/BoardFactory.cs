using System.Collections.Generic;

namespace OOPBattleship
{
    public class BoardFactory : Board
    {
        public List<string> takenSpots;

        // only for testing (to be deleted)
        Dictionary<string, string> shipInfo = new Dictionary<string, string>();

        public void RandomPlacement()
        {
            
        }

        public bool ManualPlacement(Dictionary<string, string> shipInfo, Player player)
        {
            int x = Int16.Parse(shipInfo["x"]);
            int y = Int16.Parse(shipInfo["y"]);
            int shipLength = Int16.Parse(shipInfo["shipLength"]);
            List<Square> shipSquares;
            Tuple<int, int> position

            
            for (int i = 0; i < shipLength; i++)
            {   
                if (shipLength == 0)
                {
                position = new Tuple<int, int>(x, y);
                } 
                else 
                {
                    if (shipInfo["position"] == "horizontal")
                    {
                    position = new Tuple<int, int>(x, y+i);
                    }
                    else if (shipInfo["position"] == "vertical")
                    {
                    position = new Tuple<int, int>(x, y+i);
                    }
                }
                         
                Square shipSquare = new Square(position, SquareStatus.Ship);
                shipSquares.Add(shipSquare);
            }
            Ship ship = new Ship(shipSquares);
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
            /*private void lookForNeighborCells(int x, int y)
            {

            }*/        
               
    }
}