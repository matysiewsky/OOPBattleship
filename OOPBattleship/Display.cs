using System;

namespace OOPBattleship
{
    public class Display : Input
    {
        public void ShowMenu()
        {
            Console.WriteLine("Macieju, cos w tym stylu, nie?");
        }

        public void ShowBoard()
        {
            Console.WriteLine("");
        }

        public void ShowRules()
        {
            Console.WriteLine("Zasady, cos tam, daj se statki i je zatop.");
        }
        
        public void DisplayHighscore()
        {
            Console.WriteLine("");
        }

        public void shipPlacement(ShipType)
        {
            Console.WriteLine($"You are placing {ShipType}");
            Console.WriteLine("Press v - for vartical or h - for horizontal");
            string position = ShipPosition();
            Console.WriteLine("Choose first coordinate eg. A1");
            Tuple<string, string> firstCoordinate = CoordinateConversion();

        }
    }
}