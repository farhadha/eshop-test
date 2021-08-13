using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Mock : object
    {
        private static System.Collections.Generic.IList<Models.Product> products;

        public static System.Collections.Generic.IList<Models.Product> Products
        {
            get
            {
                if (products is null)
                {
                    products = new System.Collections.Generic.List<Models.Product>();

                    var flag = false;

                    for (int index = 1; index <= 10; index++)
                    {
                        Models.Product product = new Models.Product
                        {
                            Id = index,
                            Name = $"Product {index}",
                            Category =  flag ? "Cat 1" : "Cat 2",
                            Price = index * 1000
                        };
                        flag = !flag;
                        products.Add(product);
                    }
                }

                return products;
            }
        }
    }
}
