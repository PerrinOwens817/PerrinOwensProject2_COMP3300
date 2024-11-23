namespace PerrinOwensProject2.Models
{
    /// <summary>
    /// Represents an entry in the dictionary, containing a letter and associated words.
    /// </summary>
    public class DictionaryEntry
    {
       /// <summary>
       /// Gets or sets the letter associated with the dictionary entry.
       /// </summary>
        public string? letter { get; set; }

       /// <summary>
       /// Gets or sets the list of words associated with the letter.
       /// </summary>
        public List<string>? words { get; set; }
    }
}