﻿using Marketplace.Data;
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
    public static class OrderEndpoint
    {
        public static void ConfigureOrderEndpoints(this WebApplication app)
        {
            var orders = app.MapGroup("orders");
            orders.MapGet("/", Get);
            orders.MapGet("/{id}", GetById);
            orders.MapGet("/myOrders", GetByUserId);
            orders.MapPost("/", Post);
        }

        [Authorize(Roles ="Admin")]
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

        private static async Task<IResult> GetById(IRepository<OrderHistory> repository, int id, ClaimsPrincipal user)
        {
            var history = await repository.GetById(id);
            if (history == null)
            {
                return Results.BadRequest("Can't find orderhistory with that id");
            }
            
            if (history.UserId != user.UserId() && !user.IsInRole("Admin"))
            {
                return Results.Unauthorized();
            }
            return TypedResults.Ok(createOrderHistoryDTO(history));
        }

        private static async Task<IResult> Post(IRepository<OrderHistory> repository,IRepository<OrderItem> itemRepo, IRepository<Product> prodRepo, OrderHistoryPost oh, ClaimsPrincipal user, DataContext context)
        {
            if (string.IsNullOrEmpty(user.UserId()))
            {
                return TypedResults.Unauthorized();
            }
            var histories = await repository.Get();
            // 1. Create and populate the OrderHistory object
            var orderHistory = new OrderHistory
            {
                //Id = histories.Any() ? histories.Max(w => w.Id) + 1 : 1,
                ShippingAddress = oh.ShippingAddress,
                ShippingCity = oh.ShippingCity,
                ShippingPostCode = oh.ShippingPostCode,
                TotalSum = oh.TotalSum,
                DateOfOrder = oh.DateOfOrder,
                UserId = user.UserId(),
            };
            var temphistory = orderHistory;

            // 2. Create and populate the OrderItem objects
            foreach (var itemPost in oh.Items)
            {
                // Check if the product with the given ProductId exists
                var productExists = await ProductExists(context, itemPost.ProductId);
                if (!productExists)
                {
                    return Results.BadRequest($"Product with ID {itemPost.ProductId} does not exist.");
                }

                var orderItem = new OrderItem
                {
                    ProductId = itemPost.ProductId,
                    CurrentPrice = itemPost.CurrentPrice,
                    Amount = itemPost.Amount,
                    OrderHistoryId = orderHistory.Id // Set OrderHistoryId to establish the association
                };
                orderItem.Product = await prodRepo.GetById(orderItem.ProductId);

                // Add the OrderItem to the OrderHistory's Items collection
                orderHistory.Items.Add(orderItem);
            }

            // 3. Insert the OrderHistory object along with its associated OrderItem objects into the database
            await repository.Insert(temphistory);

            return TypedResults.Ok(createOrderHistoryDTO(orderHistory));
        }
        [Authorize]
        private static async Task<IResult> GetByUserId(IRepository<OrderHistory> repository, ClaimsPrincipal user)
        {
            // Define a function to extract the UserId from an OrderHistory object
            Func<OrderHistory, string> getUserIdFunc = (OrderHistory oh) => oh.UserId;

            // Retrieve order histories by user ID using the GetByUserId method
            var orderHistories = await repository.GetByUserId(user.UserId(), getUserIdFunc);

            // Project each OrderHistory object to its corresponding DTO using createOrderHistoryDTO function
            var orderHistoryDTOs = orderHistories.Select(createOrderHistoryDTO);

            // Return the filtered order history DTOs
            return TypedResults.Ok(orderHistoryDTOs);
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
            orderhistory.Items.AddRange( oh.Items.Select(item => new OrderItemDTO
            {
                Id = item.Id,
                CurrentPrice = item.CurrentPrice,
                Amount = item.Amount,
                ProductId = item.ProductId,
                Product = new ProductDTO
                {
                    Name = item.Product.Name,
                    Producer = item.Product.Producer,
                    Description = item.Product.Description,
                    Price = item.Product.Price,
                    ImageURL = item.Product.ImageURL,
                    Category = item.Product.Category
                }
            }).ToList());

            return orderhistory;
        }
        // Helper method to check if a product with the given ProductId exists in the Products table
        private static async Task<bool> ProductExists(DataContext context, int productId)
        {
            // Check if a product with the given ProductId exists in the Products table
            return await context.Products.AnyAsync(p => p.Id == productId);
        }
    }
}
