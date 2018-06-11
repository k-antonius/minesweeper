using System;

namespace Minesweeper
{
    public class Tile
    {
        public enum Visibility { Hidden, Revealed, Flagged }
        public enum Contents { Empty, Number, Mine }

        private Visibility visibility;
        private Contents contents;

        public Tile(Contents contents = Contents.Empty,
                    Visibility visibility = Visibility.Hidden)
        {
            this.visibility = visibility;
            this.contents = contents;
        }

        public Visibility GetVisibility()
        {
            return this.visibility;
        }

        public Contents GetContents()
        {
            return this.contents;
        }

        public void SetContents(Contents updated_contents)
        {
            this.contents = updated_contents;
        }

        public void SetVisibility(Visibility updated_visibility)
        {
            this.visibility = updated_visibility;
        }

        public override string ToString()
        {
            Visibility visible_case = GetVisibility();
            Contents contents_case = GetContents();
            switch (visible_case)
            {
                case Visibility.Hidden:
                    return "H";
                case Visibility.Flagged:
                    return "X";
                case Visibility.Revealed:
                    switch (contents_case)
                    {
                        case Contents.Empty:
                            return " ";
                        case Contents.Number:
                            return "?"; // implement method
                        case Contents.Mine:
                            return "*";
                    }
                    throw new Exception("Tile revealed case invalid.");
            }
            throw new Exception("Tile ToString Error");
        }
    }
}

