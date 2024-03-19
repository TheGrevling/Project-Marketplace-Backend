using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Marketplace.DataModels
{
    [Table("OrderHistory")]
    public class OrderHistory
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("shipping_address")]
        public string ShippingAddress { get; set; }
        [Column("shipping_city")]
        public string ShippingCity { get; set; }
        [Column("shipping_postcode")]
        public string ShippingPostCode { get; set; }
        [Column("total_sum")]
        public double TotalSum { get; set; }
        [ForeignKey(nameof(ApplicationUser)), Column("fk_user_id")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
