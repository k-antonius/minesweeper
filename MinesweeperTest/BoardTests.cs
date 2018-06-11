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
        public void TestBoardEmpty()
        {
            Assert.True()
        }
    }
}
