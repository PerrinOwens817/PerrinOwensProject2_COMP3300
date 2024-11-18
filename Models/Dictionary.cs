using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PerrinOwensProject2.Models
{
    public class Dictionary
    {
        private HashSet<string> words;

        public Dictionary(string filePath)
        {
            words = new HashSet<string>();
            LoadDictionary(filePath);
        }

        private void LoadDictionary(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<List<DictionaryEntry>>(jsonData);
                foreach (var entry in data)
                {
                    foreach (var word in entry.words)
                    {
                        words.Add(words.ToLower());
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Dictionary file not found.");
            }
        }

        private bool IsValidWord(string word)
        {
            return words.Contains(word.ToLower());
        }
    }
}
