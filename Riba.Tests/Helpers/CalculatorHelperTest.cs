using NUnit.Framework;
using Riba.Common.Helpers;

namespace Riba.Tests.Controllers
{
    [TestFixture]
    public class CalculatorHelperTest
    {
        [Test]
        [TestCase(1,5,5)]
        [TestCase(1, 10, 10)]
        [TestCase(1, 11, 10.45)]
        [TestCase(1,15,14.25)]
        [TestCase(1, 20, 19)]
        [TestCase(1,25,22.5)]
        [TestCase(1, 30, 27)]
        [TestCase(1, 31, 26.3)]
        [TestCase(1,40,33.5)]
        public void Discount_Result_Should_Matches(decimal price, int quantity, decimal discountExpected)
        {
            var calculatorHelper = new CalculatorHelper();
            var discount = calculatorHelper.CalculateDiscount(price, quantity);

            Assert.AreEqual(discountExpected, discount);
        }
    }
}
