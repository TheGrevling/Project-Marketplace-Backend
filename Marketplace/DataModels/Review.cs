using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    public class Review
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(Product)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        //[ForeignKey(nameof(User)), Column("user")]
        public int UserId { get; set; }
        //public User user { get; set; } - do we use ApplicationUser or make a new class?
        [Column("rating")]
        public int Rating { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }

        
    }
}
