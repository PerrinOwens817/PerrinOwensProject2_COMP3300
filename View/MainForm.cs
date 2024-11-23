using Newtonsoft.Json;
using PerrinOwensProject2.Models;
using Timer = System.Windows.Forms.Timer;

// I hope you will see this teacher... please not the highscore and stat files are in the bin folder.

namespace PerrinOwensProject2.View
{
    /// <summary>
    /// The main form for the Text Twist game.
    /// </summary>
    public partial class MainForm : Form
    {
        private LetterBag letterBag;
        private Dictionary dictionary;
        private List<string> enteredWords;
        private List<(string word, DateTime time, int points)> validWords;
        private List<(string word, DateTime time, string reason)> invalidWords;
        private int timeLeft;
        private List<HighScore> highScores;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            letterBag = new LetterBag();
            dictionary = new Dictionary("C:\\Users\\periw\\source\\repos\\PerrinOwensProject2\\JSON File\\dictionary.json"); // Put the path to dictionary.json here
            enteredWords = new List<string>();
            validWords = new List<(string word, DateTime time, int points)>();
            invalidWords = new List<(string word, DateTime time, string reason)>();
            gameTimer = new Timer();
            DisplayRandomLetters();
            InitializeTimer();
            highScores = new List<HighScore>();
            LoadHighScores();
            InitializeGame();
        }
        
        /// <summary>
        /// Displays seven random letters on the form.
        /// </summary>
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

        /// <summary>
        /// Handles the clock event for submitting a word.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Checks ifthe entered word is valid.
        /// </summary>
        /// <param name="word">The word to check.</param>
        /// <returns>True, if the word is valid; otherwise, false.</returns>
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


        /// <summary>
        /// Calculates the points for the entered word.
        /// </summary>
        /// <param name="word">The word to calculate points for.</param>
        /// <returns>The points for the word.</returns>
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

        /// <summary>
        /// Gets the reason why a word is invalid.
        /// </summary>
        /// <param name="word">The invalid word.</param>
        /// <returns>The reason why the word is invalid.</returns>
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

        /// <summary>
        /// Initializes the game timer.
        /// </summary>
        private void InitializeTimer()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            timeLeft = 60;
            lblTimer.Text = "Time Left: " + timeLeft.ToString();
        }

        /// <summary>
        /// Handles the game timer tick event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void gameTimer_Tick(object? sender, EventArgs e)
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

        /// <summary>
        /// Sets the game timer to the specified number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds.</param>
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

        /// <summary>
        /// Handles the twist letters button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnTwistLetters_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var letters = lblRandomLetters.Text.Replace(", ", "").ToCharArray();
            letters = letters.OrderBy(c => random.Next()).ToArray();
            lblRandomLetters.Text = string.Join(", ", letters);
        }

        /// <summary>
        /// Handles the new game button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        /// <summary>
        /// Initializes a new game by resetting all relevant data.
        /// </summary>
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

        /// <summary>
        /// Handles the click event for exiting the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the click event for exporting the game stats.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Loads the high scores from a file.
        /// </summary>
        private void LoadHighScores()
        {
            if (File.Exists("highscores.json"))
            {
                var json = File.ReadAllText("highscores.json");
                highScores = JsonConvert.DeserializeObject<List<HighScore>>(json) ?? new List<HighScore>();
            }
            else
            {
                highScores = new List<HighScore>();
            }
        }

        /// <summary>
        /// Records a high score
        /// </summary>
        /// <param name="playerName">The player's name</param>
        /// <param name="score">The score achieved by the player.</param>
        private void RecordHighScore(string playerName, int score)
        {
            highScores.Add(new HighScore { Name = playerName, Score = score, Time = DateTime.Now });
            SaveHighScores();
        }

        /// <summary>
        /// Saves the high scores to a file.
        /// </summary>
        private void SaveHighScores()
        {
            var json = JsonConvert.SerializeObject(highScores);
            File.WriteAllText("highscores.json", json);
        }

        /// <summary>
        /// Clears the high scores list view and displays high scores sorted by score and time.
        /// </summary>
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

        /// <summary>
        /// Clears the high scores and updates the high scores list view.
        /// </summary>
        private void ResetHighScores()
        {
            highScores.Clear();
            SaveHighScores();
            ShowHighScores();
        }

        /// <summary>
        /// Handles displaying high scores when the button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnShowHighScores_Click(object sender, EventArgs e)
        {
            ShowHighScores();
        }

        /// <summary>
        /// Handles resetting high scores when the button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnResetHighScores_Click(object sender, EventArgs e)
        {
            ResetHighScores();
        }

        /// <summary>
        /// Ends the current round, prompts the player fo their name, records the high score, and then displays the results.
        /// </summary>
        private void EndRound()
        {
            int totalScore = validWords.Sum(v => v.points);
            string playerName = PromptForPlayerName();

            RecordHighScore(playerName, totalScore);

            DisplayResults();
        }

        /// <summary>
        /// Prompts the player for their name.
        /// </summary>
        /// <returns>The player's name.</returns>
        private string PromptForPlayerName()
        {
            string playerName = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "Player Name", "Player");
            return playerName;
        }

        /// <summary>
        /// Displays a message box indicating the round is over.
        /// </summary>
        private void DisplayResults()
        {
            MessageBox.Show("Round over! Check high scores to see your results.");
        }

        private void lvHighScores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //...
        }

        /// <summary>
        /// Loads the previous game session from a JSON file and initializes the game state.
        /// </summary>
        private void LoadPreviousSession()
        {
            try
            {
                var json = File.ReadAllText("stats.json");
                var previousSessionData = JsonConvert.DeserializeObject<PreviousSessionData>(json);
                validWords = previousSessionData?.ValidWords ?? new List<(string word, DateTime time, int points)>();
                invalidWords = previousSessionData?.InvalidWords ?? new List<(string word, DateTime time, string reason)>();
                SetTimer(previousSessionData?.Timer ?? 60);
                gameTimer.Start(); // Start the timer after loading
                MessageBox.Show("Previous session loaded successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while loading the previous session. Starting a new game.");
                InitializeGame();
            }
        }

        /// <summary>
        /// Handles loading the previous session when the button is clicked.
        /// </summary>
        /// <param name="sender">The source of the data.</param>
        /// <param name="e">The event data.</param>
        private void btnLoadPreviousSession_Click(object sender, EventArgs e)
        {
            LoadPreviousSession();
        }
    }
}
