namespace PerrinOwensProject2.Models
{
    /// <summary>
    /// Represents a high score entry in the game.
    /// </summary>
    public class HighScore
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the score achieved by the player.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the time when the score was achieved.
        /// </summary>
        public DateTime Time { get; set; }
    }
}