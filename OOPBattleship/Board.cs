namespace OOPBattleship
{
    public class Board 
    {
        public Square[,] ocean;
        private bool _isPlacementOk;
        private char[] alpha = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        bool IsPlacementOk 
        { 
            get { return _isPlacementOk; } 
            set { _isPlacementOk = value; } 
        }

        public Board()
        {
            ocean = CreateBoard();
        }

        Square[,] CreateBoard()
        {
            Square[,] board = new Square[10,10];
            for (int i= 0; i< board.Length; i ++)
            {
                for(int j=0; j< board.Length; j++)
                {
                    board[i, j] = new Square(i, j);
                }
            }
            return board;
        }

        bool PlacementValidation()
        {
            return true;
        }
        
    }
}