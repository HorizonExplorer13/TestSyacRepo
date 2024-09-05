using SYACTest.Entitys;

namespace SYACTest.DTOs.PurchesOrders
{
    public record OrderProductsDTO
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal partialValue { get; set; }
    }
}
