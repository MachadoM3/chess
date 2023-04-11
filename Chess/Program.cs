using board;
using Chess.board;
using Chess.Game;

namespace Chess
{
    class Program
    {
        static void Main(string[] main)
        {

            try
            {
                ChessMatch game = new ChessMatch();

                while (!game.EndGame)
                {
                    try
                    {

                        Console.Clear();
                        View.PrintMatch(game);



                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = View.ReadChessPosition().toPosition();
                        game.OriginPositionValidation(origin);
                        bool[,] possiblePositions = game.Brd.SelectedPiece(origin).PossibleMovs();

                        Console.Clear();
                        View.PrintBoard(game.Brd, possiblePositions);

                        Console.Write("Destiniy: ");
                        Position destiny = View.ReadChessPosition().toPosition();
                        game.DestinyPositionValidation(origin, destiny);

                        game.PerformsMov(origin, destiny);
                    }
                    catch (BoardException error)
                    {

                        Console.WriteLine(error.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Console.ReadLine();
        }

    }

}
