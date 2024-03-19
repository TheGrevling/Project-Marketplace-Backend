using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.DataTransfers.Responses;
using Marketplace.Helpers;
using Marketplace.Repository;
using Microsoft.AspNetCore.Authorization;
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

        private static async Task<IResult> Post(IRepository<Wishlist> repository, IRepository<WishlistItem> repoItem, IRepository<Product> repoProduct, string userId, int productId, ClaimsPrincipal user)
        {

            // doesn't work, pls fix

            var wishlists = await repository.Get();
            var items = await repoItem.Get();
            var product = await repoProduct.GetById(productId);

            if (wishlists.Any(x => x.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest($"Wishlist for {userId} already exists");
            }

            var entity = new Wishlist()
            {
                Id = wishlists.Count() + 1,
                UserId = userId,
                WishlistItems = new List<WishlistItem>()
                /*{
                    new WishlistItem()
                    {
                        Id = items.Count() + 1,
                        ProductId = productId,
                        Product = product,
                        WishlistId = wishlists.Count(),
                    }
                }*/
            };

            await repository.Insert(entity);
            return TypedResults.Created($"Wishlist posted: {entity.Id}", entity);
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
    }
}
