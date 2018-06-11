using System;
using Minesweeper;

namespace Minesweeper
{
    public class Board
    {
        private int[,] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:minesweeper.Board"/>
        /// class.
        /// </summary>
        /// <param name="num_rows">Number rows.</param>
        /// <param name="num_cols">Number cols.</param>
        /// <param name="num_mines">Number mines.</param>
        public Board(int num_rows, int num_cols, int num_mines)
        {
            this.board = new int[num_rows, num_cols];

        }

        /// <summary>
        /// Returns the 2d array representing the board.
        /// </summary>
        /// <returns>The board.</returns>
        public int[,] getBoard() {
            return board;
        }

        /// <summary>
        /// Gets the Tile stored at row, col in the board.
        /// </summary>
        /// <returns>The tile.</returns>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        public Tile GetTile(int row, int col) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the tile at board position row, col.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        /// <param name="type">Type.</param>
        public void SetTile(int row, int col, Tile tile) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is the given row, col on the board?
        /// </summary>
        /// <returns><c>true</c>, if within bounds was ised, 
        /// <c>false</c> otherwise.</returns>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        private bool IsWithinBounds(int row, int col) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// String representation of the board.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the 
        /// current <see cref="T:Minesweeper.Board"/>.</returns>
        public override string ToString() {
            throw new NotImplementedException();
        }
    }
}
