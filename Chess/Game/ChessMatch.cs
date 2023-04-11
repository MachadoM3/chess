using System.Collections;
using board;
using Chess.board;

namespace Chess.Game
{
    class ChessMatch
    {

        public Board Brd { get; private set; }
        public int Round { get; private set; }
        public Color SelectedPlayer { get; private set; }
        public bool EndGame { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CatchPieces;
        public bool IsCheck { get; private set; }

        public ChessMatch()
        {
            Brd = new Board(8, 8);
            Round = 1;
            SelectedPlayer = Color.White;
            EndGame = false;
            Pieces = new HashSet<Piece>();
            CatchPieces = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMov(Position origin, Position destiny)
        {
            Piece p = Brd.RemovePiece(origin);
            //p.AmoutMovIncrements();
            Piece catchPiece = Brd.RemovePiece(destiny);
            Brd.InsertPiece(p, destiny);
            if (catchPiece != null) CatchPieces.Add(catchPiece);
            return catchPiece;
        }

        public void UndoMov(Position origin, Position destiny, Piece catchPiece)
        {
            Piece p = Brd.RemovePiece(destiny);
            if (catchPiece != null)
            {
                Brd.InsertPiece(catchPiece, destiny);
                CatchPieces.Remove(catchPiece);
            }
            Brd.InsertPiece(p, origin);
        }

        public void PerformsMov(Position origin, Position destiny)
        {
            Piece catchPiece = ExecuteMov(origin, destiny);


            if (IsInCheck(SelectedPlayer))
            {
                UndoMov(origin, destiny, catchPiece);
                throw new BoardException("You can't put yourself in check");
            }

            if (IsInCheck(Enemy(SelectedPlayer))) IsCheck = true;
            else IsCheck = false;

            if (IsCheckMate(Enemy(SelectedPlayer))) EndGame = true;
            else
            {
                Round++;
                ChangePlayer();
            }
        }

        public void OriginPositionValidation(Position pos)
        {
            if (Brd.SelectedPiece(pos) == null) throw new BoardException("Don't exist piece in selected position");
            if (SelectedPlayer != Brd.SelectedPiece(pos).Color) throw new BoardException("Selected piece isn't yours");
            if (!Brd.SelectedPiece(pos).ExistPossibleMovs()) throw new BoardException("Don't exist moves for this piece");
        }

        public void DestinyPositionValidation(Position origin, Position destiny)
        {
            if (!Brd.SelectedPiece(origin).PossibleMove(destiny)) throw new BoardException("Destiny position is invalid!");
        }

        private void ChangePlayer()
        {
            if (SelectedPlayer == Color.White) SelectedPlayer = Color.Black;
            else SelectedPlayer = Color.White;
        }

        public HashSet<Piece> PlayerCatchPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in CatchPieces)
            {
                if (p.Color == color) aux.Add(p);
            }
            return aux;
        }

        public HashSet<Piece> PlayerPiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in CatchPieces)
            {
                if (p.Color == color) aux.Add(p);
            }
            aux.ExceptWith(PlayerCatchPieces(color));
            return aux;
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Brd.InsertPiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }

        public void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(Brd, Color.White));
            PutNewPiece('c', 2, new Tower(Brd, Color.White));
            PutNewPiece('d', 2, new Tower(Brd, Color.White));
            PutNewPiece('e', 2, new Tower(Brd, Color.White));
            PutNewPiece('e', 1, new Tower(Brd, Color.White));
            PutNewPiece('d', 1, new King(Brd, Color.White));
        }

        private Color Enemy(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece PlayerKing(Color color)
        {
            foreach (Piece p in PlayerPiecesInGame(color))
            {
                if (p is King) return p;
            }
            return null;
        }
        public bool IsInCheck(Color color)
        {
            Piece K = PlayerKing(color);
            foreach (Piece p in PlayerPiecesInGame(Enemy(color)))
            {
                bool[,] mat = p.PossibleMovs();
                if (mat[K.Position.Row, K.Position.Column]) return true;
            }
            return false;
        }

        public bool IsCheckMate(Color color)
        {
            if (!IsInCheck(color)) return false;
            foreach (Piece p in PlayerPiecesInGame(color))
            {
                bool[,] mat = p.PossibleMovs();
                for (int i = 0; i < Brd.Rows; i++)
                {
                    for (int j = 0; j < Brd.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = p.Position;
                            Position destiny = new Position(i, j);
                            Piece catchPiece = ExecuteMov(origin, destiny);
                            bool checkTest = IsInCheck(color);
                            UndoMov(origin, destiny, catchPiece);
                            if (!checkTest) return false;
                        }
                    }
                }
            }
            return true;
        }

    }
}

