using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYACTest.Entitys
{
    public class OrderProducts
    {
        [Key]
        public int orderProductId { get; set; }
        [ForeignKey("purchaseOrders")]
        public int purchaseOrderId { get; set; }  

        public PurchesOrders? purchaseOrders { get; set; }
        [ForeignKey("products")]
        public int productId { get; set; }

        public Products products { get; set; }

        public int quantity { get; set; }
        public decimal partialValue { get; set; }
 
    }
    
}
