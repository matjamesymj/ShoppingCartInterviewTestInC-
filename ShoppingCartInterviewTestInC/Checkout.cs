using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartInterviewTestInC
{
     public class Checkout : ICheckout
    {
         Cart Cart { get; set; }
        public Checkout()
        {
            Cart = new Cart();
        }
       
        public Cart AddToCart(Product product)
        {
            var cartItem = Cart.CartItems.Find(x => x.Product.ProductKey == product.ProductKey);

            if (cartItem == null)
            {
                cartItem = new CartItem {Product = product,Quantiy = 1};
                Cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantiy += 1;
                
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
    }
}
