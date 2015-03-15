using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    public class FullValueCalculator : IValueCalculator
    {
        public decimal ValueProducts(IEnumerable<IProduct> products, IDiscount discount)
        {
            if (products == null || discount == null)
            {
                throw new ArgumentNullException();
            }
            decimal sumOfProduct = 0;
            foreach (var product in products)
            {
                sumOfProduct += product.Price;
            }
            return sumOfProduct - Decimal.Multiply(sumOfProduct, (decimal)discount.Discount);
        }
    }

    public class HalfValueCalculator : IValueCalculator
    {
        public decimal ValueProducts(IEnumerable<IProduct> products, IDiscount discount)
        {
            if (products == null || discount == null)
            {
                throw new ArgumentNullException();
            }
            decimal sumOfProduct = 0;
            foreach (var product in products)
            {
                sumOfProduct += product.Price / 2;
            }
            return sumOfProduct - Decimal.Multiply(sumOfProduct, (decimal)discount.Discount);
        }
    }
}
