using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Logic
{
    internal class King : Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        //All possible directions the king can move
        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.Up,
            Direction.Down,
            Direction.Left,
            Direction.Right,
            Direction.UpLeft,
            Direction.UpRight,
            Direction.DownRight

        };
        public King(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        //Generates all possible positions the king can move to from a given position on the board
        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;
                if (Board.IsInside(to))
                {
                    continue;
                }

                if (board.isEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        //Generates all possible moves for the king from a given position on the board
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position to in MovePositions(from, board))
            {
                yield return new NormalMoves(from, to);
            }
        }
    }
}
