using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplicationEntityFactory.Entities;

namespace SEDCWebApplicationEntityFactory.Interfaces
{
    public interface IProductDAL
    {
        List<Product> GetAllProducts(int skip, int take);
        Product GetById(int id);

        void Save(Product item);

        void Delete(Product item);
    }
}
