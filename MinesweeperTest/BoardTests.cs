using System;
using Minesweeper;
using Xunit;
using System.Collections.Generic;


namespace MinesweeperTest
{
    public class BoardTests
    {
        Board board10x10;
        Board board4x4;
        int height_10x10;
        int width_10x10;
        string board4x4_string;
        string board4x4_string_mine_2_2;
        string board4x4_string_row_2_empty;
        string board4x4_string_0_0_flag;


        public BoardTests()
        {
            board10x10 = new Board(10, 10, 5);
            board4x4 = new Board(4, 4, 2);
            height_10x10 = board10x10.GetBoard().GetLength(0);
            width_10x10 = board10x10.GetBoard().GetLength(1);
            board4x4_string = "    0 1 2 3 " + Environment.NewLine +
                              "0 [ H H H H ]" + Environment.NewLine +
                              "1 [ H H H H ]" + Environment.NewLine +
                              "2 [ H H H H ]" + Environment.NewLine +
                              "3 [ H H H H ]" + Environment.NewLine;

            board4x4_string_mine_2_2 = "    0 1 2 3 " + Environment.NewLine +
                              "0 [ H H H H ]" + Environment.NewLine +
                              "1 [ H H H H ]" + Environment.NewLine +
                              "2 [ H H * H ]" + Environment.NewLine +
                              "3 [ H H H H ]" + Environment.NewLine;

            board4x4_string_row_2_empty = "    0 1 2 3 " + Environment.NewLine +
                              "0 [ H H H H ]" + Environment.NewLine +
                              "1 [ H H H H ]" + Environment.NewLine +
                              "2 [         ]" + Environment.NewLine +
                              "3 [ H H H H ]" + Environment.NewLine;

            board4x4_string_0_0_flag = "    0 1 2 3 " + Environment.NewLine +
                              "0 [ X H H H ]" + Environment.NewLine +
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
            int height = board.GetBoard().GetLength(0);
            int width = board.GetBoard().GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (predicate(board.GetBoard()[i, j]))
                    {
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

        private string TileListPrinter(List<Tile> tile_list)
        {
            string output_string = "";
            foreach (Tile tile in tile_list)
            {
                output_string += tile.GetRowColString();
            }

            return output_string;
        }

        private bool TileListComparer(List<Tile> expected,
                                      List<Tile> actual) 
        {
            if (expected.Count != actual.Count) {
                return false;
            }    

            foreach (Tile tile in expected) {
                if (! actual.Contains(tile)) {
                    return false;
                }
            }
            return true;
        }

        [Fact]
        public void TestBoardDimensions10x10()
        {
            Tile[,] target = board10x10.GetBoard();
            Assert.True(target.Length == 100, "length was " + target.Length);
        }

        [Fact]
        public void TestBoardDimensions4x4()
        {
            Tile[,] target = board4x4.GetBoard();
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
        public void TestGetTile0_0onBoard10x10() 
        {
            var target = board10x10.GetTile(0,0);
            var expected = new Tile(0, 0);
            Assert.Equal(target, expected);
        }

        [Fact]
        public void TestGetTile3_1onBoard10x10()
        {
            var target = board10x10.GetTile(3, 1);
            var expected = new Tile(3, 1);
            Assert.Equal(target, expected);
        }

        [Fact]
        public void TestToString4x4()
        {
            Assert.Equal(board4x4_string, board4x4.ToString());
        }

        // test various iterations of ToString
        [Fact]
        public void TestToString4x4Mine_2_2()
        {
            Tile tile_2_2 = board4x4.GetTile(2, 2);
            tile_2_2.SetContents(Tile.Contents.Mine);
            tile_2_2.SetVisibility(Tile.Visibility.Revealed);
            Assert.Equal(board4x4_string_mine_2_2, board4x4.ToString());
        }

        [Fact]
        public void TestToString4x4Row_2Empty()
        {
            // reveal all tiles in row 2
            for (int j = 0; j < board4x4.GetBoard().GetLength(1); j++)
            {
                Tile current = board4x4.GetTile(2, j);
                current.SetVisibility(Tile.Visibility.Revealed);
            }
            Assert.Equal(board4x4_string_row_2_empty, board4x4.ToString());
        }

        [Fact]
        public void TestToString4x4Flag_0_0()
        {
            Tile tile_2_2 = board4x4.GetTile(0, 0);
            tile_2_2.SetVisibility(Tile.Visibility.Flagged);
            Assert.Equal(board4x4_string_0_0_flag, board4x4.ToString());
        }

        [Fact]
        public void TestFindAdjacent4x4_0_0()
        {
            var expected = new List<Tile>();
            expected.Add(new Tile(0, 1));
            expected.Add(new Tile(1, 0));
            expected.Add(new Tile(1, 1));

            Assert.Equal(expected, board4x4.FindAdjacent(0, 0));
        }

        [Fact]
        public void TestFindAdjacent4x4_1_2()
        {
            var expected = new List<Tile>();
            expected.Add(new Tile(0, 1));
            expected.Add(new Tile(0, 2));
            expected.Add(new Tile(0, 3));
            expected.Add(new Tile(1, 1));
            expected.Add(new Tile(1, 3));
            expected.Add(new Tile(2, 1));
            expected.Add(new Tile(2, 2));
            expected.Add(new Tile(2, 3));

            var actual = board4x4.FindAdjacent(1, 2);

            Assert.True(TileListComparer(expected, actual),
                        TileListPrinter(actual));
        }

        [Fact]
        public void TestFindAdjacent4x4_3_3()
        {
            var expected = new List<Tile>();
            expected.Add(new Tile(2, 2));
            expected.Add(new Tile(2, 3));
            expected.Add(new Tile(3, 2));

            var actual = board4x4.FindAdjacent(3, 3);

            Assert.True(TileListComparer(expected, actual),
                        TileListPrinter(actual));
        }

        [Fact]
        public void TestFindAdjacent4x4_1_3()
        {
            var expected = new List<Tile>();
            expected.Add(new Tile(0, 2));
            expected.Add(new Tile(0, 3));
            expected.Add(new Tile(1, 2));
            expected.Add(new Tile(2, 2));
            expected.Add(new Tile(2, 3));

            var actual = board4x4.FindAdjacent(1, 3);

            Assert.True(TileListComparer(expected, actual),
                        TileListPrinter(actual));
        }

        [Fact]
        public void TestFindAdjacent4x4_2_0()
        {
            var expected = new List<Tile>();
            expected.Add(new Tile(1, 0));
            expected.Add(new Tile(1, 1));
            expected.Add(new Tile(2, 1));
            expected.Add(new Tile(3, 0));
            expected.Add(new Tile(3, 1));

            var actual = board4x4.FindAdjacent(2, 0);

            Assert.True(TileListComparer(expected, actual),
                        TileListPrinter(actual));
        }


    }
}
