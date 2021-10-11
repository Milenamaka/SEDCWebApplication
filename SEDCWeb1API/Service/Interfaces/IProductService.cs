using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWeb1API.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetById(int id);

        ProductDTO Add(ProductDTO product);
        ProductDTO Delete(ProductDTO product);
    }
}
