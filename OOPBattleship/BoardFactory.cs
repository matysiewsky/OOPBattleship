using System.Collections.Generic;

namespace OOPBattleship
{
    public class BoardFactory : Board
    {
        public List<string> takenSpots;
        Dictionary<string, string> shipInfo = new Dictionary<string, string>();
        public void RandomPlacement()
        {
            
        }

        public void ManualPlacement(Dictionary<string, string> shipInfo)
        {
            if (shipInfo["shipLength"] == "1")
            {

            }
            else
            {
                if (shipInfo["position"] == "horizontal")
                {
                    if (shipInfo["shipLength"] == "2")
                    {

                    }
                    else if (shipInfo["shipLength"] == "3")
                    {

                    } 

                }
                else if (shipInfo["position"] == "vertical")
                {
                    if (shipInfo["shipLength"] == "2")
                    {

                    }
                    else if (shipInfo["shipLength"] == "3")
                    {

                    } 
                }
            }
            private void lookForAdherentCells(int x, int y)
            {

            }

            
               
        }
    }
}