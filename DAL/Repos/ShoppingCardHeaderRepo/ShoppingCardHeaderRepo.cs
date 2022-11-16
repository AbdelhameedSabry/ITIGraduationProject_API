using Microsoft.EntityFrameworkCore;

namespace ECommerceGP.DAL
{
    public class ShoppingCardHeaderRepo:Generic<ShoppingCardHeader>,IShoppingCardHeaderRepo
    {
        private readonly ApplicationDbcontext applicationDbcontext; 

        public ShoppingCardHeaderRepo(ApplicationDbcontext applicationDbcontext):base(applicationDbcontext)
        {
            this.applicationDbcontext = applicationDbcontext;
        }

        public void CreateCardproductAndCardHeader(ShoppingCardHeader cardHeaders)
        {
            applicationDbcontext.shoppingCardHeaders.Add(cardHeaders);
        }

        public ShoppingCardHeader? GetCardProductsByShoppingCardHeaderId(int id)
        {
            return applicationDbcontext.shoppingCardHeaders.Include(s => s.cardproducts).FirstOrDefault(d => d.Id ==id);
        }
    }
}
