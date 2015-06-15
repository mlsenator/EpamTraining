using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopModel;
using Ninject;
using System.Collections.Generic;

namespace ShopModelUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod()]
        public void FullValueNoDiscountTest()
        {
            IKernel kernel = new StandardKernel(new NinjectConfigModule());
            IShoppingCart shop = kernel.Get<ShoppingCart>();
            shop.Products = new List<Product>()
            {
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 100},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200}
            };
            var actual = shop.CalculateProductTotal();
            decimal expected = 300;
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        public void FullValueDiscount5Test()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<Discount5>();
            kernel.Bind<IValueCalculator>().To<FullValueCalculator>();
            IShoppingCart shop = kernel.Get<ShoppingCart>();
            shop.Products = new List<Product>()
            {
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 100},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C1", Description = "no", ProductID = 3, Price = 100},
                new Product {Name = "Product 4", Category = "C2", Description = "no", ProductID = 4, Price = 600}
            };
            var actual = shop.CalculateProductTotal();
            decimal expected = 950;
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        public void HalfValueDiscount10Test()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<Discount10>();
            kernel.Bind<IValueCalculator>().To<HalfValueCalculator>();
            IShoppingCart shop = kernel.Get<ShoppingCart>();
            shop.Products = new List<Product>()
            {
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 100},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C1", Description = "no", ProductID = 3, Price = 100},
                new Product {Name = "Product 4", Category = "C2", Description = "no", ProductID = 4, Price = 600}
            };
            var expected = shop.CalculateProductTotal();
            decimal actual = 450;
            Assert.AreEqual<decimal>(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ActivationException))]
        public void ActivationExceptionTest()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDiscount>().To<Discount10>();
            //kernel.Bind<IValueCalculator>().To<HalfValueCalculator>();
            IShoppingCart shop = kernel.Get<ShoppingCart>();
            shop.Products = new List<Product>()
            {
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 100},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C1", Description = "no", ProductID = 3, Price = 100},
                new Product {Name = "Product 4", Category = "C2", Description = "no", ProductID = 4, Price = 600}
            };
            var expected = shop.CalculateProductTotal();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullTest()
        {
            IShoppingCart shop = new ShoppingCart(null, null);
            shop.Products = new List<Product>()
            {
                new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 100},
                new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200},
                new Product {Name = "Product 3", Category = "C1", Description = "no", ProductID = 3, Price = 100},
                new Product {Name = "Product 4", Category = "C2", Description = "no", ProductID = 4, Price = 600}
            };
            var expected = shop.CalculateProductTotal();
        }
    }
}
