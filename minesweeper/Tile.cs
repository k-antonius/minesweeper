using System;

namespace Minesweeper
{
    public class Tile
    {
        public enum Visibility { Hidden, Revealed, Flagged}
        public enum Contents {Empty, Number, Mine}

        private Visibility visibility;
        private Contents contents;
        private readonly int[] location;


        public Tile(int row, int col)
        {
            this.visibility = Visibility.Hidden;
            this.contents = Contents.Empty;
        }

        public Tile(int row, int col, Contents initial_contents,
                    Visibility initial_visibility)
        {
            this.visibility = initial_visibility;
            this.contents = initial_contents;
        }

        public Visibility GetVisibility() {
            return this.visibility;
        }

        public Contents GetContents() {
            return this.contents;
        }

        public void SetContents(Contents updated_contents) {
            this.contents = updated_contents;
        }

        public void SetVisibility(Visibility updated_visibility) {
            this.visibility = updated_visibility;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}

