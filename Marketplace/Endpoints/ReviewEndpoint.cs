using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.Repository;
using Microsoft.AspNetCore.Builder;
using System.Security.Claims;

namespace Marketplace.Endpoints
{
    public static class ReviewEndpoint
    {
        public static void ConfigureReviewEndpoints(this WebApplication app)
        {
            var products = app.MapGroup("reviews");
            products.MapGet("/", Get);
            products.MapPost("/{id}", Post).AddEndpointFilter(async (invocationContext, next) =>
            {
                var review = invocationContext.GetArgument<ReviewPost>(1);

                if (string.IsNullOrEmpty(review.Title) || string.IsNullOrEmpty(review.Content))
                {
                    return Results.BadRequest("You must enter a full review");
                }
                return await next(invocationContext);
            });
            products.MapPut("/{id}", Update);
            products.MapDelete("/{id}", Delete);
        }

        private static async Task<IResult> Get(IRepository<Review> repository)
        {
            var reviews = await repository.Get();
            List<Review> results = new List<Review>();
            foreach (var review in reviews)
            {
                results.Add(review);
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> Post(IRepository<Review> repository, int userId, int productId, ReviewPost review, ClaimsPrincipal user)
        {
            var reviews = await repository.Get();

            if (reviews.Any(x => x.Title.Equals(review.Title, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest("Review with this title already exists");
            }
            if (user.IsInRole("Admin"))
            {
                var entity = new Review()
                {
                    Id = reviews.Count() + 1,
                    UserId = userId,
                    ProductId = productId,
                    Rating = review.Rating,
                    Title = review.Title,
                    Content = review.Content,
                };
                await repository.Insert(entity);
                return TypedResults.Created($"product posted: {entity.Title}", entity);
            }
            return TypedResults.Unauthorized();
        }

        private static async Task<IResult> Update(IRepository<Review> repository, int id, ReviewPut review, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find review with provided Id:{id}");
            }

            if (user.IsInRole("Admin"))
            {
                entity.Title = !string.IsNullOrEmpty(review.Title) ? review.Title : entity.Title;
                entity.Content = !string.IsNullOrEmpty(review.Content) ? review.Content : entity.Content;
                entity.Rating = (int)(review.Rating.HasValue ? review.Rating : entity.Rating);

                var result = await repository.Update(entity);

                return result != null ? TypedResults.Ok(new { entity.Title }) :
                    TypedResults.BadRequest("Failed to update review");

            }

            return TypedResults.Unauthorized();
        }

        private static async Task<IResult> Delete(IRepository<Review> repository, int id, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find review with provided Id:{id}");
            }

            if (user.IsInRole("Admin"))
            {
                var result = await repository.Delete(id);
                return TypedResults.Ok(result);
            }
            return TypedResults.Unauthorized();
        }
    }
}
