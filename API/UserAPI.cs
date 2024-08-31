using bangazon.Models;

namespace bangazon.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            // CHECK USERS
            app.MapGet("/checkUser/{uid}", (BangazonDBContext db, string uid) =>
            {
                var user = db.Users.Where(u => u.Id == uid).ToList();

                if (uid == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });
            
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

            // REGISTER USER
            app.MapPost("/register", (BangazonDBContext db, User newUser) =>
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return Results.Ok(newUser);
            });

        }
    }
}
