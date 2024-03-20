using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.Helpers;
using Marketplace.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marketplace.Endpoints
{
    public static class ProductEndpoints
    {
        public static void ConfigureProductEndpoints(this WebApplication app)
        {
            var products = app.MapGroup("products");
            products.MapGet("/", Get);
            products.MapGet("/{id}", GetById);
            products.MapPost("/{id}", Post).AddEndpointFilter(async (invocationContext, next) =>
            {
                var product = invocationContext.GetArgument<ProductPost>(1);

                if (string.IsNullOrEmpty(product.Name))
                {
                    return Results.BadRequest("You must enter a product name");
                }
                return await next(invocationContext);
            });
            products.MapPut("/{id}", Update);
            products.MapDelete("/{id}", Delete);
        }

        private static async Task<IResult> Get(IRepository<Product> repository, string? category)
        {
            var products = await repository.Get();

            if (!string.IsNullOrEmpty(category))
            {
                // Filter products based on category
                products = products.Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return TypedResults.Ok(products);
        }


        private static async Task<IResult> GetById(IRepository<Product> repository, int id)
        {
            var product = await repository.GetById(id);
            if (product == null)
            {
                return Results.BadRequest("Can't find product with that id");
            }
            return TypedResults.Ok(product);
        }

        [Authorize(Roles ="Admin")]
        private static async Task<IResult> Post(IRepository<Product> repository, ProductPost product, ClaimsPrincipal user)
        {
            var products = await repository.Get();

            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest("Product with this name already exists");
            }
            if (user.IsInRole("Admin"))
            {
                var entity = new Product()
                {
                    Id = products.Count() + 1,
                    Name = product.Name,
                    Producer = product.Producer,
                    Price = product.Price,
                    Category = product.Category,
                    Description = product.Description,
                    ImageURL = product.ImageURL
                };
                await repository.Insert(entity);
                return TypedResults.Created($"product posted: {entity.Name}", entity);
            }
            return TypedResults.Unauthorized();
        }

        [Authorize(Roles = "Admin")]
        private static async Task<IResult> Update(IRepository<Product> repository, int id, ProductPut product, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find product with provided Id:{id}");
            }

            if (user.IsInRole("Admin"))
            {
                entity.Name = !string.IsNullOrEmpty(product.Name) ? product.Name : entity.Name;
                entity.Producer = !string.IsNullOrEmpty(product.Producer) ? product.Producer : entity.Producer;
                entity.Category = (product.Category != null) ? product.Category : entity.Category;
                entity.Price = (double)(product.Price.HasValue ? product.Price : entity.Price);
                entity.Description = !string.IsNullOrEmpty(product.Description) ? product.Description : entity.Description;
                entity.ImageURL = !string.IsNullOrEmpty(product.ImageURL) ? product.ImageURL : entity.ImageURL;

                var result = await repository.Update(entity);

                return result != null ? TypedResults.Ok(new { entity.Name }) :
                    TypedResults.BadRequest("Failed to update product");

            }

            return TypedResults.Unauthorized();
        }

        [Authorize(Roles = "Admin")]
        private static async Task<IResult> Delete(IRepository<Product> repository, int id, ClaimsPrincipal user)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return TypedResults.NotFound($"Could not find product with provided Id:{id}");
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
