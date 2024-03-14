using Marketplace.Enums;
using Microsoft.AspNetCore.Identity;

namespace Marketplace.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; }
    }
}
