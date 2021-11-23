using System;

namespace OOPBattleship
{
    public class Board 
    {
        public Square[,] ocean;
        private bool _isPlacementOk;

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
                    Tuple<int, int> position = new Tuple<int, int>(i, j);
                    board[i, j] = new Square(position, SquareStatus.Empty);
                }
            }
            return board;
        }

        
    }
}