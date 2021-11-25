namespace OOPBattleship
{
    public class Battleship
    {
        private bool isGameRunning;
        private Display display = new();
        private Input input = new();
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

                switch (chosenOption)
                {
                    //"1" => Game.Initialize(display)
                    case "2":
                        display.ShowRules();
                        input.BackToMenu();
                        break;
                    case "3":
                        display.DisplayHighscore();
                        input.BackToMenu();
                        break;
                    case "4":
                        isGameRunning = false;
                        break;
                }

            }
        }

        
    }
}