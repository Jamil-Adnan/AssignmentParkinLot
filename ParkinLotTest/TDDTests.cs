using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.Net.WebSockets;

namespace ParkinLotTest
{
    [TestClass]
    public class TDDTests
    {
        [TestMethod]
        public void CalculateAmountWithFine()
        {
            double expected = 530;
            var result = ParkinLot.TDD.CalculateTotalAmount(20, 30);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateAmountWithoutFine()
        {
            double expected = 0;
            var result = ParkinLot.TDD.CalculateTotalAmount(20, 10);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateAmountWithNegativeInput()
        {
            double expected = 0;
            var result = ParkinLot.TDD.CalculateTotalAmount(-20, -10);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        
        public void CalculateAmountWithLargeExceededTime()
        { 
           double expected = 650;
           var result = ParkinLot.TDD.CalculateTotalAmount(100, 510);
           Assert.AreEqual(expected, result);
        }
    }
}
