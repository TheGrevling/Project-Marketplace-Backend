using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.Helpers;
using Marketplace.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using System.Security.Claims;

namespace Marketplace.Endpoints
{
    public static class ReviewEndpoint
    {
        public static void ConfigureReviewEndpoints(this WebApplication app)
        {
            var reviews = app.MapGroup("reviews");
            reviews.MapGet("/", Get);
            reviews.MapGet("/all", GetAllForProduct);
            reviews.MapPost("/{id}", Post);
            reviews.MapPut("/{id}", Update);
            reviews.MapDelete("/{id}", Delete);
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

        private static async Task<IResult> GetAllForProduct(IRepository<Review> repository, int productId)
        {
            var reviews = await repository.Get();
            List<Review> results = new List<Review>();
            foreach (var review in reviews)
            {
                if (review.ProductId == productId)
                {
                    results.Add(review);
                }
                continue;
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> Post(IRepository<Review> repository, int productId, ReviewPost review, ClaimsPrincipal user)
        {
            if (string.IsNullOrEmpty(user.UserId()))
            {
                return TypedResults.Unauthorized();
            }

            var reviews = await repository.Get();
            
            var entity = new Review()
            {
                Id = reviews.Count() + 1,
                ProductId = productId,
                Rating = review.Rating,
                Title = review.Title,
                Content = review.Content,
            };
            await repository.Insert(entity);
            return TypedResults.Created($"Review posted: {entity.Title}", entity);
        }

        private static async Task<IResult> Update(IRepository<Review> repository, int id, ReviewPut review, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find review with provided Id:{id}");
            }

            entity.Title = !string.IsNullOrEmpty(review.Title) ? review.Title : entity.Title;
            entity.Content = !string.IsNullOrEmpty(review.Content) ? review.Content : entity.Content;
            entity.Rating = (int)(review.Rating.HasValue ? review.Rating : entity.Rating);

            var result = await repository.Update(entity);

            return result != null ? TypedResults.Ok(new { entity.Title }) :
                TypedResults.BadRequest("Failed to update review");

        }

        [Authorize(Roles = "Admin")]
        private static async Task<IResult> Delete(IRepository<Review> repository, int id, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find review with provided Id:{id}");
            }
            var result = await repository.Delete(id);
            return TypedResults.Ok(result);
            
        }
    }
}
