using InGreed_API.Enums;

namespace InGreed_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string PasswordHash { get; set; }
        public UserRoleEnum Role { get; set; }
        public bool EmailNotifications { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Opinion> Opinions { get; set; }
        public virtual List<Preference> Preferences { get; set; }
        public virtual List<FavouriteProduct> FavouriteProducts { get; set; }
        public virtual List<Ban> Bans { get; set; }
    }
}
