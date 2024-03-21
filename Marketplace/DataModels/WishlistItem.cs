using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("WishlistItem")]
    public class WishlistItem
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(Product)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(ApplicationUser)), Column("fk_user_id")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
