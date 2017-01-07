using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartInterviewTestInC;

namespace ShoppingCartInterviewTestInCTests
{
    [TestClass()]
    public class CheckoutTests
    {
        Product _testProduct;
        Product _strawberry;
        Product _fruitTea;

        [TestInitialize]
        public void TestInitialize()
        {
            _testProduct = new Product
            {
                Name = "test",
                Price = 9.99m,
                ProductKey = "testKey",
                promotion = Promiotion.BuyOneGetOneFree
            };

            _strawberry = new Product
            {
                Name = "Strawberry",
                Price = 5m,
                ProductKey = "SR1",
                promotion = Promiotion.TenPercentOffIf3OrMore
            };
            _fruitTea = new Product
            {
                Name = "Fruit Tea",
                Price = 3.11m,
                ProductKey = "FR1",
                promotion = Promiotion.BuyOneGetOneFree
            };
        }

        [TestMethod]
        public void AddToCartNoExistingCartItemsTest()
        {
            var checkout = new Checkout();
            var cart = checkout.AddToCart(_testProduct);
            checkout.AddToCart(_testProduct);
            checkout.AddToCart(_testProduct);
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == _testProduct.ProductKey));
            Assert.IsTrue(cart.TotalCost == 19.98m);
        }

        [TestMethod]
        public void AddToCartWithExistingCartItemsTest()
        {

            var checkout = new Checkout();

            var cart = checkout.AddToCart(_testProduct);
            checkout.AddToCart(_testProduct);
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == _testProduct.ProductKey));
            Assert.IsTrue(cart.TotalCost == 9.99m);
        }

        [TestMethod]
        public void RemoveFromCartTest()
        {

            var product2 = new Product
            {
                Name = "test2",
                Price = 9.99m,
                ProductKey = "testKey2",
                promotion = Promiotion.BuyOneGetOneFree
            };

            var checkout = new Checkout();
            var cart = checkout.AddToCart(_testProduct);
            checkout.AddToCart(product2);
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == _testProduct.ProductKey));
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == product2.ProductKey));
            checkout.RemoveFromCart(cart.CartItems.Find(x => x.Product.ProductKey == product2.ProductKey));
            Assert.IsNull(cart.CartItems.Find(x => x.Product.ProductKey == product2.ProductKey));
        }

        [TestMethod]
        public void ViewCartTest()
        {
            var checkout = new Checkout();
            checkout.AddToCart(_testProduct);

            var cart = checkout.ViewCart();
            Assert.IsNotNull(cart.CartItems.Find(x => x.Product.ProductKey == _testProduct.ProductKey));
        }

        [TestMethod]
        public void BuyOneGetOneFreeAdd2Products()
        {
            var checkout = new Checkout();
            var cart = checkout.AddToCart(_testProduct);
            checkout.AddToCart(_testProduct);

            Assert.IsTrue(cart.TotalCost == 9.99m);
        }

        [TestMethod]
        public void BuyOneGetOneFreeAdd1Product()
        {
            var checkout = new Checkout();
            var cart = checkout.AddToCart(_testProduct);

            Assert.IsTrue(cart.TotalCost == 9.99m);
        }

        [TestMethod]
        public void TenPercentOffIf3OrMoreAdd3TheSame()
        {
            var checkout = new Checkout();
            var cart = checkout.AddToCart(_strawberry);
            checkout.AddToCart(_strawberry);
            checkout.AddToCart(_strawberry);
            checkout.AddToCart(_fruitTea);

            Assert.IsTrue(cart.TotalCost == 16.61m);
        }

        [TestMethod]
        public void TenPercentOffIf3OrMoreAddONlyTwo()
        {

            var checkout = new Checkout();
            var cart = checkout.AddToCart(_strawberry);
            checkout.AddToCart(_strawberry);
            checkout.AddToCart(_fruitTea);

            Assert.IsTrue(cart.TotalCost == 13.11m);
        }

        [TestMethod]
        public void NoPromotionTest()
        {

            var checkout = new Checkout();
            var cart = checkout.AddToCart(_strawberry);
            Assert.IsTrue(cart.TotalCost == 5m);
        }
    }
}