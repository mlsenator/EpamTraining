using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<IProduct> products, IDiscount discount);
    }
}
