using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlashCardsLibrary
{
    public class DivisionNumberGenerator : NumberGenerator
    {

        public override void GenerateNumbers(FlashCardsController flashcard)
        {
            Random randomNumber =
                new Random(DateTime.Now.Millisecond);

            int temp;
            temp = randomNumber.Next(1, 9);
            flashcard.Number2 = randomNumber.Next(1, 9);
            flashcard.Number1 = temp * flashcard.Number2;
        }
    }
}
