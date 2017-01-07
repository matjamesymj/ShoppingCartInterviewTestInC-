using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartInterviewTestInC
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }

        public Product Product { get; set; }

        public int Quantiy { get; set; }

        public decimal TotalCost
        {
            get
            {

                switch (Product.promotion)
                {
                    case Promiotion.BuyOneGetOneFree:
                        if (Quantiy >= 2)
                        {
                            if (Quantiy%2 == 0)
                            {
                                return (Product.Price*Quantiy)/2;
                            }
                            else
                            {
                                return ((Product.Price*(Quantiy - 1))/2) + Product.Price;
                            }

                        }
                        else
                        {
                            return Product.Price*Quantiy;
                        }

                    case Promiotion.TenPercentOffIf3OrMore:
                        if (Quantiy >= 3)
                        {
                            return (Product.Price * Quantiy) *0.9m;
                        }
                        else
                        {
                            return Product.Price * Quantiy;
                        }
                       
                    case Promiotion.None:
                        return Product.Price*Quantiy;
                    default:
                        return Product.Price*Quantiy;
                }

            }
        }
    }
}
