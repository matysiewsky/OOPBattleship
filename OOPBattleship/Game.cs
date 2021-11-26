using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Game
    {

        public Board board1;
        public Board board2;
        public Player player1;
        public Player player2;
        private List<Board> boards = new List<Board>();

        private static List<Ship> shipsPlayer1 = new();
        private static List<Ship> shipsPlayer2 = new();
        private List<List<Ship>> shipsList = new()
        {
            shipsPlayer1,
            shipsPlayer2
        };

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
                foreach(List<Ship> list in shipsList)
                foreach (ShipInfo.ShipType shipType in Enum.GetValues(typeof(ShipInfo.ShipType)))
                {

                    Console.Clear();
                    display.DisplayBoard(board, placingPhase);
                    Console.WriteLine();
                    display.DisplayShipPlacementInfo(shipType.ToString(), (int) shipType);


                    string shipDirection = input.ChooseVerticalOrHorizontal();
                    display.DisplayChoosingCoordinates();
                    Tuple<int, int> shipStartCoordinates = converter.ConvertShipCoordinates(input.GetShipPosition());
                    Ship newShip = bf.ManualPlacement(shipStartCoordinates, shipDirection, shipType, board);
                    list.Add(newShip);
                    board.isPlacementOk = bf.PlacementValidation(newShip, board);
                    Console.WriteLine(board.isPlacementOk);
                    if (board.isPlacementOk)
                    {

                        bf.PlaceShipOnBoard(board, newShip);

                    }


                }
            }

            Player player1 = new("Player 1", shipsPlayer1);
            Player player2 = new("Player 2", shipsPlayer2);

            Console.ReadLine();
            
        }

        public void Round()
        {
            Player currentMove = player1;
            while (!player1.IsPlayerAlive || !player2.IsPlayerAlive)
            {
                bool player1Turn = true;
                while (player1Turn is true)
                {

                }
            }
        }
    }
}