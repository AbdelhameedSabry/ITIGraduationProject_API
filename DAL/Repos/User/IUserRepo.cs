namespace ECommerceGP.DAL
{
    public interface IUserRepo:IGeneric<User>
    {
        User?GetShoppingHeaderByUserId(int id); 
    }
}
