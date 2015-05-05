using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsLibrary
{
    public class FlashCardsController
    {

        private string mUser;
        private double mNumber1;
        private double mNumber2;
        private int mCorrect;
        private int mTries;
        private string mWorkOn;

        public FlashCardsController(string workOn)
        {
            this.WorkOn = workOn;
        }


        public event EventHandler ScoreChanged;

        private int mScore;
        public int Score
        {
            get
            {
                return mScore;
            }
            set
            {
                mScore = value;

                if (ScoreChanged != null)
                {
                    ScoreChanged(this, EventArgs.Empty);
                }
            }
        }

        public void GenerateNumbers()
        {
            NumberGenerator generator;

            switch (this.WorkOn)
            {
                case "M":
                    generator = new MultiplicationNumberGenerator();
                    break;
                case "D":
                    generator = new DivisionNumberGenerator();
                    break;
                default:
                    generator = new NumberGenerator();
                    break;
            }
            generator.GenerateNumbers(this);
        }

        public string BuildEquation()
        {

            switch (this.WorkOn)
            {
                case "A":
                    return mNumber1.ToString() + "+" + mNumber2.ToString();
                case "S":
                    return mNumber1.ToString() + "-" + mNumber2.ToString();
                case "M":
                    return mNumber1.ToString() + "*" + mNumber2.ToString();
                default:
                    return mNumber1.ToString() + "/" + mNumber2.ToString();

            }
        }

        public bool CheckAnswer(double answer)
        {
            double correctAnswer;

            if (this.WorkOn == "A")
            {
                correctAnswer = mNumber1 + mNumber2;
            }
            else if (this.WorkOn == "S")
            {
                correctAnswer = mNumber1 - mNumber2;
            }
            else if (this.WorkOn == "M")
            {
                correctAnswer = mNumber1 * mNumber2;
            }

            else
            {
                correctAnswer = mNumber1 / mNumber2;
            }

            mTries += 1;

            if (correctAnswer == answer)
            {
                mCorrect += 1;
                Score += 10;
                return true;
            }
            else
            {
                return false;
            }

        }

        public int Correct
        {
            get
            {
                return mCorrect;
            }
        }


        public int Tries
        {
            get
            {
                return mTries;
            }
        }

        public double PercentCorrect
        {
            get
            {
                return ((double)Correct / (double)Tries) * 100.0;
            }
        }

        public string WorkOn
        {
            get
            {
                return mWorkOn;
            }
            set
            {
                string input = value.ToUpper().Substring(0, 1);

                if (input == "A" || input == "S" ||
                    input == "M" || input == "D")
                    mWorkOn = input;
                else
                    throw new ArgumentException
                        ("Must enter Add, Subtract, Multiply or Divide");

            }
        }

        public string User
        {
            get
            {
                return mUser;
            }
            set
            {
                mUser = value;
            }
        }

        public double Number1
        {
            get
            {
                return mNumber1;
            }
            set
            {
                mNumber1 = value;
            }
        }

        public double Number2
        {
            get
            {
                return mNumber2;
            }
            set
            {
                mNumber2 = value;
            }
        }


    }
}
