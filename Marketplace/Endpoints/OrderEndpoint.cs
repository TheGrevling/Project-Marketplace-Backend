using Marketplace.DataModels;
using Marketplace.DataTransfers.Requests;
using Marketplace.DataTransfers.Responses;
using Marketplace.Helpers;
using Marketplace.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Marketplace.Endpoints
{
    public static class OrderEndpoint
    {
        public static void ConfigureOrderEndpoints(this WebApplication app)
        {
            var orders = app.MapGroup("orders");
            orders.MapGet("/", Get);
            orders.MapGet("/{id}", GetById);
            orders.MapPost("/{id}", Post).AddEndpointFilter(async (invocationContext, next) =>
            {
                var product = invocationContext.GetArgument<ProductPost>(1);

                if (string.IsNullOrEmpty(product.Name))
                {
                    return Results.BadRequest("You must enter a product name");
                }
                return await next(invocationContext);
            });
            orders.MapPut("/{id}", Update);
            orders.MapDelete("/{id}", Delete);
        }

        //[Authorize(Roles ="Admin")]
        private static async Task<IResult> Get(IRepository<OrderHistory> repository)
        {
            var products = await repository.Get();
            List<OrderHistoryDTO> results = new List<OrderHistoryDTO>();
            foreach (var history in products)
            {
                results.Add(createOrderHistoryDTO(history));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> GetById(IRepository<Product> repository, int id)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        private static async Task<IResult> Post(IRepository<Product> repository, ProductPost product, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        private static async Task<IResult> Update(IRepository<Product> repository, int id, ProductPut product, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        private static async Task<IResult> Delete(IRepository<Product> repository, int id, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        private static OrderHistoryDTO createOrderHistoryDTO(OrderHistory oh)
        {
            OrderHistoryDTO orderhistory = new OrderHistoryDTO();
            orderhistory.Id = oh.Id;
            orderhistory.TotalSum = oh.TotalSum;
            orderhistory.DateOfOrder = oh.DateOfOrder;
            orderhistory.ShippingAddress = oh.ShippingAddress;
            orderhistory.ShippingCity = oh.ShippingCity;
            orderhistory.ShippingPostCode = oh.ShippingPostCode;
            orderhistory.UserId = oh.UserId;
            orderhistory.Items = oh.Items.Select(item => new OrderItemDTO
            {
                Id = item.Id,
                CurrentPrice = item.CurrentPrice,
                Amount = item.Amount,
                ProductId = item.ProductId,
                Product = new ProductDTO
                {
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Price = item.Product.Price,
                    ImageURL = item.Product.ImageURL,
                    Category = item.Product.Category
                }
            }).ToList();

            return orderhistory;
        }
    }
}
