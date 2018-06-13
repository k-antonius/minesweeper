using System;
using System.Collections.Generic;
using Minesweeper;

namespace Minesweeper
{
    public class Board
    {
        private readonly Tile[,] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:minesweeper.Board"/>
        /// class.
        /// </summary>
        /// <param name="num_rows">Number rows.</param>
        /// <param name="num_cols">Number cols.</param>
        /// <param name="num_mines">Number mines.</param>
        public Board(int num_rows, int num_cols, int num_mines)
        {
            this.board = new Tile[num_rows, num_cols];
            for (int i = 0; i < num_rows; i++)
            {
                for (int j = 0; j < num_cols; j++)
                {
                    // sometimes the tile should have a mine
                    this.board[i, j] = new Tile(i, j);
                }
            }

        }

        /// <summary>
        /// Returns the 2d array representing the board.
        /// </summary>
        /// <returns>The board.</returns>
        public Tile[,] GetBoard()
        {
            return board;
        }

        /// <summary>
        /// Gets the Tile stored at row, col in the board.
        /// </summary>
        /// <returns>The tile.</returns>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        public Tile GetTile(int row, int col)
        {
            return board[row, col];
        }

        /// <summary>
        /// Is the given row, col on the board?
        /// </summary>
        /// <returns><c>true</c>, if within bounds was ised, 
        /// <c>false</c> otherwise.</returns>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        public bool IsWithinBounds(int row, int col)
        {
            var height = this.board.GetLength(0);
            var width = this.board.GetLength(1);
            return (row < height) && (row >= 0) && (col < width) && (col >= 0);
        }

        /// <summary>
        /// String representation of the board.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the 
        /// current <see cref="T:Minesweeper.Board"/>.</returns>
        public override string ToString()
        {
            string board_str = "    ";
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board_str += j.ToString() + " ";
            }
            board_str += Environment.NewLine;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (j == 0) 
                    {
                        board_str += i.ToString() + " [ ";
                        board_str += GetTile(i, j) + " ";
                    }
                    else if (j == board.GetLength(1) - 1)
                    {
                        board_str += GetTile(i, j) + " ";
                        board_str += "]" + Environment.NewLine;
                    }
                    else 
                    {
                        board_str += GetTile(i, j) + " ";
                    }

                     
                }
            }
            return board_str;
        }

        public List<Tile> FindAdjacent(int row, int col)
        {
            int[] directions = { 0, 1, -1 };
            List<Tile> neighbors = new List<Tile>();

            foreach (int row_offset in directions)
            {
                foreach (int col_offset in directions)
                {
                    if (row_offset == 0 && col_offset == 0)
                    {
                        continue;
                    }
                    var neighbor_row = row + row_offset;
                    var neighbor_col = col + col_offset;
                    if (IsWithinBounds(neighbor_row, neighbor_col))
                    {
                        var neighbor = GetTile(neighbor_row, neighbor_col);
                        neighbors.Add(neighbor);
                    }
                }
            }

            return neighbors;
        }

        // rather than having this return a bool
        // have it count the number of neighbors with mines
        // update the increment mine method in Tile to take an int
        private bool IsNeighborMined(List<Tile> neighbors)
        {
            foreach (Tile neighbor in neighbors)
            {
                if (neighbor.GetContents() == Tile.Contents.Mine)
                {
                    return true;
                }
            }
            return false;
        }

        public void SearchLocation(int row, int col)
        {
            var search_target = GetTile(row, col);
            var visibility = search_target.GetVisibility();
            var contents = search_target.GetContents();
            if (visibility != Tile.Visibility.Hidden || 
                contents == Tile.Contents.Mine)
            {
                throw new TileSearchException("Tile searched was " + search_target.GetRowColString());
            }
            var queue = new Queue<Tile>();
            queue.Enqueue(GetTile(row, col));

            while (queue.Count > 0) 
            {
                Tile current = queue.Dequeue();
                current.SetVisibility(Tile.Visibility.Revealed);
                var neighbors = FindAdjacent(current.GetRow(), 
                                             current.GetCol());

                if (IsNeighborMined(neighbors))
                {
                    foreach (Tile neighbor in neighbors)
                    {
                        if (neighbor.GetContents() == Tile.Contents.Mine)
                        {
                            current.IncrNumAdjMines();
                        }
                    }
                    continue;
                }

                foreach (Tile neighbor in neighbors)
                {
                    var neighbor_visibility = neighbor.GetVisibility();
                    if (neighbor_visibility == Tile.Visibility.Hidden &&
                        ! queue.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
