namespace Chess_Logic
{
    // Enum representing the two players in a chess game
    public enum Player
    {
        None,
        White,
        Black
    }

    // Extension methods for the Player enum
    public static class PlayerExtensions
    {
        // Method to get the opponent of the current player
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.Black,
                Player.Black => Player.White,
                _ => Player.None,
            };
        }
    }
}
