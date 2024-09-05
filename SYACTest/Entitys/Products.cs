using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYACTest.Entitys
{
    public class Products
    {
        [Key]
        public int productId { get; set; }

        public List<OrderProducts> OrderProducts { get; set; }
        public string productCode { get; set; }
        public string productname { get; set; }
        public decimal unitValue { get; set; }

    }
}
