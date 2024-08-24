using bangazon.Models;

namespace bangazon.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            // GET USER
            app.MapGet("/api/user/{id}", (BangazonDBContext db, string id) =>
            {
                User user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });

        }
    }
}
