namespace SYACTest.DTOs.orderProduct
{
    public record orderProductsDTO
    {
        public int ProductId { get; set; }  
        public int Quantity { get; set; }
        public decimal PartialValue { get; set; }  
    }
}
