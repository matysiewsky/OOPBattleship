using System;

namespace OOPBattleship
{
    public class Square
    {
        protected Tuple<int, int> positionCoordinates;

        public SquareStatus status;

        public Tuple<int, int> Position { get; }

        public Square(Tuple<int, int> coordinates, SquareStatus status)
        {
            Position = coordinates;
            this.status = status;
        }

        public string GetCharacter() => status switch
        {
            SquareStatus.Empty => "X",
            SquareStatus.Ship => "Ship",
            SquareStatus.Hit => "Hit",
            SquareStatus.Missed => "Miss"
        };

        public override string ToString() => status switch
        {
            SquareStatus.Empty => "",
            SquareStatus.Ship => "",
            SquareStatus.Hit => "",
            SquareStatus.Missed => ""
        };

    }


    public enum SquareStatus
    {
        Empty = 0,
        Ship = 1,
        Hit = 2,
        Missed = 3
    }
}
