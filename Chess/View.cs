
using board;
using Chess.Game;

namespace Chess
{
    class View
    {

        public static void PrintMatch(ChessMatch game)
        {
            PrintBoard(game.Brd);
            Console.WriteLine();
            PrintCatchPieces(game);
            Console.WriteLine();
            Console.WriteLine("Round: " + game.Round);
            if (!game.EndGame)
            {
                Console.WriteLine("Waiting play: " + game.SelectedPlayer);
                if (game.IsCheck) Console.WriteLine("CHECK!");
            }
            else
            {
                Console.WriteLine("CHECKMATE!!");
                Console.WriteLine("Winner: " + game.SelectedPlayer);
            }
        }

        public static void PrintCatchPieces(ChessMatch game)
        {
            Console.WriteLine("Catch pieces");
            Console.Write("Whites: ");
            PrintGroup(game.PlayerCatchPieces(Color.White));
            Console.WriteLine();

            ConsoleColor aux = Console.ForegroundColor;
            Console.Write("Blacks: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintGroup(game.PlayerCatchPieces(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void PrintGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach (Piece p in group)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.SelectedPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {

            ConsoleColor defaultBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j]) Console.BackgroundColor = newBackground;
                    else Console.BackgroundColor = defaultBackground;

                    PrintPiece(board.SelectedPiece(i, j));
                    Console.BackgroundColor = defaultBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = defaultBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }


        public static void PrintPiece(Piece selectedPiece)
        {
            if (selectedPiece == null) Console.Write("- ");
            else
            {

                if (selectedPiece.Color == Color.White) Console.Write(selectedPiece);
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(selectedPiece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public View()
        {
        }
    }
}

