using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlashCardsLibrary
{
    public class NumberGenerator
    {
        public virtual void GenerateNumbers(FlashCardsController flashcard)
        {     
            Random randomNumber = new Random(DateTime.Now.Millisecond);

            flashcard.Number1 = randomNumber.Next(0, 99);
            flashcard.Number2 = randomNumber.Next(0, 99);
        }
    }
}
