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
                
                foreach (ShipInfo.ShipType shipType in Enum.GetValues(typeof(ShipInfo.ShipType)))
                {
                    
                    bool isPlacementOk = false;
                    while (!isPlacementOk)
                    {
                        display.ClearScreen();
                        display.DisplayBoard(board, placingPhase);
                        display.NewLine();
                        display.DisplayShipPlacementInfo(shipType.ToString(), (int)shipType);


                        string shipDirection = input.ChooseVerticalOrHorizontal();
                        display.DisplayChoosingCoordinates();
                        Tuple<int, int> shipStartCoordinates = converter.ConvertShipCoordinates(input.GetShipPosition());
                        Ship newShip = bf.ManualPlacement(shipStartCoordinates, shipDirection, shipType, board);
                        isPlacementOk = bf.PlacementValidation(newShip, board);
                        if (isPlacementOk)
                        {

                            bf.PlaceShipOnBoard(board, newShip);
                            bf.LookForNeighborCells(board, newShip);
                            board.ships.Add(newShip);

                        }
                        else
                        {
                            display.WrongPlacement();
                            display.PressAnyKey();
                            input.PressAnyKey();
                        }

                        
                        display.ClearScreen();
                        display.DisplayBoard(board, placingPhase);
                    }
                    

                }
                display.EndPlacingInfo();
                display.PressAnyKey();
                input.PressAnyKey();
            }

            Player player1 = new("Player 1", board1, 0);
            Player player2 = new("Player 2", board2, 0);

            display.ClearScreen();
            display.StartShootingInfo();
            display.PressAnyKey();
            input.PressAnyKey();
            Round(player1, player2, display, input);

        }

        public void Round(Player player1, Player player2, Display display, Input input)
        {
            while (player1.IsPlayerAlive && player2.IsPlayerAlive)
            {
                playerMove(player2, display, input, player1);
                playerMove(player1, display, input, player2);
            };
            

        }

        public void playerMove(Player player, Display display, Input input, Player player2)
        {
            bool roundFinished = false;
            while (!roundFinished)
            {
                
                display.ClearScreen();
                display.PlayerInfo(player2.Name);
                display.NewLine();
                display.DisplayBoard(player.PlayerBoard, shootingPhase);
                display.NewLine();
                DataManager converter = new DataManager();
                display.ChoosingCoordinates();
                Tuple<int, int> coordinates = converter.ConvertShipCoordinates(input.GetShipPosition());
                bool didPlayerMissed = player.ShotHandler2(coordinates, player.PlayerBoard);
                display.ClearScreen();
                roundFinished = didPlayerMissed;
                if (didPlayerMissed)
                {
                    display.DisplayBoard(player.PlayerBoard, shootingPhase);
                    display.MissedInfo();
                    display.PressAnyKey();
                    input.PressAnyKey();
                }
                else
                {
                    display.ShootInfo();
                    display.PressAnyKey();
                    input.PressAnyKey();
                    if (!player.IsPlayerAlive)
                    {
                        Console.Clear();
                        player2.Highscore++;
                        Battleship.SecondPlayerHighscore++;
                        display.EndGame(player2.Name);
                        input.PressAnyKey();
                        display.ShowMenu();
                        break;
                    }
                    else if (!player2.IsPlayerAlive)
                    {
                        Console.Clear();
                        player2.Highscore++;
                        Battleship.FirstPlayerHighscore++;
                        display.EndGame(player2.Name);
                        input.PressAnyKey();
                        display.ShowMenu();
                        break;
                    }
                }
                
                

            }

            
            
        }
    }
}