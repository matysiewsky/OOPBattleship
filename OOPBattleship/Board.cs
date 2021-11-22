using System;

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
                    Tuple<int, int> position = new Tuple<int, int>(i, j);
                    board[i, j] = new Square(position, SquareStatus.Empty);
                }
            }
            return board;
        }

        protected bool PlacementValidation(Player player, Ship ship)
        {
            // placement is possible if:
            // all squares of ship are not in player's fleet already
            // any square touch another square
            foreach (Square square in ship.squaresPosition)
            {
                foreach(Ship ship in player.fleet)
                {
                    if (ship.Contains(square))
                    {
                        return false
                    }
                }
            }
            return true;
        }
        
    }
}