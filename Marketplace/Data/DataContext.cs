using Marketplace.DataModels;
using Marketplace.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Data
{
    public class DataContext : IdentityUserContext<ApplicationUser>
    {
        // Define lists of random product names and producers
        // Define lists of random product name fragments
        private readonly List<string> ProductNameAdjectives = new List<string>
        {
            "Adventure",
            "Mystic",
            "Galactic",
            "Kingdoms",
            "Epic",
            "Ancient",
            // Add more adjectives as needed
        };

        private readonly List<string> ProductNameNouns = new List<string>
        {
            "Quest",
            "Manor",
            "Conquest",
            "Magic",
            "Battles",
            "Chronicles",
            // Add more nouns as needed
        };

        // Define lists of random producer name fragments
        private readonly List<string> ProducerNamePrefixes = new List<string>
        {
            "Adventure",
            "Mystic",
            "Galactic",
            "Legendary",
            "Mythical",
            "Empire",
            // Add more prefixes as needed
        };

        private readonly List<string> ProducerNameSuffixes = new List<string>
        {
            "Games",
            "Studios",
            "Creations",
            "Entertainment",
            "Productions",
            "Co.",
            // Add more suffixes as needed
        };


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderHistory>().Navigation(x => x.Items).AutoInclude();
            modelBuilder.Entity<OrderItem>().Navigation(x=>x.Product).AutoInclude();
            modelBuilder.Entity<Wishlist>().Navigation(x => x.WishlistItems).AutoInclude();
            modelBuilder.Entity<WishlistItem>().Navigation(x => x.Product).AutoInclude();

            SeedProducts(modelBuilder);
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            var rng = new Random();

            // Seed Boardgames
            for (int i = 0; i < 5; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i + 1, // Assuming Id starts from 1
                    Name = GetRandomProductName(),
                    Producer = GetRandomProducer(),
                    Price = rng.Next(100, 1000), // Assuming price range from 100 to 1000 NOK
                    Category = Category.Boardgame,
                    Description = "Description of boardgame",
                    ImageURL = "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg"
                });
            }

            // Seed Cardgames
            for (int i = 0; i < 5; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i + 6, // Assuming Id continues from previous category
                    Name = GetRandomProductName(),
                    Producer = GetRandomProducer(),
                    Price = rng.Next(100, 1000), // Assuming price range from 100 to 1000 NOK
                    Category = Category.Cardgame,
                    Description = "Description of cardgame",
                    ImageURL = "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg"
                });
            }

            // Seed Roleplays
            for (int i = 0; i < 5; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i + 11, // Assuming Id continues from previous category
                    Name = GetRandomProductName(),
                    Producer = GetRandomProducer(),
                    Price = rng.Next(100, 1000), // Assuming price range from 100 to 1000 NOK
                    Category = Category.Roleplay,
                    Description = "Description of roleplay",
                    ImageURL = "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg"
                });
            }

            // Seed Puzzlegames
            for (int i = 0; i < 5; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i + 16, // Assuming Id continues from previous category
                    Name = GetRandomProductName(),
                    Producer = GetRandomProducer(),
                    Price = rng.Next(100, 1000), // Assuming price range from 100 to 1000 NOK
                    Category = Category.Puzzlegame,
                    Description = "Description of puzzlegame",
                    ImageURL = "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg"
                });
            }
        }

        // Helper method to get a random product name from the lists of fragments
        private string GetRandomProductName()
        {
            var rng = new Random();
            string adjective = ProductNameAdjectives[rng.Next(ProductNameAdjectives.Count)];
            string noun = ProductNameNouns[rng.Next(ProductNameNouns.Count)];
            return $"{adjective} {noun}";
        }

        // Helper method to get a random producer name from the lists of fragments
        private string GetRandomProducer()
        {
            var rng = new Random();
            string prefix = ProducerNamePrefixes[rng.Next(ProducerNamePrefixes.Count)];
            string suffix = ProducerNameSuffixes[rng.Next(ProducerNameSuffixes.Count)];
            return $"{prefix} {suffix}";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set;}
    }
}
