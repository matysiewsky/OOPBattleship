namespace OOPBattleship
{
    public class Battleship
    {
        private bool isGameRunning;
        private Display display;
        private Input input;

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
                if (chosenOption == "3")
                {
                    break;
                }
            }
        }

        
    }
}