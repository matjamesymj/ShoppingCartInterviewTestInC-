using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartInterviewTestInC
{
    public class Product
    {

        public string ProductKey { get; set; }

        public string Name { get; set; }

        public  decimal Price { get; set; }

        public Promiotion promotion { get; set; }
      

    }
}
