using System;
using System.Diagnostics;
using Minesweeper;

namespace minesweeper
{
    public class Game
    {
        const string flag = "flag";
        const string search = "search";
        private Board game_board;
        private int mines_flagged;
        private enum EndState { Win, Loss };
        private bool game_in_progress;

        public Game()
        {
            game_board = new Board(10, 10, 4);
            game_in_progress = true;
        }

        // function to determine if game is over

        // function to pass move to the board

        // function to start a new game

        // track flagged mines

        private void GameLoop()
        {
            while (game_in_progress)
            {
                // prompt for new move
            }
        }

        private int[] MovePrompt()
        {
            int[] move_choice;
            string move_type_question = 
                "Please choose whether to flag or search a tile (enter s or f).";
            Console.WriteLine(move_type_question);
            string response = Console.ReadLine();

            if (response == "s")
            {
                string search_prompt = "Please enter a row/col to search.";
                Console.WriteLine(search_prompt);
                move_choice = RowColPrompt();

            }
            else if (response == "f")
            {
                string search_prompt = "Please enter a row/col to search.";
                Console.WriteLine(search_prompt);
                move_choice = RowColPrompt();
            }
            else {
                Console.WriteLine("I did not understand that.");
                return;
            }


        }

        private int[] RowColPrompt()
        {
            Console.WriteLine("Enter row:");
            int row = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter column:");
            int col = int.Parse(Console.ReadLine());

            int [] coord = {row, col};
            return coord;
        }

        private void FlagTile(int row, int col)
        {
            var tile = game_board.GetTile(row, col);
            tile.SetVisibility(Tile.Visibility.Flagged);
            if (tile.GetContents() == Tile.Contents.Mine)
            {
                mines_flagged++;
                Debug.Assert(mines_flagged <= game_board.GetMines(),
                            "Flagged mines exceeded number of mines" +
                             " was " + mines_flagged.ToString() + " on exit.");
            }
        }

        private void Search(int row, int col)
        {
            var tile = game_board.GetTile(row, col);
            if (tile.GetContents() == Tile.Contents.Mine)
            {
                EndGame(EndState.Loss);
            }
            else if (tile.GetVisibility() != Tile.Visibility.Hidden)
            {
                return; // some error msg function
            }
            else
            {
                game_board.SearchLocation(row, col);
            }
        }

        private void Move(int row, int col, string action)
        {
            if (action == search)
            {
                Search(row, col);
            }

            if (action == flag)
            {
                FlagTile(row, col);
                if (game_board.GetMines() - mines_flagged == 0)
                {
                    EndGame(EndState.Win);
                }
            }
        }

        private void EndGame(EndState state)
        {
            game_in_progress = false;
            switch(state)
            {
                case EndState.Loss:

                    Console.WriteLine("You lose. All your base...");
                    Console.WriteLine(game_board);
                    return;
                case EndState.Win:
                    Console.WriteLine("You win. May the Force be with you.");
                    Console.WriteLine(game_board);
                    return;
            }
        }
    }
}
