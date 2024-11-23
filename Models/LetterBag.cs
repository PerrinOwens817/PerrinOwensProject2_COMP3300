namespace PerrinOwensProject2.Models
{
    /// <summary>
    /// represents a bag of letters used to draw random letters for word formation.
    /// </summary>
    public class LetterBag
    {
        private List<char> lettersBag;
        private Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetterBag"/> class.
        /// </summary>
        public LetterBag()
        {
            lettersBag = new List<char>
            {
                'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e',
                't', 't', 't', 't', 't', 't', 't', 't', 't',
                'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o',
                'a', 'a', 'a', 'a', 'a', 'a',
                'i', 'i', 'i', 'i', 'i', 'i',
                'n', 'n', 'n', 'n', 'n', 'n',
                's', 's', 's', 's', 's', 's',
                'h', 'h', 'h', 'h', 'h',
                'r', 'r', 'r', 'r', 'r',
                'l', 'l', 'l', 'l',
                'd', 'd', 'd',
                'u', 'u', 'u',
                'w', 'w', 'w',
                'y', 'y', 'y',
                'b', 'b',
                'c', 'c',
                'f', 'f',
                'g', 'g',
                'm', 'm',
                'p', 'p',
                'v', 'v',
                'j', 'k', 'q', 'x', 'z'
            };
            random = new Random();
        }

        /// <summary>
        /// Draws a specified number of  random letters from the letter bag.
        /// </summary>
        /// <param name="count">The number of letters to draw.</param>
        /// <returns>A list of randomly drawn letters.</returns>
        public List<char> DrawRandomLetters(int count = 7)
        {
            List<char> randomLetters = new List<char>();
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(lettersBag.Count);
                char letter = lettersBag[index];
                randomLetters.Add(letter);
                lettersBag.RemoveAt(index); // BTW this is completely optional, remove the letter if you don't want any duplicates.
            }
            return randomLetters;
        }
    }
}