using System;

namespace Minesweeper
{
    public class Tile
    {
        public enum Visibility { Hidden, Revealed, Flagged }
        public enum Contents { Empty, Number, Mine }

        private Visibility visibility;
        private Contents contents;
        private readonly int row;
        private readonly int col;

        public Tile(int row, int col, Contents contents = Contents.Empty,
                    Visibility visibility = Visibility.Hidden)
        {
            this.visibility = visibility;
            this.contents = contents;
            this.row = row;
            this.col = col;
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

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            Tile that = (Tile)obj;
            return (that.row == row) && (that.col == col);
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + row.GetHashCode();
            hash = hash * 23 + col.GetHashCode();

            return hash;

        }

        public string GetRowColString()
        {
            return "[ " + row.ToString() + ", " + col.ToString() + " ]";
        }
    }
}

