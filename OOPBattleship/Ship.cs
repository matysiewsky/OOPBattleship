using System;
using System.Collections.Generic;
using static OOPBattleship.ShipInfo;

namespace OOPBattleship
{
    public class Ship
    {
        public readonly List<Square> SquaresPosition;
        public readonly ShipType Type;
        public int Size;

        public Ship(List<Square> shipPositions, ShipType type)
        {
            SquaresPosition = shipPositions;
            Type = type;
            Size = (int) type;
        }

    }


}