using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class WishlistItem
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(Product)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Wishlist)), Column("fk_wishlist_id")]
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
