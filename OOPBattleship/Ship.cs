using System;

namespace OOPBattleship
{
    public class Ship: Square
    {
        public Ship(Tuple<int,int> coordinates, SquareStatus status): base(coordinates, status)
        {

        }

        public Ship(Tuple<int, int>[,] coordinatesArray, SquareStatus status): base(coordinatesArray, status)
        {

        }
    }
}