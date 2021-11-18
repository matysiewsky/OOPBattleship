using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Ship
    {
        public readonly List<Square> squaresPosition = new List<Square>();
        public Ship(List<Square> shipPositions)
        {
            foreach (Square square in shipPositions)
            {
                squaresPosition.Add(square);
            }
        }

    }
}