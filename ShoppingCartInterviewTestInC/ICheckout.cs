using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartInterviewTestInC
{
    interface ICheckout
    {
        Cart AddToCart(Product product);
        Cart RemoveFromCart(CartItem cartItem);
        Cart ViewCart();

    }
}
