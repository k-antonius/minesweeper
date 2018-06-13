using System;
using System.Collections.Generic;
using Minesweeper;


namespace minesweeper
{
    class GameRunner
    {
        enum Visibility
        {
            Hidden,
            Revealed,
            Flagged
        }

        static void Main(string[] args)
        {
            var x = new Tile(0, 0);
            x.IncrNumAdjMines();
            x.SetVisibility(Tile.Visibility.Revealed);

            var expression = x;

            Console.WriteLine(expression);


        }
    }
}
