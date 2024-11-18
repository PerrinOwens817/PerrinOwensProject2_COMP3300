using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PerrinOwensProject2.Models;

namespace PerrinOwensProject2.View
{
    public partial class MainForm : Form
    {
        private LetterBag letterBag;
        private Dictionary dictionary;
        private List<string> enteredWords;
        private List<(string word, DateTime time, int points)> validWords;
        private List<(string word, DateTime time, string reason)> invalidWords;

        public MainForm()
        {
            InitializeComponent();
            letterBag = new LetterBag();
            dictionary = new Dictionary("C:\\Users\\periw\\source\\repos\\PerrinOwensProject2\\JSON File\\dictionary.json"); // Put the path to dictionary.json here
            enteredWords = new List<string>();
            validWords = new List<(string word, DateTime time, int points)>();
            invalidWords = new List<(string word, DateTime time, string reason)>();
            DisplayRandomLetters();
        }

        private void DisplayRandomLetters()
        {
            List<char> randomLetters = letterBag.DrawRandomLetters();
            lblRandomLetters.Text = string.Join(", ", randomLetters);
        }

        private void lblResult_Click(object sender, EventArgs e)
        {
            //...
        }

        private void txtWordEntry_TextChanged(object sender, EventArgs e)
        {
            //...
        }

        private void btnSubmitWord_Click(object sender, EventArgs e)
        {
            string enteredWord = txtWordEntry.Text;
            if (IsValidWord(enteredWord))
            {
                lblResult.Text = $"Valid word! Points: {enteredWord.Length}";
            }
            else
            {
                lblResult.Text = "Invalid word or too short!";
            }
        }

        private bool IsValidWord(string word)
        {
            if (word.Length < 3)
            {
                return false;
            }

            List<char> availableLetters = new List<char>(lblRandomLetters.Text.Replace(", ", "").ToCharArray());

            foreach (char letter in word)
            {
                if (!availableLetters.Contains(letter))
                {
                    return false;
                }

                availableLetters.Remove(letter);
            }

            return true;
        }
    }
}
