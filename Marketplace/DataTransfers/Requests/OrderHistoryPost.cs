using Marketplace.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataTransfers.Requests
{
    public class OrderHistoryPost
    {
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostCode { get; set; }
        public double TotalSum { get; set; }
        public DateTime DateOfOrder { get; set; }
        public List<orderItemPost> Items { get; set; } = new List<orderItemPost>();
    }

    public class orderItemPost
    {
        public int ProductId { get; set; }
        public double CurrentPrice { get; set; }
        public int Amount { get; set; }
    }
}
