using System;

namespace OOPBattleship
{
    public class DataManager
    {
        // from A1 -> ("0","0")
        public Tuple<int, int> ConvertShipCoordinates(Tuple<string, string> position)
        {
            var firstParameter = Convert.ToChar(position.Item1);
            var firstParameterAsDigit = firstParameter % 32 -1; //https://stackoverflow.com/questions/20044730/convert-character-to-its-alphabet-integer-position
            var secondParameterAsDigit = Convert.ToInt32(position.Item2) -1;
            return new Tuple<int, int>(secondParameterAsDigit, firstParameterAsDigit);
        }
    }
}