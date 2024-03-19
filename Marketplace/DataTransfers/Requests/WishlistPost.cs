namespace Marketplace.DataTransfers.Requests
{
    public class WishlistPost
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public WishlistItemPost WishlistItemPost { get; set; }
    }
}
