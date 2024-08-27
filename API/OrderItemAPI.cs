using System.Security.Claims;
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
            app.MapPost("/api/orderitem", (BangazonDBContext db, OrderItem orderItem, HttpContext context) =>
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
                        // Generate a new GuestId if it doesn't exist
                        guestId = Guid.NewGuid().ToString();
                        context.Response.Cookies.Append("GuestId", guestId);
                    }
                    openOrder = db.Orders.SingleOrDefault(oo => oo.Open && oo.GuestId == guestId);
                }

                if (openOrder == null)
                {
                    openOrder = new Order
                    {
                        CustomerId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                        Open = true,
                        GuestId = guestId
                    };
                    db.Orders.Add(openOrder);
                    db.SaveChanges();
                }
                orderItem.OrderId = openOrder.Id;

                db.OrderItems.Add(orderItem);
                db.SaveChanges();
                return Results.Created($"/api/orderitem/{orderItem.Id}", orderItem);
            });

        }
    }
}
