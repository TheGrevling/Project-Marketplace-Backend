using Marketplace.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; }

        // below in same class or make a separate User.cs?y
        [Column("id")]
        public int ? UserId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email {  get; set; }
        [Column("phone")]
        public string Phone {  get; set; }
        [ForeignKey(nameof(OrderHistory)), Column("fk_order_history_id")]
        public int OrderHistoryId { get; set; }
        public OrderHistory OrderHistory { get; set; }
        [ForeignKey(nameof(Wishlist)), Column("fk_wishlist_id")]
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

    }
}
