using System;

namespace Riba.Common.Helpers
{
    public class CalculatorHelper: ICalculatorHelper
    {
        /// <summary>
        /// Calculate discount based on price and quantity
        /// </summary>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public decimal CalculateDiscount(decimal price, int quantity)
        {
            if (quantity <= 10)
                return price * quantity;
            else if (quantity <= 20)
                return Convert.ToDecimal((double)price * quantity * 0.95);
            else if (quantity <= 30)
                return Convert.ToDecimal((double)price * quantity * 0.90);
            else return Convert.ToDecimal((double)price * (30 * 0.85 + (quantity - 30) * 0.80));
        }
    }
}
