using System;
using Minesweeper;
using Xunit;


namespace MinesweeperTest
{
    public class BoardTests
    {
        Board board10x10; 

        public BoardTests() {
            board10x10 = new Board(10, 10, 5);
        }

        [Fact]
        public void TestBoardDimensions10x10()
        {
            int[,] target = board10x10.getBoard();
            Assert.True(target.Length == 100, "length as " + target.Length);
        }
    }
}
