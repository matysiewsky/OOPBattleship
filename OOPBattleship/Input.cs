using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Input
    {
        private char[] alpha = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        List<string> list = new() { "1", "2", "3" };
        public string ChooseMenuOption()
        {
            string number = Console.ReadLine();
            return (list.Contains(number)) ? number : ChooseMenuOption();
        }

    }
}