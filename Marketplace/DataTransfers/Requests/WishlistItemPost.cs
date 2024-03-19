namespace Marketplace.DataTransfers.Requests
{
    public class WishlistItemPost
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WishlistId { get; set; }
    }
}
