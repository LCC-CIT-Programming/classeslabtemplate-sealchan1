using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class ProductList
    {
        private List<Product> products;

        public ProductList()
        {
            products = new List<Product>();
        }

        public int Count
        {
            get
            {
                return products.Count;
            }
        }

        public void Fill()
        {
            products = ProductDB.GetProducts();
        }

        public void Save()
        {
            ProductDB.SaveProducts(products);
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        /*
        public void Add(int id, string code, string description, decimal price, int quantity)
        {
            Product p = new Product(id, code, description, price, quantity);
            products.Add(p);
        }
        //*/

        public void Remove(Product product)
        {
            products.Remove(product);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Product p in products)
            {
                output += p.ToString() + "\n";
            }
            return output;
        }

        public Product this[int i]
        {
            get
            {
                return products[i];
            }
            set
            {
                products[i] = value;
            }
        }

        public Product this[string code]
        {
            get
            {
                foreach (Product p in products)
                {
                    if (p.Code == code)
                        return p;
                }
                return null;
            }
        }

        public static ProductList operator +(ProductList pl, Product p)
        {
            pl.Add(p);
            return pl;
        }

        public static ProductList operator +(Product p, ProductList pl)
        {
            pl.Add(p);
            return pl;
        }

        public static ProductList operator -(ProductList pl, Product p)
        {
            pl.Remove(p);
            return pl;
        }

        #region Abstract Classes changes

        // this is a new property.  It illustrates the use of the abstract property ShippingCharge
        public decimal ShippingCharge
        {
            get
            {
                decimal total = 0;
                foreach (Product p in products)
                    // this won't work unless ALL classes implement shippingcharge
                    total += p.ShippingCharge;

                return total;

            }
        }

        #endregion
    }
}
