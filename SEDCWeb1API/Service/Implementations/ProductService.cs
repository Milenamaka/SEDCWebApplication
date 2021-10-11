using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWeb1API.Service.Implementations

{
    public class ProductService : IProductService
    {
        private readonly IProductManager _productManager;
        public ProductService(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _productManager.GetAllProducts();
        }

        public ProductDTO GetById(int id)
        {
            return _productManager.GetById(id);
        }

        public ProductDTO Add(ProductDTO product)
        {
            return _productManager.Add(product);
        }
        public ProductDTO Delete(ProductDTO product)
        {
            return _productManager.Delete(product);
        }

    }
}

