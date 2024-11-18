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
            txtWordEntry = new TextBox();
            btnSubmitWord = new Button();
            lblResult = new Label();
            lblRandomLetters = new Label();
            SuspendLayout();
            // 
            // txtWordEntry
            // 
            txtWordEntry.Location = new Point(149, 192);
            txtWordEntry.Name = "txtWordEntry";
            txtWordEntry.Size = new Size(125, 27);
            txtWordEntry.TabIndex = 0;
            txtWordEntry.TextChanged += txtWordEntry_TextChanged;
            // 
            // btnSubmitWord
            // 
            btnSubmitWord.Location = new Point(164, 285);
            btnSubmitWord.Name = "btnSubmitWord";
            btnSubmitWord.Size = new Size(94, 29);
            btnSubmitWord.TabIndex = 1;
            btnSubmitWord.Text = "Submit";
            btnSubmitWord.UseVisualStyleBackColor = true;
            btnSubmitWord.Click += btnSubmitWord_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(185, 97);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(50, 20);
            lblResult.TabIndex = 2;
            lblResult.Text = "label1";
            lblResult.Click += lblResult_Click;
            // 
            // lblRandomLetters
            // 
            lblRandomLetters.AutoSize = true;
            lblRandomLetters.Location = new Point(185, 133);
            lblRandomLetters.Name = "lblRandomLetters";
            lblRandomLetters.Size = new Size(50, 20);
            lblRandomLetters.TabIndex = 3;
            lblRandomLetters.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 450);
            Controls.Add(lblRandomLetters);
            Controls.Add(lblResult);
            Controls.Add(btnSubmitWord);
            Controls.Add(txtWordEntry);
            Name = "MainForm";
            Text = "Text Twist by Owens";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtWordEntry;
        private Button btnSubmitWord;
        private Label lblResult;
        private Label lblRandomLetters;
    }
}