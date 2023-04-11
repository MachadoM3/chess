using System;
using board;

namespace Chess.Game
{
	class ChessPosition
	{
		public char Column { get; set; }
		public int Row { get; set; }

		public ChessPosition(char column, int row)
		{
			this.Column = column;
			this.Row = row;
		}

		public Position toPosition()
		{
			return new Position(8 - Row, Column - 'a');
		}

        public override string ToString()
        {
			return "" + Column + Row;
        }
    }
}

