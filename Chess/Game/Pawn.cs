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
        private ChessMatch Game;
        public Pawn(Board board, Color color, ChessMatch game) : base(board, color)
        {
            Game = game;
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

                //#SpecialMov EnPassant
                if(pos.Row == 3)
                {
                    Position left = new Position(pos.Row, pos.Column - 1);
                    if(Board.PositionIsValid(left) && ExistEnemy(left) && Board.SelectedPiece(left) == Game.enPassantVunerable)
                    {
                        mat[left.Row -1, left.Column] = true; 
                    }
                    Position right = new Position(pos.Row, pos.Column + 1);
                    if (Board.PositionIsValid(right) && ExistEnemy(right) && Board.SelectedPiece(right) == Game.enPassantVunerable)
                    {
                        mat[right.Row -1 , right.Column] = true;
                    }

                }

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

                if (pos.Row == 4)
                {
                    Position left = new Position(pos.Row, pos.Column - 1);
                    if (Board.PositionIsValid(left) && ExistEnemy(left) && Board.SelectedPiece(left) == Game.enPassantVunerable)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(pos.Row, pos.Column + 1);
                    if (Board.PositionIsValid(right) && ExistEnemy(right) && Board.SelectedPiece(right) == Game.enPassantVunerable)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }

                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
