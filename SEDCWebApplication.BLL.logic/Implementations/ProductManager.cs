using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;
//using SEDCWebApplication.DAL.data.Entities;
//using SEDCWebApplication.DAL.data.Interfaces;
//using SEDCWebApplicationEntityFactory.Entities;
//using SEDCWebApplicationEntityFactory.Interfaces;

namespace SEDCWebApplication.BLL.logic.Implementations
{
    public class ProductManager : IProductManager
    {

        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;
        public ProductManager(IProductDAL productDAL, IMapper mapper)
        {
            _productDAL = productDAL;
            _mapper = mapper;
        }
        public ProductDTO Add(ProductDTO product)
        {

            Product productEntity = _mapper.Map<Product>(product);
            _productDAL.Save(productEntity);
            product = _mapper.Map<ProductDTO>(productEntity);
            return product;
        }
        public ProductDTO Delete(ProductDTO product)
        {

            Product productEntity = _mapper.Map<Product>(product);
            _productDAL.Delete(productEntity);
            product = _mapper.Map<ProductDTO>(productEntity);
            return product;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_productDAL.GetAll(0, 50));
        }

        public ProductDTO GetById(int id)
        {
            return _mapper.Map<ProductDTO>(_productDAL.GetById(id));
        }
    }
}
