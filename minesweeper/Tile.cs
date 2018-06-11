using System;

namespace Minesweeper
{
    public class Tile
    {
        public enum Visibility { Hidden, Revealed, Flagged}
        public enum Contents {Empty, Number, Mine}

        private Visibility visibility;
        private Contents contents;

        public Tile(Contents contents = Contents.Empty,
                    Visibility visibility = Visibility.Hidden)
        {
            this.visibility = visibility;
            this.contents = contents;
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

