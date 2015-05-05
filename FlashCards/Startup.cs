using System;
using System.Collections.Generic;
using System.Text;

// Setting CLSCompliant attribute to false
[assembly: CLSCompliant(false)]

namespace FlashCards
{
    class Startup
    {
        public static void Main()
        {
            /*
            string input;
            double answer;

            Console.WriteLine("Welcome to Flashcards!");

            FlashCards game = new FlashCards();
            Console.WriteLine("What is your name?");

            game.User = Console.ReadLine();
            Console.WriteLine("Hello " + game.User);

            do{

               game.GenerateNumbers();

               Console.WriteLine
                   ("Do you want to (A)dd, (S)ubtract, (M)ultiply or (D)ivide?");

               try
               {
                   game.WorkOn = Console.ReadLine();
               }
               catch (Exception ex)
               {
                   game.WorkOn = "A";
               }

               Console.WriteLine(game.WorkOn);

               do
               {
                   Console.WriteLine(game.BuildEquation());
                   input = Console.ReadLine();
                   if (Double.TryParse(input, out answer) == false)
                   {
                       Console.WriteLine("Invalid input, try again.");
                   }
               } while (Double.TryParse(input, out answer) == false);

               if (game.CheckAnswer(answer))
               {
                   Console.WriteLine("Correct:)");
               }
               else
               {
                   Console.WriteLine("Sorry, wrong answer:(");
               }

               Console.WriteLine(
               String.Format("Your score is {0} out of {1} for {2}%",
               game.Correct, game.Tries, game.PercentCorrect)
               );

               Console.WriteLine("Do you want to play again (Y or N)?");
               input = Console.ReadLine();

            } while (!input.ToUpper().StartsWith("N"));

            Console.ReadLine();
            */

            // HACK BREAK CODE ON PURPOSE FOR DEMO!!
            
            // UGHE
            System.Windows.Forms.Application.Run(new FlashCardsForm());

            // TODO A nicer form would be good
        }
    }
}
