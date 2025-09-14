using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Logic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        public readonly Direction forward;

        public Pawn(Player color)
        {
            Color = color;

            if (color == Player.White)
            {
                forward = Direction.Up;
            }
            else if (color == Player.Black)
            {
                forward = Direction.Down;
            }
        }

        // Creates a copy of the pawn piece, preserving its color and movement state
        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) && board.isEmpty(pos);
        }

        // Check if the pawn can capture an opponent's piece at the given position
        private bool CanCapture(Position pos, Board board)
        {
            if (!Board.IsInside(pos) || board.isEmpty(pos))
            {
                return false;
            }

            return board[pos].Color != Color;
        }

        // Forward moves (one or two squares)
        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position oneMovePos = from + forward;
            if (CanMoveTo(oneMovePos, board))
            {
                yield return new NormalMoves(from, oneMovePos);

                Position twoMovePos = oneMovePos + forward;

                if (!HasMoved && CanMoveTo(twoMovePos, board))
                {
                    yield return new NormalMoves(from, twoMovePos);
                }
            }
        }

        // Diagonal capture moves
        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.UpRight, Direction.UpLeft })
            {
                Position to = from + forward + dir;

                if (CanCapture(to, board))
                {
                    yield return new NormalMoves(from, to);
                }
            }
        }


        // Generates all possible moves for the pawn from a given position on the board
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }
    }
}

