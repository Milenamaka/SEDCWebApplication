using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.Models.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetById(int id);

        Product Add(Product product);
    }
}
