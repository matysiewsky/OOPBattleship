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
            Regex regex = new Regex(@"^\s*(?<row>[A-J])(?<col>[1-9]|10{1,2})\s*$");
            while (true)
            {
                string position = Console.ReadLine();
                Match match = regex.Match(position.ToUpper());
                if (match.Success)
                {
                    string firstCoordinate = match.Groups["row"].Value;
                    string secondCoordinate = match.Groups["col"].Value;
                    
                    Tuple<string, string> tupleWithCoordinates = Tuple.Create(firstCoordinate, secondCoordinate);
                    return tupleWithCoordinates;
                }
                
                display.DisplayInfoAboutWrongInput();

            }
        }
        
        public void PressAnyKey()
        {
            Console.ReadLine();
        }
    }
}