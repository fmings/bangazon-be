using bangazon.Models;

namespace bangazon.API
{
    public class OrderItemAPI
    {
        public static void Map(WebApplication app)
        {

            // GET ORDERITEMS
            app.MapGet("/api/order/{id}/orderitems", (BangazonDBContext db, int id) =>
            {
                List<OrderItem> orderItems = db.OrderItems.Where(oi => oi.OrderId == id).ToList();
                return Results.Ok(orderItems);
            });

            // DELETE ORDERITEM
            app.MapDelete("/api/orderitem/{id}", (BangazonDBContext db, int id) =>
            {
                OrderItem orderItem = db.OrderItems.FirstOrDefault(oi => oi.Id == id);
                if (orderItem == null)
                {
                    return Results.NotFound();
                }
                db.OrderItems.Remove(orderItem);
                db.SaveChanges();
                return Results.NoContent();
            });

            // POST ORDER ITEM (FOR ADDING ITEM TO CART)
            app.MapPost("/api/orderitem", (BangazonDBContext db, OrderItem orderitem) =>
            {
                db.OrderItems.Add(orderitem);
                db.SaveChanges();
                return Results.Created($"/api/orderitem/{orderitem.Id}", orderitem);
            });

        }
    }
}
