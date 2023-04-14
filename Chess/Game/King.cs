using board;
namespace Chess.Game
{
    class King : Piece
    {
        private ChessMatch game;

        public King(Board board, Color color, ChessMatch game) : base(board, color)
        {
            this.game = game;
        }

        private bool TestRockyForTower(Position pos)
        {
            Piece p = Board.SelectedPiece(pos);
            return p != null && p is Tower && p.Color == Color && p.AmountMov == 0;
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
            // UP
            pos.ValueDefine(Position.Row + 1, Position.Column);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // UP + RIGHT
            pos.ValueDefine(Position.Row + 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // UP + LEFT
            pos.ValueDefine(Position.Row + 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // DOWN
            pos.ValueDefine(Position.Row - 1, Position.Column);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // DOWN + RIGHT 
            pos.ValueDefine(Position.Row + 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // DOWN + LEFT
            pos.ValueDefine(Position.Row - 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // LEFT
            pos.ValueDefine(Position.Row, Position.Column - 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // RIGHT
            pos.ValueDefine(Position.Row, Position.Column + 1);
            if (Board.PositionIsValid(pos) && CanMov(pos)) mat[pos.Row, pos.Column] = true;

            // #SPECIAL PLAY 
            if(AmountMov == 0 && !game.IsCheck)
            {
                Position posT1 = new Position(pos.Row, pos.Column +3);
                //LITTLE ROCKIE
                if (TestRockyForTower(posT1)) {
                    Position p1 = new Position(pos.Row, pos.Column + 1);
                    Position p2 = new Position(pos.Row, pos.Column + 2);
                    if (Board.SelectedPiece(p1) == null && Board.SelectedPiece(p2) == null) mat[pos.Row, pos.Column + 2] = true;
                }


                Position posT2= new Position(pos.Row, pos.Column - 4);
                // BIG ROCKIE
                if (TestRockyForTower(posT1))
                {
                    Position p1 = new Position(pos.Row, pos.Column - 1);
                    Position p2 = new Position(pos.Row, pos.Column - 2);
                    Position p3 = new Position(pos.Row, pos.Column - 3);
                    if (Board.SelectedPiece(p1) == null && Board.SelectedPiece(p2) == null && Board.SelectedPiece(p3) == null) mat[pos.Row, pos.Column - 2] = true;
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

