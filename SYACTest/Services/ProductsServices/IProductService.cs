using SYACTest.AuxModels;
using SYACTest.DTOs;
using SYACTest.Entitys;

namespace SYACTest.Services.ProductsServices
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Products>>> createproducto(List<ProductsDTO> product);
        Task<ServiceResponse<object>> getlist();
    }
}
