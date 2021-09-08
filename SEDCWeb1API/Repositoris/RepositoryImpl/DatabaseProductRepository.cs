﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWeb1API.IRepository;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWeb1API.RepositoryImpl
{
    public class DatabaseProductRepository : IProductRepository
    {
        private readonly IProductManager _productManager;
        public DatabaseProductRepository(IProductManager productManager)
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

