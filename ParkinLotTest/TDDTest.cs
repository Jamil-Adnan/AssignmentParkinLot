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
        
        
    }
}

