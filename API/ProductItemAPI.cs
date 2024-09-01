using bangazon.Models;
using Microsoft.EntityFrameworkCore;
namespace bangazon.API
{
    public static class ProductItemAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL PRODUCTS
            app.MapGet("/api/products", (BangazonDBContext db) =>
            {
                return db.ProductItems.ToList();
            });

            // GET SINGLE PRODUCT BY ID WITH USER DETAILS
            app.MapGet("/api/product/{id}", async (BangazonDBContext db, int id) =>
            {
                ProductItem productItem = await db.ProductItems
                .Include(p => p.User) // Eagerly load the User entity
                .FirstOrDefaultAsync(p => p.Id == id);

                if (productItem == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(productItem);
            });

            // GET PRODUCTS BY SELLER
            app.MapGet("/api/seller/{id}/products", (BangazonDBContext db, string id) =>
            {
                List<ProductItem> sellerProducts = db.ProductItems.Where(pi => pi.UserId == id).ToList();
                return sellerProducts;
            });

        }
    }
}
