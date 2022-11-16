using Microsoft.EntityFrameworkCore;

namespace ECommerceGP.DAL;

public class UserRepo:Generic<User> ,IUserRepo
{
    private readonly ApplicationDbcontext _dbcontext;
    public UserRepo(ApplicationDbcontext applicationDbcontext ):base(applicationDbcontext)
    {
      _dbcontext = applicationDbcontext;
    }

    public User? GetShoppingHeaderByUserId(int id)
    {
        return _dbcontext.Users.Include(s => s.shoppingcardheader).ThenInclude(s=>s.cardproducts).FirstOrDefault(a => a.Id ==id);
    }
}
