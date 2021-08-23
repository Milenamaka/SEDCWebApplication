using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.IRepository;

namespace SEDCWebApplication.Models.RepositoryImpl
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _productList;
        public MockProductRepository()
        {
            _productList = new List<Product>()
            {
                    new Product
                    {
                        Id=1,
                        ProductName="Margherita",
                        UnitPrice=180,
                        IsDiscounted= false,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/delikates.png",
                        Description="pelat, kačkavalj, svež paradajz"


                    },
                    new Product
                    {
                        Id=2,
                        ProductName="Vegetariana",
                        UnitPrice=170,
                        IsDiscounted= true,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/vegetariana.png",
                        Description="pelat, kačkavalj, tikvica, kukuruz, pečurke, paprika zelena, masline, crni luk, beli luk"
                    },
                    new Product
                    {
                        Id=3,
                        ProductName="Capricciosa",
                        UnitPrice=220,
                        IsDiscounted= false,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/capriccosa.png",
                        Description="pelat, šunka, pečurke, kačkavalj"
                    },
                    new Product
                    {
                        Id=4,
                        ProductName="Specijal",
                        UnitPrice=260,
                        IsDiscounted= false,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/specijal.png",
                        Description="pelat, kačkavalj, kulen, ljuta paprika, svež paradajz, masline"
                    },
                    new Product
                    {
                        Id=5,
                        ProductName="Rukola",
                        UnitPrice=240,
                        IsDiscounted= true,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/rukola.png",
                        Description="pelat, pečurke, rukola, zelena paprika, masline"
                    },
                    new Product
                    {
                        Id=6,
                        ProductName="Srpska",
                        UnitPrice=280,
                        IsDiscounted= false,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/srpska.png",
                        Description="pelat, kačkavalj, šunka, slanina, kulen, pršuta, pečurke, kobasica, zelena paprika, maslina, jaje"
                    },
                    new Product
                    {
                        Id=7,
                        ProductName="Delikates",
                        UnitPrice=280,
                        IsDiscounted= false,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/delikates.png",
                        Description="pelat, kačkavalj, šunka, pečurke, suvi vrat, paprika"
                    },
                    new Product
                    {
                        Id=8,
                        ProductName="Domacinska",
                        UnitPrice=260,
                        IsDiscounted= true,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "small",
                        ImagePath ="/img/domacinska.png",
                        Description="pelat, kačkavalj, šunka, kulen, slanina, pečurke, jaje, svež paradajz"
                    },
                  
                    new Product
                    {
                        Id=27,
                        ProductName="Capricciosa",
                        UnitPrice=560,
                        IsDiscounted= true,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "medium",
                        ImagePath ="/img/capriccosa.png",
                        Description="pelat, šunka, pečurke, kačkavalj"
                    },
                    new Product
                    {
                        Id=28,
                        ProductName="Specijal",
                        UnitPrice=590,
                        IsDiscounted= true,
                        IsActive= false,
                        IsDeleted=false,
                        Size= "medium",
                         ImagePath ="/img/specijal.png",
                        Description="pelat, kačkavalj, kulen, ljuta paprika, svež paradajz, masline"
                    },
                    new Product
                    {
                        Id=29,
                        ProductName="Domacinska",
                        UnitPrice=590,
                        IsDiscounted= true,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "medium",
                        ImagePath ="/img/domacinska.png",
                        Description="pelat, kačkavalj, šunka, kulen, slanina, pečurke, jaje, svež paradajz"
                    },
                    new Product
                    {
                        Id=30,
                        ProductName="Srpska",
                        UnitPrice=580,
                        IsDiscounted= true,
                        IsActive= true,
                        IsDeleted=false,
                        Size= "medium",
                        ImagePath ="/img/srpska.png",
                        Description="pelat, kačkavalj, šunka, slanina, kulen, pršuta, pečurke, kobasica, zelena paprika, maslina, jaje"
                    }


            };

        }
        List<Product> IProductRepository.GetAllProducts()
        {
            return _productList;
        }

        Product IProductRepository.GetById(int id)
        {
            return _productList.Where(x => x.Id == id).FirstOrDefault();
        }
        public Product Add(Product product)
        {
            product.Id = _productList.Max(e => e.Id) + 1;
            _productList.Add(product);
            return _productList.Where(x => x.Id == product.Id).FirstOrDefault();
        }
    }
}
