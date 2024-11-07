using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CoolShopFlowers.Models
{
    public class User : IdentityUser
    {
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string? Sex { get; set; }

        // Навігаційні властивості
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
