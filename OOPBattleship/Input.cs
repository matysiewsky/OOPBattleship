using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOPBattleship
{
    public class Input
    {
        private Display display;
        private char[] _alpha = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        readonly List<string> _list = new() { "1", "2", "3", "4" };

        public string ChooseMenuOption()
        {
            while (true)
            {
                string number = Console.ReadLine();
                if (_list.Contains(number))
                {
                    return number;
                }
                display.DisplayInfoAboutWrongInput();
            }
        }

        public string ChooseVerticalOrHorizontal()
        {
            while (true)
            {
                char input = Convert.ToChar(Console.ReadLine()); //Coalesce with fallback value?
                if (Char.ToLower(input) == 'v' || char.ToLower(input) == 'h')
                { //Char czy char?
                    return Convert.ToString(input);
                }
                
                display.DisplayInfoAboutWrongInput();
            }
        }

        public string ChooseTypeOfShipPlacement()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "manual" || input.ToLower() == "random")
                {
                    return input;
                }
                display.DisplayInfoAboutWrongInput();
                
            }
        }
        
        
        public Tuple<string,string> ShipPosition()
        {
            
            while (true)
            {
                string position = Console.ReadLine();
                if (Regex.IsMatch(position, @"^[a-zA-Z0-9]+$") && position.Length is 2 or 3)
                {
                    string firstCoordinate = position.Substring(0, 1);
                    string secondCoordinate = null;
                    if (position.Length == 2)
                    {
                        secondCoordinate = position.Substring(1, 1);
                    }
                    else if (position.Length == 3)
                    {
                        secondCoordinate = position.Substring(1, 2);
                        
                    }
                    Tuple<string, string> tupleWithCoordinates = Tuple.Create(firstCoordinate, secondCoordinate);
                    return tupleWithCoordinates;
                }
                
                display.DisplayInfoAboutWrongInput();

            }
        }
        // from A1 -> ("0","0")
        public Tuple<int, int> CoordinateConversion(Tuple<string, string> position)
        {
            var firstParameter = Convert.ToChar(position.Item1);
            var firstParameterAsDigit = firstParameter % 32;
            var secondParameterAsDigit = Convert.ToInt32(position.Item2);
            return new Tuple<int, int>(firstParameterAsDigit, secondParameterAsDigit);
        }
    }
}