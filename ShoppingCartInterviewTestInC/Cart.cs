using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartInterviewTestInC
{
    public class Cart
    {
        public Cart()
        {
            CartItems= new List<CartItem>();
        }
        
        public Guid CartId { get; set; }

        public List<CartItem> CartItems { get; set; }

        public decimal TotalCost
        {
            get { return CartItems.Sum(getSum => getSum.TotalCost); }
        }

    }
}
