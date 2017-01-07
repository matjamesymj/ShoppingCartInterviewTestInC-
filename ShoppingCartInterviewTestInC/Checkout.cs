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
            var cartItem = Cart.CartItems.Find(x => x.Product.ProductKey == product.ProductKey);

            if (cartItem == null)
            {
                Cart.CartItems.Add(ProductNotInCart(product));
            }
            else
            {
                AddOneToQuantity(cartItem);
            }

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

        private static void AddOneToQuantity(CartItem cartItem)
        {
            cartItem.Quantiy += 1;
        }

        private static CartItem ProductNotInCart(Product product)
        {
            return new CartItem {Product = product, Quantiy = 1};
        }
    }
}