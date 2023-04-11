
using Chess.board;
using Chess.Game;

namespace board
{
    class Board
    {

        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece SelectedPiece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        public Piece SelectedPiece(int row, int column)
        {
            return pieces[row, column];
        }

        public bool HasPieceOnThisPosition(Position pos)
        {
            ValidatePosition(pos);
            return SelectedPiece(pos) != null;
        }


        public void InsertPiece(Piece p, Position pos)
        {
            if (HasPieceOnThisPosition(pos)) throw new BoardException("Exist a piece on this position");
            pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (SelectedPiece(pos) == null) return null;
            Piece aux = SelectedPiece(pos);
            aux.Position = null;
            pieces[pos.Row, pos.Column] = null;
            return aux;

        }


        public bool PositionIsValid(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns) return false;
            else return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!PositionIsValid(pos)) throw new BoardException("Invalid position");
        }
    }
}

