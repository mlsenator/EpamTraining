using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IValueCalculator valueCalc;
        private readonly IDiscount discount;
        public IEnumerable<IProduct> Products { get; set; }

        public ShoppingCart(IValueCalculator valueCalc, IDiscount discount)
        {
            if (valueCalc == null || discount == null)
            {
                throw new ArgumentNullException("Null parametrs.");
            }
            this.valueCalc = valueCalc;
            this.discount = discount;
        }
        public decimal CalculateProductTotal()
        {
            return valueCalc.ValueProducts(Products, discount);
        }
    }
}
