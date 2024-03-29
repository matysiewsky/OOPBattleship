using System;
using System.Collections.Generic;

namespace OOPBattleship
{
    public class Board 
    {
        public Square[,] ocean;
        public int Size { get; private set;}
        public List<Ship> ships = new();


        public Board(int size)
        {
            Size = size;
            ocean = CreateBoard(Size);
            
        }

        Square[,] CreateBoard(int size)
        {
            
            Square[,] board = new Square[size, size];
            for (int i= 0; i< size; i ++)
            {
                for(int j=0; j< size; j++)
                {
                    Tuple<int, int> position = new Tuple<int, int>(i, j);
                    board[i, j] = new Square(position, SquareStatus.Empty);
                }
            }
            return board;
        }

        
    }
}