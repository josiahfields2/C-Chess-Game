using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Logic
{
    internal class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }
        public Knight(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }


        //Generates all potential positions a knight can move to from a given position
        private static IEnumerable<Position> PotentialToPositions(Position from)
        {
            foreach (Direction vDir in new Direction[] { Direction.Up, Direction.Down })
            {
                foreach (Direction hDir in new Direction[] { Direction.Left, Direction.Right })
                {
                    yield return from + vDir * 2 + hDir;
                    yield return from + vDir + hDir * 2;
                }
            }

        }


        //Generates all possible positions the knight can move to from a given position on the board
        private IEnumerable<Position> MovePosition(Position from, Board board)
        {
            return PotentialToPositions(from).Where(pos => Board.IsInside(pos) 
                && (board.isEmpty(pos) || board[pos].Color != Color));
        }

        //Generates all possible moves for the knight from a given position on the board
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePosition(from, board).Select(to => new NormalMoves(from, to));
        }

    }
}
