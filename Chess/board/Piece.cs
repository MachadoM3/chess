using System;


namespace board
{
    abstract class Piece
    {
        public Position? Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMov { get; protected set; }
        public Board Board { get; protected set; }


        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            AmountMov = 0;

        }

        public void AmoutMovIncrements()
        {
            AmountMov++;
        }

        public void AmoutMovDecrements()
        {
            AmountMov--;
        }


        public bool ExistPossibleMovs()
        {
            bool[,] mat = PossibleMovs();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j]) return true;
                }
            }
            return false;
        }

        public bool PossibleMove(Position pos)
        {
            return PossibleMovs()[pos.Row, pos.Column];
        }

        public abstract bool[,] PossibleMovs();

    }
}

