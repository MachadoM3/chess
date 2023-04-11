using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    class Bishop:Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
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
            // UP + LEFT
            pos.ValueDefine(Position.Row - 1, Position.Column - 1);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Row = pos.Row - 1;
                pos.Column = pos.Column - 1;
            }

            // UP + RIGHT
            pos.ValueDefine(Position.Row - 1, Position.Column + 1);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Row = pos.Row + 1;
                pos.Column = pos.Column + 1;
            }


            // DOWN + LEFT
            pos.ValueDefine(Position.Row + 1, Position.Column - 1);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Row = pos.Row + 1;
                pos.Column = pos.Column - 1;
            }

            // DOWN + RIGHT
            pos.ValueDefine(Position.Row + 1, Position.Column + 1);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Row = pos.Row + 1;
                pos.Column = pos.Column + 1;
            }

            return mat;
        }


        public override string ToString()
        {
            return "B";
        }
    }
}
