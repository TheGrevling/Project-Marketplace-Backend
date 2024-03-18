using Marketplace.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; }
        [Column("id")]
        public int UserId { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("email")]
        public string Email {  get; set; }

    }
}
