using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebAPI.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetById(int id);

        ProductDTO Add(ProductDTO product);
    }
}
