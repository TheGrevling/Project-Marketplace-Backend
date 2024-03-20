using Marketplace.Data;
using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.DataTransfers.Responses;
using Marketplace.Helpers;
using Marketplace.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Marketplace.Endpoints
{
    public static class WishlistEndpoints
    {
        public static void ConfigureWishlistEndpoints(this WebApplication app)
        {
            var reviews = app.MapGroup("wishlist");
            reviews.MapGet("/", Get);
            reviews.MapGet("/{id}", GetById);
            reviews.MapPost("/{id}", Post);
            reviews.MapDelete("/{id}", Delete);
        }

        private static async Task<IResult> Get(IRepository<Wishlist> repository)
        {
            var wishlists = await repository.Get();
            List<WishlistDTO> results = new List<WishlistDTO>();
            foreach (var wish in wishlists)
            {
                results.Add(createWishlistDTO(wish));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> GetById(IRepository<Wishlist> repository, int id, ClaimsPrincipal user)
        {
            var wishlist = await repository.GetById(id);
            if (wishlist == null)
            {
                return Results.BadRequest("Can't find wishlist matching that user id");
            }
            if (wishlist.UserId != user.UserId() && !user.IsInRole("Admin"))
            {
                return Results.Unauthorized();
            }
            return TypedResults.Ok(createWishlistDTO(wishlist));
        }

        private static async Task<IResult> Post(IRepository<Wishlist> repository, WishlistPost post, ClaimsPrincipal user, DataContext context)
        {
            if(string.IsNullOrEmpty(user.UserId()))
            {
                return TypedResults.Unauthorized();
            }

            var wishlists = await repository.Get();

            var postwishlist = new Wishlist()
            {
                Id = wishlists.Max(w => w.Id) + 1,
                UserId = user.UserId(),
                WishlistItems = new List<WishlistItem>()
            };

            foreach (var wishlistItem in post.Items)
            {
                // Check if the product with the given ProductId exists
                var productExists = await ProductExists(context, wishlistItem.ProductId);
                if (!productExists)
                {
                    return Results.BadRequest($"Product with ID {wishlistItem.ProductId} does not exist.");
                }

                var wishlistItems = context.WishlistItems;

                var newItem = new WishlistItem
                {
                    Id = wishlistItems.Max(w => w.Id) + 1,
                    ProductId = wishlistItem.ProductId,
                    WishlistId = postwishlist.Id  // Set WishlistId to establish the association
                };

                // Add the wishlistItem  to the Wishlist's Items collection
                postwishlist.WishlistItems.Add(newItem);
            }
            // Insert the new Wishlist object along with its associated WishlistLitem objects into the database
            await repository.Insert(postwishlist);
            return TypedResults.Ok(createWishlistDTO(postwishlist));
        }

        [Authorize(Roles = "Admin")]
        private static async Task<IResult> Delete(IRepository<Wishlist> repository, int id, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find wishlist with provided Id:{id}");
            }
            var result = await repository.Delete(id);
            return TypedResults.Ok(result);

        }

        private static WishlistDTO createWishlistDTO(Wishlist w)
        {
            WishlistDTO wishlist = new WishlistDTO();
            wishlist.Id = w.Id;
            wishlist.UserId = w.UserId;
            wishlist.WishlistItems.AddRange(w.WishlistItems.Select(item => new WishlistItemDTO
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Product = new ProductDTO
                {
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Price = item.Product.Price,
                    ImageURL = item.Product.ImageURL,
                    Category = item.Product.Category
                }
            }).ToList());

            return wishlist;
        }

        // Helper method to check if a product with the given ProductId exists in the Products table
        private static async Task<bool> ProductExists(DataContext context, int productId)
        {
            // Check if a product with the given ProductId exists in the Products table
            return await context.Products.AnyAsync(p => p.Id == productId);
        }
    }
}
