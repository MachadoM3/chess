﻿using board;

namespace Chess.Game
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color) { }


        public bool CanMov(Position pos)
        {
            Piece p = Board.SelectedPiece(pos);
            return p == null || p.Color != Color;
        }


        public override bool[,] PossibleMovs()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);
            // UP
            pos.ValueDefine(Position.Row - 1, Position.Column);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Row = pos.Row - 1;
            }

            // DOWN
            pos.ValueDefine(Position.Row + 1, Position.Column);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Row = pos.Row + 1;
            }

 
            // LEFT
            pos.ValueDefine(Position.Row, Position.Column - 1);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Column = pos.Column - 1;
            }

            // RIGHT
            pos.ValueDefine(Position.Row, Position.Column + 1);
            while (Board.PositionIsValid(pos) && CanMov(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.SelectedPiece(pos) != null && Board.SelectedPiece(pos).Color != Color) break;

                pos.Column = pos.Column + 1;
            }

            return mat;
        }


        public override string ToString()
        {
            return "T";
        }

    }
}

