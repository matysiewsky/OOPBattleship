using System.Collections.Generic;

namespace OOPBattleship
{
    public class ShipInfo
    {
        public enum ShipType
        {
            Carrier,
            Cruiser,
            Battleship,
            Submarine,
            Destroyer
        }

        public static readonly Dictionary<ShipType, int> ShipsSizes = new()
        {
            {ShipType.Carrier, 5},
            {ShipType.Cruiser, 3},
            {ShipType.Battleship, 4},
            {ShipType.Submarine, 3},
            {ShipType.Destroyer, 2}
        };
    }
}