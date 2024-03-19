using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("Inventory")]
    public class Inventory
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [ForeignKey(nameof(Product)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
