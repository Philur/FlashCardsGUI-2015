using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashCardsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlashCardsLibrary.Tests
{
    [TestClass()]
    public class FlashCardsControllerTests
    {
        [TestMethod()]
        public void FlashCardsControllerTest()
        {
            FlashCardsController test = new FlashCardsController("asb");

            test.WorkOn = "asb";

            Assert.AreEqual(test.WorkOn, "A");
        }
    }
}
