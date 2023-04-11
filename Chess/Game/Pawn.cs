using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        private bool ExistEnemy(Position pos)
        {
            Piece p = Board.SelectedPiece(pos);
            return p != null && p.Color != Color;
        }

        private bool ItsFree(Position pos)
        {
            return Board.SelectedPiece(pos) == null;
        }

        public bool CanMov(Position pos)
        {
            Piece p = Board.SelectedPiece(pos);
            return p == null || p.Color != Color;
        }


        public override bool[,] PossibleMovs()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);


            if (Color == Color.White)
            {
                pos.ValueDefine(Position.Row - 1, Position.Column);
                if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

                pos.ValueDefine(Position.Row - 2, Position.Column);
                if (Board.PositionIsValid(pos) && CanMov(pos) && AmountMov == 0) mat[pos.Row, pos.Column] = true;

                pos.ValueDefine(Position.Row - 1, Position.Column - 1);
                if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

                pos.ValueDefine(Position.Row - 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            }
            else
            {
                pos.ValueDefine(Position.Row + 1, Position.Column);
                if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

                pos.ValueDefine(Position.Row + 2, Position.Column);
                if (Board.PositionIsValid(pos) && CanMov(pos) && AmountMov == 0) mat[pos.Row, pos.Column] = true;

                pos.ValueDefine(Position.Row + 1, Position.Column - 1);
                if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

                pos.ValueDefine(Position.Row + 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
