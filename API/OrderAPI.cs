﻿using System.Security.Claims;
using bangazon.Migrations;
using bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace bangazon.API
{
    public class OrderAPI
    {

        public static void Map(WebApplication app)
        {
            // GET ORDER TOTAL
            app.MapGet("/api/order/{id}/total", async (BangazonDBContext db, int id) => {

                var order = db.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductItem)
                .FirstOrDefault(o => o.Id == id);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                // Calculate the total amount
                order.TotalAmount = order.OrderItems.Sum(oi => oi.ProductItem.Price);

                // Save the updated order back to the database
                await db.SaveChangesAsync();

                return Results.Ok(order);
            });


            // GET ORDER
            app.MapGet("/api/order/{id}", (BangazonDBContext db, int id) =>
            {
                Order order = db.Orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(order);
            });

            // POST ORDER
            app.MapPost("/api/order", (BangazonDBContext db, Order order) =>
            {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return Results.Created($"/api/order/{order.Id}", order);
            });

            // PATCH ORDER (when shipment details are added)
            app.MapPatch("/api/order/{id}", (BangazonDBContext db, int id, Order updatedDetails) =>
            {
                Order orderToUpdate = db.Orders.FirstOrDefault(o => o.Id == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }
                orderToUpdate.Open = updatedDetails.Open;
                orderToUpdate.StreetAddress = updatedDetails.StreetAddress;
                orderToUpdate.City = updatedDetails.City;
                orderToUpdate.State = updatedDetails.State;
                orderToUpdate.Zip = updatedDetails.Zip;
                db.SaveChanges();
                return Results.Ok(orderToUpdate);
            });

            // GET LATEST OPEN ORDER
            app.MapGet("/api/order/latest", (BangazonDBContext db, HttpContext context) =>
            {
                string guestId = null;
                var user = context.User.Identity.IsAuthenticated ? context.User : null;

                Order openOrder;

                if (user != null)
                {
                    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    openOrder = db.Orders.SingleOrDefault(oo => oo.Open && oo.CustomerId == userId);
                }
                else
                {
                    if (!context.Request.Cookies.TryGetValue("GuestId", out guestId))
                    {
                        // Just return NotFound if GuestId cookie is not present
                        return Results.NotFound();
                    }
                    openOrder = db.Orders.SingleOrDefault(oo => oo.Open && oo.GuestId == guestId);
                    Console.WriteLine("guestid:", guestId);
                }

                return openOrder != null ? Results.Ok(openOrder.Id) : Results.NotFound();
            });

            // GET LATEST OPEN ORDER BY UID
            app.MapGet("/api/order/latest/{uid}", (BangazonDBContext db, string uid) =>
            {
                Order openOrder = db.Orders.SingleOrDefault(oo => oo.Open && oo.CustomerId == uid);
                return openOrder != null ? Results.Ok(openOrder.Id) : Results.NotFound();

            });
        }
    }
}
