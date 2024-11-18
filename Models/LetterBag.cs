using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrinOwensProject2.Models
{
    public class LetterBag
    {
        private List<char> lettersBag;
        private Random random;

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

        public List<char> DrawRandomLetters(int count = 7)
        {
            List<char> randomLetters = new List<char>();
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(lettersBag.Count);
                char letter = lettersBag[index];
                randomLetters.Add(letter);
                lettersBag.RemoveAt(index); // BTW this is competely optional, remove the letter if you don't want any duplicates.
            }
            return randomLetters;
        }
    }
}
