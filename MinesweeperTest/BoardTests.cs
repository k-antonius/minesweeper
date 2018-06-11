using System;
using Minesweeper;
using Xunit;


namespace MinesweeperTest
{
    public class BoardTests
    {
        Board board10x10;
        Board board4x4;
        int height_10x10;
        int width_10x10;
        string board4x4_string;

        public BoardTests() 
        {
            board10x10 = new Board(10, 10, 5);
            board4x4 = new Board(4, 4, 2);
            height_10x10 = board10x10.getBoard().GetLength(0);
            width_10x10 = board10x10.getBoard().GetLength(1);
            board4x4_string = "    0 1 2 3 " + Environment.NewLine + 
                              "0 [ H H H H ]" + Environment.NewLine + 
                              "1 [ H H H H ]" + Environment.NewLine + 
                              "2 [ H H H H ]" + Environment.NewLine + 
                              "3 [ H H H H ]" + Environment.NewLine;
        }

        /// <summary>
        /// If predicate function does not return true for every element in
        /// the board, returns false. Otherwise, True.
        /// </summary>
        /// <returns><c>true</c>, if helper was predicated, <c>false</c> otherwise.</returns>
        /// <param name="board">Board.</param>
        /// <param name="predicate">Predicate.</param>
        bool PredicateHelper(Board board, Func<Tile, bool> predicate)
        {
            int height = board.getBoard().GetLength(0);
            int width = board.getBoard().GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (predicate(board.getBoard()[i, j])) {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [Fact]
        public void TestBoardDimensions10x10()
        {
            Tile[,] target = board10x10.getBoard();
            Assert.True(target.Length == 100, "length was " + target.Length);
        }

        [Fact]
        public void TestBoardDimensions4x4()
        {
            Tile[,] target = board4x4.getBoard();
            Assert.True(target.Length == 16, "length was " + target.Length);
        }

        [Fact]
        public void TestAllTilesEmptyAndHidden10x10()
        {
            Assert.True(PredicateHelper(board10x10,
                                        (Tile tile) =>
                            tile.GetVisibility() == Tile.Visibility.Hidden &&
                            tile.GetContents() == Tile.Contents.Empty)); 
        }

        [Fact]
        public void TestGetTile0_0() 
        {
            Assert.Throws<NotImplementedException>(() => 
                                                   board10x10.GetTile(0,0)); 
        }

        [Fact]
        public void TestToString4x4()
        {
            Assert.Equal(board4x4_string, board4x4.ToString());
        }






    }
}
