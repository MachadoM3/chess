using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
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

            pos.ValueDefine(Position.Row - 1, Position.Column - 2);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            pos.ValueDefine(Position.Row - 2, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            pos.ValueDefine(Position.Row - 2, Position.Column + 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            pos.ValueDefine(Position.Row - 1, Position.Column + 2);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            pos.ValueDefine(Position.Row + 1, Position.Column + 2);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            pos.ValueDefine(Position.Row + 2, Position.Column + 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            pos.ValueDefine(Position.Row + 2, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            pos.ValueDefine(Position.Row + 1, Position.Column - 2);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            return mat;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
