using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlashCardsLibrary
{
    public class MultiplicationNumberGenerator : NumberGenerator
    {

        public override void GenerateNumbers(FlashCardsController flashcard)
        {
            Random randomNumber =
                new Random(DateTime.Now.Millisecond);

            flashcard.Number1 = randomNumber.Next(1, 12);
            flashcard.Number2 = randomNumber.Next(1, 12);
        }
    }
}
