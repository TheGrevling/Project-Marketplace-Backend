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
            reviews.MapGet("/myWishlist", GetByUserId);
            reviews.MapPost("/{id}", Post);
            reviews.MapDelete("/{id}", Delete);
        }

        [Authorize(Roles ="Admin")]
        private static async Task<IResult> Get(IRepository<WishlistItem> repository)
        {
            var items = await repository.Get();
            List<WishlistItemDTO> results = new List<WishlistItemDTO>();
            foreach (var wish in items)
            {
                results.Add(createWishlistItemDTO(wish));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> GetById(IRepository<WishlistItem> repository, int id, ClaimsPrincipal user)
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
            return TypedResults.Ok(createWishlistItemDTO(wishlist));
        }

        private static async Task<IResult> Post(IRepository<WishlistItem> repository, IRepository<Product> productRepo,int id, ClaimsPrincipal user, DataContext context)
        {
            if(string.IsNullOrEmpty(user.UserId()))
            {
                return TypedResults.Unauthorized();
            }

            var wishlists = await repository.Get();

            // Check if the product with the given ProductId exists
            var productExists = await ProductExists(context, id);
            if (!productExists)
            {
                return Results.BadRequest($"Product with ID {id} does not exist.");
            }
            // Check if the wishlist already contains an item with the same user ID and product ID
            var itemExists = wishlists.Any(w => w.UserId == user.UserId() && w.ProductId == id);
            if (itemExists)
            {
                return Results.BadRequest($"Item already exists in the wishlist.");
            }
            int newID = wishlists.Any() ? wishlists.Max(w => w.Id) + 1 : 1;
            var newItem = new WishlistItem
            {
                Id = newID,
                ProductId = id,
                UserId = user.UserId(),
            };
                
            // Insert the new Wishlist object into the database
            var result = await repository.Insert(newItem);
            result.Product = await productRepo.GetById(result.ProductId);

            return TypedResults.Ok(createWishlistItemDTO(result));
        }

        [Authorize]
        private static async Task<IResult> Delete(IRepository<WishlistItem> repository, int id, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find wishlist with provided Id:{id}");
            }

            if (user.UserId()==entity.UserId || user.IsInRole("Admin"))
            {
                var result = await repository.Delete(id);
                return TypedResults.Ok(createWishlistItemDTO(result));
            }
            return TypedResults.Unauthorized();

        }
        [Authorize]
        private static async Task<IResult> GetByUserId(IRepository<WishlistItem> repository, ClaimsPrincipal user)
        {
            // Define a function to extract the UserId from a wishlistItem object
            Func<WishlistItem, string> getUserIdFunc = (WishlistItem w) => w.UserId;

            // Retrieve order histories by user ID using the GetByUserId method
            var wli = await repository.GetByUserId(user.UserId(), getUserIdFunc);

            // Project each OrderHistory object to its corresponding DTO using createOrderHistoryDTO function
            var wliDTOs = wli.Select(createWishlistItemDTO);

            // Return the filtered order history DTOs
            return TypedResults.Ok(wliDTOs);
        }

        private static WishlistItemDTO createWishlistItemDTO(WishlistItem w)
        {
            WishlistItemDTO wishlist = new WishlistItemDTO();
            wishlist.Id = w.Id;
            wishlist.UserId = w.UserId;
            wishlist.ProductId = w.ProductId;
            wishlist.Product = new ProductDTO
            {
            Name = w.Product.Name,
            Producer = w.Product.Producer,
            Price = w.Product.Price,
            Category = w.Product.Category,
            Description = w.Product.Description,
            ImageURL = w.Product.ImageURL
            };

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
