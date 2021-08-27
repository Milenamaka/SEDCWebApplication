using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.DAL.data.Entities;

namespace SEDCWebApplication.DAL.data.Interfaces
{
    public interface IProductDAL
    {
        List<Product> GetAllProducts(int skip, int take);
        Product GetById(int id);

        void Save(Product item);
    }
}
