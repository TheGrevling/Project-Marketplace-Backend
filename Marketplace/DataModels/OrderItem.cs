using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(Product.Id)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Order.Id)), Column("fk_order_id")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
