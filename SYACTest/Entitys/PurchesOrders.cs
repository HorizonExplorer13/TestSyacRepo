using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYACTest.Entitys
{
    public class PurchesOrders
    {
        [Key]
        public int purchesOrderid { get; set; }
        [ForeignKey("client")]
        public int clientId { get; set; }
        public ClientsEntity? client { get; set; }

        public List<OrderProducts> orderProducts { get; set; }

        public string state { get; set; }
        public string priority { get; set; }
        public DateTime recordDate { get; set; }
        public string deliveryAddress { get; set; }
        public decimal totalValue  { get; set; }

    }
}
