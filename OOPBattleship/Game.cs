using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Game
    {

        public Board board1;
        public Board board2;
        private List<Board> boards = new List<Board>();
        private string placingPhase = "placing";
        private string shootingPhase = "shooting";
        public void Initialize(Display display, Input input, BoardFactory bf)
        {
            board1 = new Board(10);
            board2 = new Board(10);
            
            boards.Add(board1);
            boards.Add(board2);

            DataManager converter = new DataManager();

            foreach (Board board in boards)
            {
                foreach (ShipInfo.ShipType shipType in Enum.GetValues(typeof(ShipInfo.ShipType)))
                {
                    
                    Console.Clear();
                    display.DisplayBoard(board, placingPhase);
                    Console.WriteLine();
                    display.DisplayShipPlacementInfo(shipType.ToString());
                    

                    string shipDirection = input.ChooseVerticalOrHorizontal();
                    display.DisplayChoosingCoordinates();
                    Tuple<int, int> shipStartCoordinates = converter.ConvertShipCoordinates(input.GetShipPosition());
                    Ship newShip = bf.ManualPlacement(shipStartCoordinates, shipDirection, shipType, board);
                    board.isPlacementOk = bf.PlacementValidation(newShip, board);
                    Console.WriteLine(board.isPlacementOk);
                    if (board.isPlacementOk)
                    {
                        
                        bf.PlaceShipOnBoard(board, newShip);
                       
                    }

                    
                }
            }
            
            
            Console.ReadLine();
            
        }
    }
}