using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Player
    {
        public readonly string Name;

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
                foreach (Ship ship in Fleet)
                {
                    foreach (Square square in ship.SquaresPosition)
                    {
                        if (square.Status == SquareStatus.Ship)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public Player(string playerName, List<Ship> listOfShips)
        {
            Name = playerName;
            Fleet = listOfShips;
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
    }
}