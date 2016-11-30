using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Solver
{
    public class MinesweeperSolver
    {
        private int[,] inputBoard;
        private int width;
        private int height;

        public MinesweeperSolver(int width, int height, int[,] inputBoard)
        {
            this.width = width;
            this.height = height;
            this.inputBoard = inputBoard;
        }

        public int[,] SolveGame()
        {
            int [,] outputBoard = new int[height, width];
            for (int row= 0;row < height;row++)
            {
                for(int col=0;col<width;col++)
                {
                    outputBoard[row, col] = GetLocationValue(row, col);
                }
            }
            return outputBoard;
        }

        public int GetLocationValue(int rowIndex, int colIndex)
        {
            try
            {
                int locationValue = 0;
                //To make the test for the corner succeed, we need to return the value -1, if the input value is -1.
                if (inputBoard[rowIndex, colIndex] == -1)
                    return -1;

                int startRow = rowIndex - 1;
                int endRow = rowIndex + 1;

                int startCol = colIndex - 1;
                int endCol = colIndex + 1;

                if (startRow < 0)
                    startRow = 0;

                if (endRow >= height)
                    endRow = height - 1;

                if (startCol < 0)
                    startCol = 0;

                if (endCol >= width)
                    endCol = width - 1;

                for (int row = startRow; row <= endRow; row++)
                {
                    for (int col = startCol; col <= endCol; col++)
                    {
                        if (row == rowIndex && col == colIndex)
                            continue;
                        if (inputBoard[row, col] == -1)
                            locationValue += 1;
                    }
                }

                return locationValue;
            }
            catch(IndexOutOfRangeException ex)
            {
                throw ex;
            }
        }
    }
}
