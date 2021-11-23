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

    }
}