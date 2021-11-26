using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOPBattleship
{
    public class Input
    {
        private Display display = new();
        private char[] _alphabetList = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        readonly List<string> _menuOptionsList = new() { "1", "2", "3", "4" };
        readonly List<string> _horizontalOrVerticalShipPlacement = new() { "h", "v", "horizontal", "vertical" };
        readonly List<string> _randomOrManualShipPlacement = new() { "random", "manual" };

        public void BackToMenu()
        {
            var chosenOption = Console.ReadKey();
        }

        public string ChooseMenuOption()
        {
            while (true)
            {
                string number = Console.ReadLine();
                if (_menuOptionsList.Contains(number))
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
                string input = Console.ReadLine();
                if (_horizontalOrVerticalShipPlacement.Contains(input.ToLower()))
                {
                    return input;
                }
                display.DisplayInfoAboutWrongInput();
            }
        }


        public string ChooseTypeOfShipPlacement()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (_randomOrManualShipPlacement.Contains(input.ToLower()))
                {
                    return input;
                }
                display.DisplayInfoAboutWrongInput();
                
            }
        }

        public Tuple<string,string> GetShipPosition()
        {
            while (true)
            {
                string position = Console.ReadLine();
                if (Regex.IsMatch(position, @"^[a-jA-J0-9]+$") && position.Length is 2 or 3)
                {
                    string firstCoordinate = position.Substring(0, 1);
                    string secondCoordinate = position.Length switch
                    {
                        2 => position.Substring(1, 1),
                        3 => position.Substring(1, 2),
                        _ => null
                    };
                    Tuple<string, string> tupleWithCoordinates = Tuple.Create(firstCoordinate, secondCoordinate);
                    return tupleWithCoordinates;
                }
                
                display.DisplayInfoAboutWrongInput();

            }
        }
        
    }
}