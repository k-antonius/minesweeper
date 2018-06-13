using System;

namespace Minesweeper
{
    // Raise this exception if an invalid Tile is searched during the game.
    public class TileSearchException : SystemException
    {
        public TileSearchException()
        {
            
        }

        public TileSearchException(string message) : base(message)
        {
            
        }
    }
}
