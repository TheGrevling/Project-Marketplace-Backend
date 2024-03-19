using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("Review")]
    public class Review
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(Product.Id)), Column("fk_product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(ApplicationUser.Id)), Column("user_id")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Column("rating")]
        public int Rating { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }

        
    }
}
