namespace OOPBattleship
{
    public class Battleship
    {
        private bool isGameRunning;
        private Display display;
        private Input input;
        public static int FirstPlayerHighscore { get; set; }
        public static int SecondPlayerHighscore { get; set; }

        public Battleship()
        {
            isGameRunning = true;
        }

        public void Run()
        {
            while (isGameRunning)
            {
                display.ShowMenu();
                string chosenOption = input.ChooseMenuOption();
                // display.ShowOptionABoutBoardSize?
                display.ShowRules();
                display.ShowBoard();
                display.DisplayHighscore();
                if (chosenOption == "4")
                {
                    break;
                }
            }
        }

        
    }
}