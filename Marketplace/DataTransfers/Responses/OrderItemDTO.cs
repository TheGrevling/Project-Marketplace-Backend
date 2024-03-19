using Marketplace.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataTransfers.Responses
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public double CurrentPrice { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }

    }
}
