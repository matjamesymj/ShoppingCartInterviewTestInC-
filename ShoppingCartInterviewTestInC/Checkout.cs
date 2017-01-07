namespace ShoppingCartInterviewTestInC
{
    public class Checkout : ICheckout
    {
        public Checkout()
        {
            Cart = new Cart();
        }

        private Cart Cart { get; }

        public Cart AddToCart(Product product)
        {
            if (ProductExistInCart(product))
            {
                return AddOneToQuantity(product);
            }
            Cart.CartItems.Add(ProductNotInCart(product));
            return Cart;
        }

        public Cart RemoveFromCart(CartItem cartItem)
        {
            Cart.CartItems.Remove(cartItem);
            return Cart;
        }

        public Cart ViewCart()
        {
            return Cart;
        }

        private bool ProductExistInCart(Product product)
        {
            return Cart.CartItems.Exists(x => x.Product.ProductKey == product.ProductKey);
        }

        private Cart AddOneToQuantity(Product product)
        {
            var cartItem = Cart.CartItems.Find(x => x.Product.ProductKey == product.ProductKey);
            cartItem.Quantiy += 1;
            return Cart;
        }

        private static CartItem ProductNotInCart(Product product)
        {
            return new CartItem {Product = product, Quantiy = 1};
        }
    }
}