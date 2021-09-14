using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SEDCWebApplicationEntityFactory.Entities;
using SEDCWebApplicationEntityFactory.Interfaces;

namespace SEDCWebApplicationEntityFactory.Implementations
{
    public class ProductRepository : IProductDAL
    {
        public void Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(int skip, int take)
        {
            using (var db = new PizzaShop1Context()) {
                List<Product> result = db.Products.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Product GetById(int id)
        {
            using (var db = new PizzaShop1Context()) {
                Product result = db.Products.First(e => e.ProductId== id);
                return result;
            }
        }

        public void Save(Product item)
        {
            using (var db = new PizzaShop1Context()) {
                db.Products.Add(item);
                db.SaveChanges();
            }
        }
    }
}
 
