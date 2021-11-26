using System;

namespace OOPBattleship
{
    public class Square
    {
        protected Tuple<int, int> positionCoordinates;

        public SquareStatus Status { get; set; }

        public Tuple<int, int> Position { get; }

        public Square(Tuple<int, int> coordinates, SquareStatus status)
        {
            Position = coordinates;
            this.Status = status;
        }

        public string GetCharacter() => Status switch
        {
            SquareStatus.Empty => "🌊",
            SquareStatus.Ship => "🚢",
            SquareStatus.Hit => "🎯",
            SquareStatus.Missed => "⛔",
            SquareStatus.Neighbor => "~"
        };

        // public override string ToString() => Status switch
        // {
        //     SquareStatus.Empty => "",
        //     SquareStatus.Ship => "",
        //     SquareStatus.Hit => "",
        //     SquareStatus.Missed => ""
        // };

    }


    public enum SquareStatus
    {
        Empty = 0,
        Ship = 1,
        Hit = 2,
        Missed = 3,
        Neighbor = 4
    }
}
