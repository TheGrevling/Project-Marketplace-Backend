using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class Wishlist
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(ApplicationUser.Id)), Column("fk_user_id")]
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(WishlistItem.Id)), Column("fk_wishlist_item_id")]
        public int WishlistItemId { get; set; }
        public WishlistItem WishlistItem { get; set; }
    }
}
