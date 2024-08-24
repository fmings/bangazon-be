using bangazon.Models;

namespace bangazon.API
{
    public class PaymentDetailAPI
    {
        public static void Map(WebApplication app)
        {
            // POST PAYMENT DETAILS (for checking out/placing order)
            app.MapPost("/api/payment", (BangazonDBContext db, PaymentDetail payment) =>
            {
                db.PaymentDetails.Add(payment);
                db.SaveChanges();
                return Results.Created($"/api/payment/{payment.Id}", payment);
            });

        }
    }
}
