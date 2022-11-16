using Microsoft.AspNetCore.Identity;

namespace ECommerceGP.DAL
{
    public class User:IdentityUser<int>
    {
        public string address { get; set; } = "";
        public ICollection<ShoppingCardHeader> shoppingcardheader { get; set; } = new HashSet<ShoppingCardHeader>();
    
    }
}
