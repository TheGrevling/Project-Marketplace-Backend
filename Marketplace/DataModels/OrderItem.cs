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
        [Column("price")]
        public double CurrentPrice { get; set; }
        [Column("amount")]
        public int Amount { get; set; }

        [ForeignKey(nameof(OrderHistory)), Column("fk_order_history_id")]
        public int OrderHistoryId { get; set; }
        public OrderHistory Order { get; set; }
    }
}
