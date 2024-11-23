namespace PerrinOwensProject2.Models
{
    /// <summary>
    /// Represents the data structure for storing previous session data.
    /// </summary>
    internal class PreviousSessionData
    {
        /// <summary>
        /// Gets or sets the list of valid words entering the previous session.
        /// </summary>
        public List<(string word, DateTime time, int points)> ValidWords { get; set; }

        /// <summary>
        /// Gets or sets the list of invalid words entering the previous session.
        /// </summary>
        public List<(string word, DateTime time, string reason)> InvalidWords { get; set; }

        /// <summary>
        /// Gets or sets the timer value in seconds from the previous session.
        /// </summary>
        public int Timer { get; set; }
    }
}
