using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PerrinOwensProject2.Models;
using Timer = System.Threading.Timer;

namespace PerrinOwensProject2.View
{
    public partial class MainForm : Form
    {
        private LetterBag letterBag;
        private Dictionary dictionary;
        private List<string> enteredWords;
        private List<(string word, DateTime time, int points)> validWords;
        private List<(string word, DateTime time, string reason)> invalidWords;
        private Timer gamerTimer;
        private int timeLeft;
        private List<HighScore> highScores;

        public MainForm()
        {
            InitializeComponent();
            letterBag = new LetterBag();
            dictionary = new Dictionary("C:\\Users\\periw\\source\\repos\\PerrinOwensProject2\\JSON File\\dictionary.json"); // Put the path to dictionary.json here
            enteredWords = new List<string>();
            validWords = new List<(string word, DateTime time, int points)>();
            invalidWords = new List<(string word, DateTime time, string reason)>();
            DisplayRandomLetters();
            InitializeTimer();
            highScores = new List<HighScore>();
            LoadHighScores();
            InitializeGame();
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
            if (enteredWords.Contains(enteredWord))
            {
                lblResult.Text = "Word already entered!";
                return;
            }

            if (IsValidWord(enteredWord))
            {
                enteredWords.Add(enteredWord);
                int points = CalculatePoints(enteredWord);
                validWords.Add((enteredWord, DateTime.Now, points));
                lblResult.Text = $"Valid word! Points: {points}";
            }
            else
            {
                string reason = GetInvalidReason(enteredWord);
                invalidWords.Add((enteredWord, DateTime.Now, reason));
                lblResult.Text = $"Invalid word! Reason: {reason}";
            }
        }

        private bool IsValidWord(string word)
        {
            if (word.Length < 3) return false;

            List<char> availableLetters = new List<char>(lblRandomLetters.Text.Replace(", ", "").ToCharArray());
            foreach (char letter in word)
            {
                if (!availableLetters.Contains(letter))
                {
                    return false;
                }

                availableLetters.Remove(letter);
            }

            return dictionary.IsValidWord(word);
        }

        private int CalculatePoints(string word)
        {
            switch (word.Length)
            {
                case 3: return 90;
                case 4: return 160;
                case 5: return 250;
                case 6: return 360;
                case 7: return 490;
                default: return 0;
            }
        }

        private string GetInvalidReason(string word)
        {
            if (word.Length < 3)
            {
                return "Too short";
            }

            if (!dictionary.IsValidWord(word))
            {
                return "Not in dictionary";
            }

            return "Invalid letters";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //...
        }

        private void InitializeTimer()
        {
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            timeLeft = 60;
            lblTimer.Text = "Time Left: " + timeLeft.ToString();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                lblTimer.Text = "Time Left: " + timeLeft.ToString();
            }
            else
            {
                gameTimer.Stop();
                MessageBox.Show("Time's up!");
                EndRound();
            }
        }


        private void SetTimer(int seconds)
        {
            timeLeft = seconds;
            lblTimer.Text = "Time Left: " + timeLeft.ToString();
        }

        private void oneMinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimer(60);
        }

        private void twoMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimer(120);
        }

        private void threeMinutesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetTimer(180);
        }

        private void btnTwistLetters_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var letters = lblRandomLetters.Text.Replace(", ", "").ToCharArray();
            letters = letters.OrderBy(c => random.Next()).ToArray();
            lblRandomLetters.Text = string.Join(", ", letters);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            SetTimer(60);
            gameTimer.Start();

            enteredWords.Clear();
            validWords.Clear();
            invalidWords.Clear();

            DisplayRandomLetters();

            txtWordEntry.Clear();
            lblResult.Text = string.Empty;
            lblTimer.Text = "Time Left: " + timeLeft.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExportStats_Click(object sender, EventArgs e)
        {
            if (validWords.Count == 0 && invalidWords.Count == 0)
            {
                MessageBox.Show("No stats to export.");
                return;
            }

            var exportData = new
            {
                ValidWords = validWords,
                InvalidWords = invalidWords
            };

            var json = JsonConvert.SerializeObject(exportData);
            File.WriteAllText("stats.json", json);
            MessageBox.Show("Stats exported.");
        }

        private void LoadHighScores()
        {
            if (File.Exists("highscores.json"))
            {
                var json = File.ReadAllText("highscores.json");
                highScores = JsonConvert.DeserializeObject<List<HighScore>>(json);
            }
            else
            {
                highScores = new List<HighScore>();
            }
        }

        private void RecordHighScore(string playerName, int score)
        {
            highScores.Add(new HighScore { Name = playerName, Score = score, Time = DateTime.Now });
            SaveHighScores();
        }


        private void SaveHighScores()
        {
            var json = JsonConvert.SerializeObject(highScores);
            File.WriteAllText("highscores.json", json);
        }

        private void ShowHighScores()
        {
            lvHighScores.Items.Clear();
            var sortedScores = highScores.OrderByDescending(h => h.Score).ThenBy(h => h.Time).ToList();

            foreach (var score in sortedScores)
            {
                var listItem = new ListViewItem(score.Name);
                listItem.SubItems.Add(score.Score.ToString());
                listItem.SubItems.Add(score.Time.ToString("g"));
                lvHighScores.Items.Add(listItem);
            }
        }

        private void ResetHighScores()
        {
            highScores.Clear();
            SaveHighScores();
            ShowHighScores();
        }

        private void btnShowHighScores_Click(object sender, EventArgs e)
        {
            ShowHighScores();
        }

        private void btnResetHighScores_Click(object sender, EventArgs e)
        {
            ResetHighScores();
        }

        private void lvHighScores_SelectedIndexChanged(object sender, EventArgs e)
        {
            //...
        }

        private void EndRound()
        {
            int totalScore = validWords.Sum(v => v.points);
            string playerName = PromptForPlayerName();

            RecordHighScore(playerName, totalScore);

            DisplayResults();
        }

        private string PromptForPlayerName()
        {
            string playerName = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "Player Name", "Player");
            return playerName;
        }

        private void DisplayResults()
        {
            MessageBox.Show("Round over! Check high scores to see your results.");
        }

        private void lvHighScores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //...
        }
    }
}
