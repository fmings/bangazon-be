using bangazon.Models;

namespace bangazon.Data
{
    public class UserData
    {
        public static List<User> ProductItems = new List<User>
        {
            new User { Id = "1", FirstName = "Felicia", LastName = "Yahoo", Email = "felicia_mings@yahoo.com", Seller = false },
            new User { Id = "2", FirstName = "Lola", LastName = "Gmail", Email = "felicia.mings13@gmail.com", Seller = false }

        };
    }
}
