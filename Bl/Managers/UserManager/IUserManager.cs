using ECommerceGP.Bl.Dtos.UserDtos;

namespace ECommerceGP.Bl.Managers.UserManager
{
    public interface IUserManager
    {
        UserReadDtos? GetUsersOrders(int id);


    }
}
