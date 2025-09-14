using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Logic
{
    // Represents the current state of the chess game
    public class GameState
    {
        // The current configuration of the chessboard
        public Board Board { get; }
        // Indicates which player's turn it is
        public Player CurrentPlayer { get; private set; }

        // Initializes a new game state with the specified player and board
        public GameState(Player player, Board board)
        {
            CurrentPlayer = player;
            Board = board;
        }
        // Returns all legal moves for the piece at the given position
        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if (Board.isEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            return piece.GetMoves(pos, Board);

        }
        // Executes a move and updates the game state accordingly
        public void MakeMove(Move move)
        {
            move.Execute(Board);
            CurrentPlayer = CurrentPlayer.Opponent();
        }

    }
}
