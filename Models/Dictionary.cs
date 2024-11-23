using Newtonsoft.Json;

namespace PerrinOwensProject2.Models
{
    /// <summary>
    /// Dictionary class -- validates words against a predefined set.
    /// </summary>
    public class Dictionary
    {
        private HashSet<string> _words;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dictionary"/> class.
        /// </summary>
        /// <param name="filePath">The path to the dictionary file.</param>
        public Dictionary(string filePath)
        {
            _words = new HashSet<string>();
            LoadDictionary(filePath);
        }

        /// <summary>
        /// Loads the dictionary from the specified file.
        /// </summary>
        /// <param name="filePath">The path to the dictionary file.</param>
        /// <exception cref="Exception">Thrown when the dictionary data fails to load or is invalid.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the dictionary file is not found.</exception>
        private void LoadDictionary(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<List<DictionaryEntry>>(jsonData);
                if (data != null)
                {
                    foreach (var entry in data)
                    {
                        foreach (var word in entry.words!)
                        {
                            if (word != null)
                            {
                                _words.Add(word.ToLower());
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Failed to load dictionary data.");
                }
            }
            else
            {
                throw new FileNotFoundException("Dictionary file not found.");
            }
        }

        /// <summary>
        /// Determines whether the specified word is valid.
        /// </summary>
        /// <param name="word">The word to validate</param>
        /// <returns>true, if the word is valid; otherwise, false.</returns>
        public bool IsValidWord(string word)
        {
            return _words.Contains(word.ToLower());
        }
    }
}

