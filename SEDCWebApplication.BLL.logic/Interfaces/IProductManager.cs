using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebApplication.BLL.logic.Interfaces
{
    public interface IProductManager
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetById(int id);

        ProductDTO Add(ProductDTO product);
    }
}
