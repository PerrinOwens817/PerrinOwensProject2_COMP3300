namespace PerrinOwensProject2.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtWordEntry = new TextBox();
            btnSubmitWord = new Button();
            lblResult = new Label();
            lblRandomLetters = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            lblTimer = new Label();
            menuStrip1 = new MenuStrip();
            setTimerToolStripMenuItem = new ToolStripMenuItem();
            oneMinuteToolStripMenuItem = new ToolStripMenuItem();
            twoMinutesToolStripMenuItem = new ToolStripMenuItem();
            threeMinutesToolStripMenuItem1 = new ToolStripMenuItem();
            btnTwistLetters = new Button();
            btnNewGame = new Button();
            btnExit = new Button();
            btnExportStats = new Button();
            btnShowHighScores = new Button();
            btnResetHighScores = new Button();
            lvHighScores = new ListView();
            colName = new ColumnHeader();
            colScore = new ColumnHeader();
            colTime = new ColumnHeader();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtWordEntry
            // 
            txtWordEntry.Location = new Point(376, 339);
            txtWordEntry.Name = "txtWordEntry";
            txtWordEntry.Size = new Size(250, 27);
            txtWordEntry.TabIndex = 0;
            txtWordEntry.TextChanged += txtWordEntry_TextChanged;
            // 
            // btnSubmitWord
            // 
            btnSubmitWord.Location = new Point(431, 372);
            btnSubmitWord.Name = "btnSubmitWord";
            btnSubmitWord.Size = new Size(151, 29);
            btnSubmitWord.TabIndex = 1;
            btnSubmitWord.Text = "Submit";
            btnSubmitWord.UseVisualStyleBackColor = true;
            btnSubmitWord.Click += btnSubmitWord_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(376, 261);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(50, 20);
            lblResult.TabIndex = 2;
            lblResult.Text = "label1";
            lblResult.Click += lblResult_Click;
            // 
            // lblRandomLetters
            // 
            lblRandomLetters.AutoSize = true;
            lblRandomLetters.Location = new Point(455, 298);
            lblRandomLetters.Name = "lblRandomLetters";
            lblRandomLetters.Size = new Size(50, 20);
            lblRandomLetters.TabIndex = 3;
            lblRandomLetters.Text = "label1";
            // 
            // gameTimer
            // 
            gameTimer.Tick += gameTimer_Tick;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(941, 28);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(50, 20);
            lblTimer.TabIndex = 4;
            lblTimer.Text = "label1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { setTimerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1149, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // setTimerToolStripMenuItem
            // 
            setTimerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { oneMinuteToolStripMenuItem, twoMinutesToolStripMenuItem, threeMinutesToolStripMenuItem1 });
            setTimerToolStripMenuItem.Name = "setTimerToolStripMenuItem";
            setTimerToolStripMenuItem.Size = new Size(86, 24);
            setTimerToolStripMenuItem.Text = "Set Timer";
            // 
            // oneMinuteToolStripMenuItem
            // 
            oneMinuteToolStripMenuItem.Name = "oneMinuteToolStripMenuItem";
            oneMinuteToolStripMenuItem.Size = new Size(156, 26);
            oneMinuteToolStripMenuItem.Text = "1 minute";
            oneMinuteToolStripMenuItem.Click += oneMinuteToolStripMenuItem_Click;
            // 
            // twoMinutesToolStripMenuItem
            // 
            twoMinutesToolStripMenuItem.Name = "twoMinutesToolStripMenuItem";
            twoMinutesToolStripMenuItem.Size = new Size(156, 26);
            twoMinutesToolStripMenuItem.Text = "2 minutes";
            twoMinutesToolStripMenuItem.Click += twoMinutesToolStripMenuItem_Click;
            // 
            // threeMinutesToolStripMenuItem1
            // 
            threeMinutesToolStripMenuItem1.Name = "threeMinutesToolStripMenuItem1";
            threeMinutesToolStripMenuItem1.Size = new Size(156, 26);
            threeMinutesToolStripMenuItem1.Text = "3 minutes";
            threeMinutesToolStripMenuItem1.Click += threeMinutesToolStripMenuItem1_Click;
            // 
            // btnTwistLetters
            // 
            btnTwistLetters.Location = new Point(431, 407);
            btnTwistLetters.Name = "btnTwistLetters";
            btnTwistLetters.Size = new Size(151, 29);
            btnTwistLetters.TabIndex = 6;
            btnTwistLetters.Text = "Twist Letters";
            btnTwistLetters.UseVisualStyleBackColor = true;
            btnTwistLetters.Click += btnTwistLetters_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(431, 442);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(151, 29);
            btnNewGame.TabIndex = 7;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(431, 477);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(151, 29);
            btnExit.TabIndex = 8;
            btnExit.Text = "Exit Game";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnExportStats
            // 
            btnExportStats.Location = new Point(431, 582);
            btnExportStats.Name = "btnExportStats";
            btnExportStats.Size = new Size(151, 29);
            btnExportStats.TabIndex = 9;
            btnExportStats.Text = "Export Stats";
            btnExportStats.UseVisualStyleBackColor = true;
            btnExportStats.Click += btnExportStats_Click;
            // 
            // btnShowHighScores
            // 
            btnShowHighScores.Location = new Point(431, 512);
            btnShowHighScores.Name = "btnShowHighScores";
            btnShowHighScores.Size = new Size(151, 29);
            btnShowHighScores.TabIndex = 11;
            btnShowHighScores.Text = "Show High Scores";
            btnShowHighScores.UseVisualStyleBackColor = true;
            btnShowHighScores.Click += btnShowHighScores_Click;
            // 
            // btnResetHighScores
            // 
            btnResetHighScores.Location = new Point(431, 547);
            btnResetHighScores.Name = "btnResetHighScores";
            btnResetHighScores.Size = new Size(151, 29);
            btnResetHighScores.TabIndex = 12;
            btnResetHighScores.Text = "Reset High Scores";
            btnResetHighScores.UseVisualStyleBackColor = true;
            btnResetHighScores.Click += btnResetHighScores_Click;
            // 
            // lvHighScores
            // 
            lvHighScores.Columns.AddRange(new ColumnHeader[] { colName, colScore, colTime });
            lvHighScores.Location = new Point(256, 59);
            lvHighScores.Name = "lvHighScores";
            lvHighScores.Size = new Size(631, 177);
            lvHighScores.TabIndex = 13;
            lvHighScores.UseCompatibleStateImageBehavior = false;
            lvHighScores.View = System.Windows.Forms.View.Details;
            lvHighScores.SelectedIndexChanged += lvHighScores_SelectedIndexChanged_1;
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 200;
            // 
            // colScore
            // 
            colScore.Text = "Score";
            colScore.TextAlign = HorizontalAlignment.Center;
            colScore.Width = 200;
            // 
            // colTime
            // 
            colTime.Text = "Time";
            colTime.TextAlign = HorizontalAlignment.Center;
            colTime.Width = 200;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 623);
            Controls.Add(lvHighScores);
            Controls.Add(btnResetHighScores);
            Controls.Add(btnShowHighScores);
            Controls.Add(btnExportStats);
            Controls.Add(btnExit);
            Controls.Add(btnNewGame);
            Controls.Add(btnTwistLetters);
            Controls.Add(lblTimer);
            Controls.Add(lblRandomLetters);
            Controls.Add(lblResult);
            Controls.Add(btnSubmitWord);
            Controls.Add(txtWordEntry);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Text Twist by Owens";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtWordEntry;
        private Button btnSubmitWord;
        private Label lblResult;
        private Label lblRandomLetters;
        private System.Windows.Forms.Timer gameTimer;
        private Label lblTimer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem setTimerToolStripMenuItem;
        private ToolStripMenuItem oneMinuteToolStripMenuItem;
        private ToolStripMenuItem twoMinutesToolStripMenuItem;
        private ToolStripMenuItem threeMinutesToolStripMenuItem1;
        private Button btnTwistLetters;
        private Button btnNewGame;
        private Button btnExit;
        private Button btnExportStats;
        private Button btnShowHighScores;
        private Button btnResetHighScores;
        private ListView lvHighScores;
        private ColumnHeader colName;
        private ColumnHeader colScore;
        private ColumnHeader colTime;
    }
}