using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("WishlistItem")]
    public class WishlistItem
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(Product.Id)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Wishlist.Id)), Column("fk_wishlist_id")]
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
