using System;


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

            Visibility x = Visibility.Hidden;
            var y = Visibility.Flagged;

            bool result = x == y;

            Console.WriteLine(result);


        }
    }
}
