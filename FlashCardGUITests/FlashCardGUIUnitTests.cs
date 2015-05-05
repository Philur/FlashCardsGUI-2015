using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlashCardsLibrary;

namespace FlashCardGuiUnittests
{
    [TestClass]
    public class FlashCardGuiUnitTests
    {
        [TestMethod]
        public void SetPlayerName()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.User = "kalle";

            Assert.AreEqual(testOjbect.User, "kalle");
        }

        [TestMethod]
        public void SetPlayerNameFail()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.User = "kalle";

            // TODO this TC is to break the testOjbect chain
            // Assert.AreEqual(testOjbect.User, "kallde");
            // REFACTOR this TC so that it works better
            Assert.AreNotEqual(testOjbect.User, "kallde");
        }

        [TestMethod]
        public void SetPlayerNameLongname()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.User = "kalle anka från Göteborg i Sverige, Europa, Jorden";

            Assert.AreEqual(testOjbect.User, "kalle anka från Göteborg i Sverige, Europa, Jorden");
        }

        [TestMethod]
        public void SetPlayerNameShortname()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.User = "T";

            Assert.AreEqual(testOjbect.User, "T");
        }

        [TestMethod]
        public void SetPlayerNameWithFunnyCharacters()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.User = "kalle % # ; =} * á le´ ä ' ~";

            Assert.AreEqual(testOjbect.User, "kalle % # ; =} * á le´ ä ' ~");
        }

        [TestMethod]
        public void SetPlayerNameWithFunnyCharacters2()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.User = "john*^`?=)(/&%¤#!½_AppDomain:;*ÄÅÖ";

            Assert.AreEqual(testOjbect.User, "john*^`?=)(/&%¤#!½_AppDomain:;*ÄÅÖ");
        }

        [TestMethod]
        public void SetPlayerNameWithFunnyCharacters3()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.User = "'";

            Assert.AreEqual(testOjbect.User, "'");
        }

        [TestMethod]
        public void SetNumber1()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.Number1 = 1;

            Assert.AreEqual(testOjbect.Number1, 1);
        }

        [TestMethod]
        public void SetNumber2()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.Number2 = 1;

            // Assert.AreNotEqual(testOjbect.Number2, 1);
            Assert.AreEqual(testOjbect.Number2, 1);
        }

        [TestMethod]
        public void WorkOnLetterA()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            Assert.AreEqual(testOjbect.WorkOn, "A");

            testOjbect.WorkOn = "A";

            Assert.AreEqual(testOjbect.WorkOn, "A");
        }

        [TestMethod]
        public void WorkOnLetterS()
        {
            FlashCardsController testOjbect = new FlashCardsController("s");

            Assert.AreEqual(testOjbect.WorkOn, "S");

            testOjbect.WorkOn = "S";

            Assert.AreEqual(testOjbect.WorkOn, "S");
        }

        [TestMethod]
        public void WorkOnLetterM()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            Assert.AreEqual(testOjbect.WorkOn, "M");
            
            testOjbect.WorkOn = "M";

            Assert.AreEqual(testOjbect.WorkOn, "M");
        }

        [TestMethod]
        public void WorkOnLetterD()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            Assert.AreEqual(testOjbect.WorkOn, "D");

            testOjbect.WorkOn = "D";

            Assert.AreEqual(testOjbect.WorkOn, "D");
        }

        //!  TODO Fix UT for the exception. This still does not work because I (Erik) really do not understand it
        /*![TestMethod]
        public void WorkOnLetter_other()
        {
            FlashCardsController testOjbect = new FlashCardsController("x");

            UnittestOjbectAssertException.Equals(System.ArgumentException("Must enter Add, Subtract, Multiply or Divide")); 
            
            testOjbect.WorkOn = "X";

            UnittestOjbectAssertException.Equals(System.ArgumentException("Must enter Add, Subtract, Multiply or Divide"));
        }
         */

        // REFACTOR Understand how to do this!
        [TestMethod]
        public void SetNumber1Multiplication()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            Assert.AreEqual(testOjbect.WorkOn, "M");

            testOjbect.GenerateNumbers();

            Assert.IsTrue(testOjbect.Number1 < 13);
            Assert.IsTrue(testOjbect.Number1 > 0);

        }

        [TestMethod]
        public void SetNumber2Multiplication()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            Assert.AreEqual(testOjbect.WorkOn, "M");

            testOjbect.GenerateNumbers();

            Assert.IsTrue(testOjbect.Number2 < 13);
            Assert.IsTrue(testOjbect.Number2 > 0);
        }

        [TestMethod]
        public void SetNumber1Division()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            Assert.AreEqual(testOjbect.WorkOn, "D");

            testOjbect.GenerateNumbers();

            Assert.IsTrue(testOjbect.Number1 < 82);
            Assert.IsTrue(testOjbect.Number1 > 0);
        }

        [TestMethod]
        public void SetNumber2Division()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            Assert.AreEqual(testOjbect.WorkOn, "D");

            testOjbect.GenerateNumbers();

            Assert.IsTrue(testOjbect.Number2 < 10);
            Assert.IsTrue(testOjbect.Number2 > 0);
        }

        [TestMethod]
        public void GetAndSetTries()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            Assert.AreEqual(testOjbect.Tries, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(55);

            Assert.AreEqual(testOjbect.Tries, 1);
        }

        [TestMethod]
        public void GetAndSetCorrectAddition()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            Assert.AreEqual(testOjbect.Correct, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(55);

            Assert.AreEqual(testOjbect.Correct, 1);
        }

        [TestMethod]
        public void GetAndSetCorrectSubtraction()
        {
            FlashCardsController testOjbect = new FlashCardsController("s");

            Assert.AreEqual(testOjbect.Correct, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(45);

            Assert.AreEqual(testOjbect.Correct, 1);
        }

        [TestMethod]
        public void GetAndSetCorrectMultiplication()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            Assert.AreEqual(testOjbect.Correct, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(250);

            Assert.AreEqual(testOjbect.Correct, 1);
        }

        [TestMethod]
        public void GetAndSetCorrectDivision()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            Assert.AreEqual(testOjbect.Correct, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(10);

            Assert.AreEqual(testOjbect.Correct, 1);
        }

        [TestMethod]
        public void GetAndSetScoreAddition()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            Assert.AreEqual(testOjbect.Score, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(55);

            Assert.AreEqual(testOjbect.Score, 10);
        }

        [TestMethod]
        public void GetAndSetScoreSubtraction()
        {
            FlashCardsController testOjbect = new FlashCardsController("s");

            Assert.AreEqual(testOjbect.Score, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(45);

            Assert.AreEqual(testOjbect.Score, 10);
        }

        [TestMethod]
        public void GetAndSetScoreMultiplication()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            Assert.AreEqual(testOjbect.Score, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(250);

            Assert.AreEqual(testOjbect.Score, 10);
        }

        [TestMethod]
        public void GetAndSetScoreDivision()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            Assert.AreEqual(testOjbect.Score, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            testOjbect.CheckAnswer(10);

            Assert.AreEqual(testOjbect.Score, 10);
        }

        [TestMethod]
        public void GetAndSetCorrectFail()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            Assert.AreEqual(testOjbect.Correct, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 0;

            testOjbect.CheckAnswer(55);

            Assert.AreEqual(testOjbect.Correct, 0);
        }

        [TestMethod]
        public void GetAndSetScoreFail()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            Assert.AreEqual(testOjbect.Score, 0);

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 0;

            testOjbect.CheckAnswer(55);
            
            Assert.AreEqual(testOjbect.Score, 0);
        }

        [TestMethod]
        public void CheckAnswerTrueDivision()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.IsTrue(testOjbect.CheckAnswer(10));
        }

        [TestMethod]
        public void CheckAnswerTrueAddition()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.IsTrue(testOjbect.CheckAnswer(55));
        }

        [TestMethod]
        public void CheckAnswerTrueSubtraction()
        {
            FlashCardsController testOjbect = new FlashCardsController("s");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.IsTrue(testOjbect.CheckAnswer(45));
        }

        [TestMethod]
        public void CheckAnswerTrueMultiplication()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.IsTrue(testOjbect.CheckAnswer(250));
        }

        [TestMethod]
        public void CheckAnswerFalseAddition()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 0;

            Assert.IsFalse(testOjbect.CheckAnswer(55));
        }

        [TestMethod]
        public void CheckAnswerFalseSubtraction()
        {
            FlashCardsController testOjbect = new FlashCardsController("s");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 0;

            Assert.IsFalse(testOjbect.CheckAnswer(45));
        }

        [TestMethod]
        public void CheckAnswerFalseMultiplication()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 4;

            Assert.IsFalse(testOjbect.CheckAnswer(250));
        }

        [TestMethod]
        public void CheckAnswerFalseDivision()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.IsFalse(testOjbect.CheckAnswer(11));
        }

        [TestMethod]
        public void BuildEquationAddition()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.AreEqual(testOjbect.BuildEquation(), "50+5");      
        }
        [TestMethod]
        public void BuildEquationSubtraction()
        {
            FlashCardsController testOjbect = new FlashCardsController("s");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.AreEqual(testOjbect.BuildEquation(), "50-5");
        }

        [TestMethod]
        public void BuildEquationMultiplication()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.AreEqual(testOjbect.BuildEquation(), "50*5");
        }

        [TestMethod]
        public void BuildEquationDivision()
        {
            FlashCardsController testOjbect = new FlashCardsController("d");

            testOjbect.Number1 = 50;
            testOjbect.Number2 = 5;

            Assert.AreEqual(testOjbect.BuildEquation(), "50/5");
        }

        // HACK this is a quite ugly test
        [TestMethod]
        public void TestNumberGenerator()
        {
            FlashCardsController testOjbect = new FlashCardsController("a");

            testOjbect.Number1 = 0;
            testOjbect.Number2 = 0;

            Assert.AreEqual(testOjbect.Number1, 0);
            Assert.AreEqual(testOjbect.Number2, 0);

            NumberGenerator testNum = new NumberGenerator();

            testNum.GenerateNumbers(testOjbect);

            Assert.AreNotEqual(testOjbect.Number1, 0);
            Assert.AreNotEqual(testOjbect.Number2, 0);
            Assert.IsTrue(testOjbect.Number1 < 100);
            Assert.IsTrue(testOjbect.Number2 < 100);
            Assert.IsTrue(testOjbect.Number1 > 0);
            Assert.IsTrue(testOjbect.Number2 > 0);
        }

        // TODO this is a quite ugly test
        [TestMethod]
        public void TestGenerateNumbersSwitchA()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            testOjbect.Number1 = 0;
            testOjbect.Number2 = 0;
            testOjbect.WorkOn = "A";

            Assert.AreEqual(testOjbect.Number1, 0);
            Assert.AreEqual(testOjbect.Number2, 0);
            Assert.AreEqual(testOjbect.WorkOn, "A");

            NumberGenerator testNum = new NumberGenerator();

            testNum.GenerateNumbers(testOjbect);

            Assert.IsTrue(testOjbect.Number1 > 0);
            Assert.IsTrue(testOjbect.Number2 > 0);
        }

        // TODO this is a quite ugly test
        [TestMethod]
        public void TestGenerateNumbersSwitchS()
        {
            FlashCardsController testOjbect = new FlashCardsController("m");

            testOjbect.Number1 = 0;
            testOjbect.Number2 = 0;
            testOjbect.WorkOn = "S";

            Assert.AreEqual(testOjbect.Number1, 0);
            Assert.AreEqual(testOjbect.Number2, 0);
            Assert.AreEqual(testOjbect.WorkOn, "S");

            NumberGenerator testNum = new NumberGenerator();

            testNum.GenerateNumbers(testOjbect);

            Assert.IsTrue(testOjbect.Number1 > 0);
            Assert.IsTrue(testOjbect.Number2 > 0);
        }
    }
}
