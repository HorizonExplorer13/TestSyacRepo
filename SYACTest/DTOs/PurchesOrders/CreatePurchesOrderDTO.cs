using SYACTest.Entitys;

namespace SYACTest.DTOs.PurchesOrders
{
    public record CreatePurchesOrderDTO
    {
        public string clientName { get; set; }
        public string clientDocument {  get; set; } 

        public string clientAddrees { get; set; }

        public List<OrderProductsDTO> orderProducts { get; set; }

        public string deliveryAddress { get; set; }

        public decimal totalValue { get; set; }
    }
}
