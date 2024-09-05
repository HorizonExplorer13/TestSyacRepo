using SYACTest.AuxModels;
using SYACTest.DTOs.PurchesOrders;
using SYACTest.Entitys;

namespace SYACTest.Services.PurchesOrderService
{
    public interface IPurchesOrderService
    {
        Task<ServiceResponse<PurchesOrders>> CreatePurchesOrder(CreatePurchesOrderDTO createPurchesOrder);
        Task<ServiceResponse<List<PurchesOrderDTO>>> GetPurchesOrdersList();
    }
}
