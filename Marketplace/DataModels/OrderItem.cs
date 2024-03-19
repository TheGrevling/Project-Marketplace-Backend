using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(Product)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Order)), Column("fk_order_id")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
