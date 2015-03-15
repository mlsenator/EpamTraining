using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    public class NoDiscount : IDiscount
    {
        public double Discount { get { return 0; } }
    }

    public class Discount1 : IDiscount
    {
        public double Discount { get { return 0.01; } }
    }

    public class Discount5 : IDiscount
    {
        public double Discount { get { return 0.05; } }
    }

    public class Discount10 : IDiscount
    {
        public double Discount { get { return 0.1; } }
    }
}
