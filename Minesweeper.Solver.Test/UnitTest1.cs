using System;
using Minesweeper.Solver;
using NUnit.Framework;

namespace Minesweeper.Solver.Test
{
    [TestFixture]
    public class MinesweeperTest
    {
        [Test]
        public void GetLocationValue_TopCornerSquareWithMine_Success()
        {
            int[,] inputBoard = new int [,]{ { -1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 0 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int locationValue = minesweeperSolver.GetLocationValue(0, 0);
            Assert.AreEqual(-1, locationValue);
        }

        [Test]
        public void SolveGame_With_Success()
        {
            int[,] inputBoard = new int[,] { { -1, -1, -1, 0, -1 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            //int locationValue = minesweeperSolver.GetLocationValue(10, 10);

            Assert.Throws<IndexOutOfRangeException>(() => minesweeperSolver.GetLocationValue(10, 10));
        }

        [Test]
        //[TestProperty("BottomCornerSquareTesting", "1")]
        public void GetLocationValue_BottomCornerSquareWithMine_Success()
        {
            int[,] inputBoard = new int[,] { { -1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 0 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int locationValue = minesweeperSolver.GetLocationValue(2, 2);
            Assert.AreEqual(1, locationValue);
        }

        [Test]
        //[TestProperty("TopCornerSquareTesting", "1")]
        public void GetLocationValue_CornerSquareWithoutMine_Success()
        {
            int[,] inputBoard = new int[,] { { 0, 0, 0 }, { 0, -1, 0 }, { 0, 0, 0 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int locationValue = minesweeperSolver.GetLocationValue(0, 0);
            Assert.AreEqual(1, locationValue);
        }

        [Test]
        //[TestProperty("CornerSquareTesting", "5")]
        public void GetLocationValue_SquareAllSurroundedByMines_Success()
        {
            int[,] inputBoard = new int[,] { { -1, 0, -1 }, { -1, -1, -1 }, { 0, 0, 0 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int locationValue = minesweeperSolver.GetLocationValue(0, 1);
            Assert.AreEqual(5, locationValue);
        }

        [Test]
        //[TestProperty("MiddleSquareTestingFullySurroundedWithMines", "0")]
        public void GetLocationValue_SquareInMiddleAllSurroundedByMines_Success()
        {
            int[,] inputBoard = new int[,] { { -1, -1, -1 }, { -1, 0, -1 }, { -1, -1, -1 },  { 0,0,0} };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int locationValue = minesweeperSolver.GetLocationValue(1, 1);
            Assert.AreEqual(8, locationValue);
        }

        [Test]
        //[TestProperty("MiddleSquareTestingWithoutMines", "0")]
        public void GetLocationValue_SquareInMiddleWithoutMines_Success()
        {
            int[,] inputBoard = new int[,] { {0,0,0 }, { 0, 0, 0 }, { 0,0,0}, { -1, 0, -1 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int locationValue = minesweeperSolver.GetLocationValue(1, 1);
            Assert.AreEqual(0, locationValue);
        }


        [Test]
        //[TestProperty("SolveBoardWithEmptyMines", "All Zeors")]
        public void SolveGame_WithEmptyMines_Success()
        {
            int[,] inputBoard = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }};
            int[,] expectedOutputBoard = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int[,] outputBoard = minesweeperSolver.SolveGame();

            CollectionAssert.AreEqual(expectedOutputBoard, outputBoard);
        }


        [Test]
        //[TestProperty("WithAllMines", "All -1")]
        public void SolveGame_WithAllMines_Success()
        {
            int[,] inputBoard = new int[,] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
            int[,] expectedOutputBoard = new int[,] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(3, 3, inputBoard);

            int[,] outputBoard = minesweeperSolver.SolveGame();

            CollectionAssert.AreEqual(expectedOutputBoard, outputBoard);
        }


        [Test]
        //[TestProperty("WithOneSquare", "Same square value")]
        public void SolveGame_WithOneSquare_Success()
        {
            int[,] inputBoard = new int[,] { { -1 } };
            int[,] expectedOutputBoard = new int[,] { { -1 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(1, 1, inputBoard);

            int[,] outputBoard = minesweeperSolver.SolveGame();

            CollectionAssert.AreEqual(expectedOutputBoard, outputBoard);
        }

        [Test]
        //[TestProperty("WithOneColumn", "")]
        public void SolveGame_WithOneColumn_Success()
        {
            int[,] inputBoard = new int[,] { { -1 }, { -1 }, { -1 }, { 0 }, { -1 } };
            int[,] expectedOutputBoard = new int[,] { { -1 }, { -1 }, { -1 }, { 2 }, { -1 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(1, 5, inputBoard);

            int[,] outputBoard = minesweeperSolver.SolveGame();

            CollectionAssert.AreEqual(expectedOutputBoard, outputBoard);
        }

        [Test]
        //[TestProperty("WithOneRow", "")]
        public void SolveGame_WithOneRow_Success()
        {
            int[,] inputBoard = new int[,] { { -1 , -1 , -1 , 0 ,-1 } };
            int[,] expectedOutputBoard = new int[,] { { -1, -1, -1, 2, -1 } };
            MinesweeperSolver minesweeperSolver = new MinesweeperSolver(5, 1, inputBoard);

            int[,] outputBoard = minesweeperSolver.SolveGame();
      
            CollectionAssert.AreEqual(expectedOutputBoard, outputBoard);
        }



    }
}
