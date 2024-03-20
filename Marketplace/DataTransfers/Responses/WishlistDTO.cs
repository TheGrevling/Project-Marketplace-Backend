using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataTransfers.Responses
{
    public class WishlistDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<WishlistItemDTO> WishlistItems { get; set; } = new List<WishlistItemDTO>();
    }
}
