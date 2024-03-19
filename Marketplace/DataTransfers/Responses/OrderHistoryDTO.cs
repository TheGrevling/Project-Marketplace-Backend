using Marketplace.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataTransfers.Responses
{
    public class OrderHistoryDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostCode { get; set; }
        public double TotalSum { get; set; }
        public DateTime DateOfOrder { get; set; }
        
        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    }
}
