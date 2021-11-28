using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Player
    {
        public readonly string Name;
        public Board PlayerBoard;
        public int Highscore;

        private List<Ship> Fleet
        {
            get;
        }

        public Ship AddAShipToFleet
        {
            set => Fleet.Add(value);
        }

        public Ship RemoveAShipFromFleet
        {
            set => Fleet.Remove(value);
        }
        public bool IsPlayerAlive
        {
            get
            {
                foreach (Square square in PlayerBoard.ocean)
                {
                    
                    if (square.Status == SquareStatus.Ship)
                    {
                        return true;
                    }
                    
                }
                return false;
            }
        }
        public Player(string playerName, Board board, int highscore)
        {
            Name = playerName;
            PlayerBoard = board;
            Highscore = highscore;
        }

        public bool ShotHandler(Tuple<int, int> enemysTarget)
        {
            foreach (Ship ship in Fleet)
            {
                foreach (Square square in ship.SquaresPosition)
                {
                    if ((enemysTarget.Item1, enemysTarget.Item2) != (square.Position.Item1, square.Position.Item2)) continue;

                    square.Status = SquareStatus.Hit;
                    return true;
                }
            }
            return false;
        }

        public bool ShotHandler2(Tuple<int, int> enemysTarget, Board board)
        {
            if(board.ocean[enemysTarget.Item1, enemysTarget.Item2].Status == SquareStatus.Ship)
            {
                board.ocean[enemysTarget.Item1, enemysTarget.Item2].Status = SquareStatus.Hit;
                return false;
            }
            else
            {
                board.ocean[enemysTarget.Item1, enemysTarget.Item2].Status = SquareStatus.Missed;
                return true;
            }
        }
    }
}