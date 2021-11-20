using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Player
    {
        public readonly string Name;
        private List<Ship> _fleet;

        public Ship AddAShipToFleet
        {
            set => _fleet.Add(value);
        }

        public Ship RemoveAShipFromFleet
        {
            set => _fleet.Remove(value);
        }
        public bool IsPlayerAlive
        {
            get
            {
                foreach (Ship ship in _fleet)
                {
                    foreach (Square square in ship.squaresPosition)
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
            _fleet = listOfShips;
        }

        public bool ShotHandler(Tuple<int, int> enemysTarget)
        {
            foreach (Ship ship in _fleet)
            {
                foreach (Square square in ship.squaresPosition)
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