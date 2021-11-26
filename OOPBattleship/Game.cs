using System.Collections.Generic;

namespace OOPBattleship
{
    public class Game
    {
        public void Initialize()
        {
            // tworzenie 2 boardów, rozmieszczanie statkó
            // for (int i = 0; i < 3; i++)
            // {
            //
            // }
            Display display = new Display();
            Board board1 = new Board(10);
            System.Console.WriteLine("cfeuifer");
            display.DisplayBoard(board1);
            
            
        }
    }
}