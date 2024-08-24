using bangazon.Models;

namespace bangazon.API
{
    public class OrderAPI
    {

        public static void Map(WebApplication app)
        {
            // GET ORDER TOTAL


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
                orderToUpdate.StreetAddress = updatedDetails.StreetAddress;
                orderToUpdate.City = updatedDetails.City;
                orderToUpdate.State = updatedDetails.State;
                orderToUpdate.Zip = updatedDetails.Zip;
                return Results.Ok(orderToUpdate);
            });
        }
    }
}
