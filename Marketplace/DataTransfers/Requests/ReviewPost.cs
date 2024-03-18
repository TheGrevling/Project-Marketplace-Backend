namespace Marketplace.DataTransfers.Requests
{
    public class ReviewPost
    {
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
