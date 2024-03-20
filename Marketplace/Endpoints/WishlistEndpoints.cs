using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.DataTransfers.Responses;
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
            List<Wishlist> results = new List<Wishlist>();
            foreach (var wishlist in wishlists)
            {
                results.Add(product);
            }
            return TypedResults.Ok(results);
            var wishlists = from wishlist in await repository.Get()
                            select new WishlistDTO()
                            {
                                Id = wishlist.Id,
                                WishlistItems = wishlist.WishlistItems.Select(x => new WishlistItemDTO()
                                { 
                                    Id = x.Id,
                                    Product = new ProductDTO()
                                    {
                                        Name = x.Product.Name,
                                        Producer = x.Product.Producer,
                                        Category = x.Product.Category,
                                        Price = x.Product.Price,
                                        Description = x.Product.Description,
                                        ImageURL = x.Product.ImageURL,
                                    }
                                })
                            };
            return TypedResults.Ok(wishlists);
        }

        private static async Task<IResult> GetById(IRepository<Wishlist> repository, int id)
        {
            var wishlist = await repository.GetById(id);
            if (wishlist == null)
            {
                return Results.BadRequest("Can't find wishlist with that id");
            }
            return TypedResults.Ok(wishlist);
        }

        private static async Task<IResult> Post(IRepository<Wishlist> repository, string userId, ClaimsPrincipal user)
        {
            var wishlists = await repository.Get();

            if (wishlists.Any(x => x.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest($"Wishlist for {userId} already exists");
            }

            var entity = new Wishlist()
            {
                Id = wishlists.Count() + 1,
                UserId = userId
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
    }
}
