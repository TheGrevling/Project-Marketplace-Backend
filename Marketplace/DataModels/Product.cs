using Marketplace.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.DataModels
{
    [Table("Product")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("producer")]
        public string Producer {  get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("category")]
        public Category Category { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
