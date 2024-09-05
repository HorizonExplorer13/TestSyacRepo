using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;

namespace SYACTest.Services.ProductsServices
{
    public class Productservices : IProductService
    {
        public Productservices(AppDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public AppDBContext DBContext { get; }

        public async Task<ServiceResponse<object>> getlist(){
            List<Products> productList = new List<Products>();
            productList = new List<Products> {
                new Products
                {
                     productId = 1,
                     productname = "P1",
                     productCode = "1",
                     unitValue = 1,
                },
                 new Products
                {
                     productId = 2,
                     productname = "P2",
                     productCode = "2",
                     unitValue = 2,
                },
                  new Products
                {
                     productId = 3,
                     productname = "P3",
                     productCode = "3",
                     unitValue = 3,
                },
                   new Products
                {
                     productId = 4,
                     productname = "P4",
                     productCode = "4",
                     unitValue = 4,
                },
                    new Products
                {
                     productId = 5,
                     productname = "P5",
                     productCode = "5",
                     unitValue = 5,
                },
            };

            return new ServiceResponse<object>
            {
                statusCode = 200,
                data = productList,
            };
        //    var list = await DBContext.Products.ToListAsync();
        //    if(list.Any() || list.Count > 0)
        //    {
        //        return new ServiceResponse<object>
        //        {
        //            statusCode = 200,
        //            data = list
        //        };
        //    }
        //    return new ServiceResponse<object>
        //    {
        //        statusCode = 400,
                
        //    };
        }

        public async Task<ServiceResponse<List<Products>>> createproducto(List<ProductsDTO> product)
        {
            var createProducts = new List<Products>();
            foreach(var item in product)
            {
                var toadd = new Products {
                    productname = item.productName,
                    productCode = item.productCode,
                    unitValue = item.productUnitValue
                };
                createProducts.Add(toadd);
            }
            await DBContext.Products.AddRangeAsync(createProducts);
            var result = await DBContext.SaveChangesAsync();

           if(result != 0)
            {
                return new ServiceResponse<List<Products>>
                {
                    statusCode = 200
                };
            }
            return new ServiceResponse<List<Products>>
            {
                statusCode = 400
            };

        }

    }
}
