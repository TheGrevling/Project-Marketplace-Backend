using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("Wishlist")]
    public class Wishlist
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(ApplicationUser)), Column("fk_user_id")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<WishlistItem> WishlistItems { get; set; }
    }
}
