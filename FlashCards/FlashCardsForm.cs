using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FlashCardsLibrary;

namespace FlashCards
{
    public partial class FlashCardsForm : Form
    {
        public FlashCardsForm()
        {
            this.InitializeComponent();
        }

        private FlashCardsController game = new FlashCardsController("Add");

        private void FlashCardsForm_Load(object sender, EventArgs e)
        {
            UserDialogForm userDialog = new UserDialogForm();
            userDialog.ShowDialog();
            this.game.User = userDialog.UserTextBox.Text;

            this.WelcomeLabel.Text = "Hello " + this.game.User;
//
//TODO BREAKINGG CODEEEE !!!! 
            QuestionLabel.Text = string.Empty; // ""

           game.ScoreChanged += new EventHandler(game_ScoreChanged);
        }

        void game_ScoreChanged(object sender, EventArgs e)
        {
            ScoreLabel.Text = String.Format("Score: {0}", game.Score);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (PlayButton.Text == "Play")
            {
                if (AddRadio.Checked)
                {
                    game.WorkOn = "ADD";
                }
                else if (SubtractRadio.Checked)
                {
                    game.WorkOn = "SUBTRACT";
                }
                else if (MultiplyRadio.Checked)
                {
                    game.WorkOn = "MULTIPLY";
                }
                else if (DivideRadio.Checked)
                {
                    game.WorkOn = "DIVIDE";
                }
                game.GenerateNumbers();
                QuestionLabel.Text = game.BuildEquation();
                PlayButton.Text = "Check Answer";
                AnswerTextBox.Text = string.Empty; // "";
                AnswerTextBox.Focus();
            }
            else
            {
                double answer;
                if (double.TryParse(this.AnswerTextBox.Text, out answer)
                    == true)
                {
                    if (game.CheckAnswer(answer) == true)
                    {
                        AnswerLabel.Text = 
                            string.Format("Correct!  Your score is {0} out of {1} for {2} percent.",
                            game.Correct, game.Tries, game.PercentCorrect);
                    }
                    else
                    {
                        AnswerLabel.Text = 
                            string.Format("Incorrect.  Your score is {0} out of {1} for {2} percent.",
                            game.Correct, game.Tries, game.PercentCorrect);
                    }
                    PlayButton.Text = "Play";
                }
                else
                {
                    AnswerTextBox.Focus();
                    AnswerTextBox.SelectAll();
                }
            }
        }
    }
}
