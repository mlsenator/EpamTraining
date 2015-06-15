using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace ShopModel
{
    public class NinjectConfigModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDiscount>().To<NoDiscount>();
            this.Bind<IValueCalculator>().To<FullValueCalculator>();
        }
    }
}
