using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartInterviewTestInC;

namespace ShoppingCartInterviewTestInCTests
{
    [TestClass()]
    public class CheckoutTests
    {
       
        [TestMethod()]
        public void AddToCartNoExistingCartItemsTest()
        {
            
            var product = new Product {Name = "test",Price = 9.99m,ProductKey = "testKey",promotion = Promiotion.BuyOneGetOneFree};

            var checkout = new Checkout();
            var cart = checkout.AddToCart(product);
            checkout.AddToCart(product);
            checkout.AddToCart(product);
            Assert.IsNotNull(cart.CartItems.Find(x=>x.Product.ProductKey==product.ProductKey));
            Assert.IsTrue(cart.TotalCost==19.98m);
            

        }
        [TestMethod()]
        public void AddToCartWithExistingCartItemsTest()
        {

            var product = new Product { Name = "test", Price = 9.99m, ProductKey = "testKey", promotion = Promiotion.BuyOneGetOneFree };

            var checkout = new Checkout();
            
            var cart = checkout.AddToCart(product);
           checkout.AddToCart(product);
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == product.ProductKey));
            Assert.IsTrue(cart.TotalCost==9.99m);


        }

        [TestMethod()]
        public void RemoveFromCartTest()
        {
            var product1 = new Product { Name = "test1", Price = 9.99m, ProductKey = "testKey1", promotion = Promiotion.BuyOneGetOneFree };
            var product2 = new Product { Name = "test2", Price = 9.99m, ProductKey = "testKey2", promotion = Promiotion.BuyOneGetOneFree };

            var checkout = new Checkout();
            var cart = checkout.AddToCart(product1);
            checkout.AddToCart(product2);
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == product1.ProductKey));
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == product2.ProductKey));
            checkout.RemoveFromCart(cart.CartItems.Find(x => x.Product.ProductKey == product2.ProductKey));
            Assert.IsNull(cart.CartItems.Find(x => x.Product.ProductKey == product2.ProductKey));
            
        }

        [TestMethod()]
        public void ViewCartTest()
        {
            var product = new Product { Name = "test", Price = 9.99m, ProductKey = "testKey", promotion = Promiotion.BuyOneGetOneFree };

            var checkout = new Checkout();
           checkout.AddToCart(product);

            Cart cart = checkout.ViewCart();
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == product.ProductKey));
        }

        [TestMethod]
        public void BuyOneGetOneFreeAdd2Products()
        {
            var product1 = new Product { Name = "test1", Price = 9.99m, ProductKey = "testKey1", promotion = Promiotion.BuyOneGetOneFree };
            var checkout = new Checkout();
            var cart = checkout.AddToCart(product1);
            checkout.AddToCart(product1);

            Assert.IsTrue(cart.TotalCost == 9.99m);

        }
        [TestMethod]
        public void BuyOneGetOneFreeAdd1Product()
        {
            var product1 = new Product { Name = "test1", Price = 9.99m, ProductKey = "testKey1", promotion = Promiotion.BuyOneGetOneFree };

            var checkout = new Checkout();
            var cart = checkout.AddToCart(product1);

            Assert.IsTrue(cart.TotalCost == 9.99m);

        }
        [TestMethod]
        public void TenPercentOffIf3OrMoreAdd3TheSame()
        {
            var strawberry = new Product { Name = "Strawberry", Price = 5m, ProductKey = "SR1", promotion = Promiotion.TenPercentOffIf3OrMore };
            var fruitTea = new Product { Name = "Fruit Tea", Price = 3.11m, ProductKey = "FR1", promotion = Promiotion.BuyOneGetOneFree };

            var checkout = new Checkout();
            var cart = checkout.AddToCart(strawberry);
            checkout.AddToCart(strawberry);
            checkout.AddToCart(strawberry);
            checkout.AddToCart(fruitTea);

            Assert.IsTrue(cart.TotalCost == 16.61m);

        }
        [TestMethod]
        public void TenPercentOffIf3OrMoreAddONlyTwo()
        {
            var strawberry = new Product { Name = "Strawberry", Price = 5m, ProductKey = "SR1", promotion = Promiotion.TenPercentOffIf3OrMore };
            var fruitTea = new Product { Name = "Fruit Tea", Price = 3.11m, ProductKey = "FR1", promotion = Promiotion.BuyOneGetOneFree };

            var checkout = new Checkout();
            var cart = checkout.AddToCart(strawberry);
            checkout.AddToCart(strawberry);
            checkout.AddToCart(fruitTea);

            Assert.IsTrue(cart.TotalCost == 13.11m);

        }
        [TestMethod]
        public void NOPromotionTest()
        {
            var strawberry = new Product { Name = "Strawberry", Price = 5m, ProductKey = "SR1", promotion = Promiotion.None };
            var checkout = new Checkout();
            var cart = checkout.AddToCart(strawberry);
            Assert.IsTrue(cart.TotalCost == 5m);

        }
    }
}