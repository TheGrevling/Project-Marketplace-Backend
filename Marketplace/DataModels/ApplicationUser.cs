using Marketplace.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; }

    }
}
