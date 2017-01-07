using System;

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
                            return Quantiy%2 == 0
                                ? (Product.Price*Quantiy)/2
                                : ((Product.Price*(Quantiy - 1))/2) + Product.Price;
                        }
                        break;

                    case Promiotion.TenPercentOffIf3OrMore:
                        if (Quantiy >= 3)
                        {
                            return (Product.Price*Quantiy)*0.9m;
                        }
                        break;
                }
                return Product.Price*Quantiy;
            }
        }
    }
}