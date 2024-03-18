using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class Wishlist
    {
        [Column("id")]
        public int Id { get; set; }
        //[ForeignKey(nameof(User)), Column("fk_user_id")]
        public int UserID { get; set; }
        //public User User { get; set; }
        [ForeignKey(nameof(WishlistItem)), Column("fk_wishlist_item_id")]
        public int WishlistItemId { get; set; }
        public WishlistItem WishlistItem { get; set; }
    }
}
