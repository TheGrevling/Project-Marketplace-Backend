namespace Marketplace.DataTransfers.Responses
{
    public class WishlistItemDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
