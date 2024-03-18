using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(OrderItem)), Column("fk_order_item_id")]
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
        [Column("sum")]
        public double OrderSum { get; set; }
        [Column("quantity")]
        public int OrderQuantity { get; set; }
        [ForeignKey(nameof(OrderHistory)), Column("fk_order_history_id")]
        public int OrderHistoryId { get; set; }
        public OrderHistory OrderHistory { get; set; }
    }
}
