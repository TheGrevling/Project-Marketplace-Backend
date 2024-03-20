using Marketplace.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataTransfers.Requests
{
    public class ProductPost
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
