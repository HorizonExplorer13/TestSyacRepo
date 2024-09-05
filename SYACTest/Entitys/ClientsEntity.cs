using System.ComponentModel.DataAnnotations;

namespace SYACTest.Entitys
{
    public class ClientsEntity
    {
        [Key]
        public int clientId { get; set; }
        public string clientDocument { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }

        public List<PurchesOrders> purchesOrdersAsosiated { get; set; }

    }
}
