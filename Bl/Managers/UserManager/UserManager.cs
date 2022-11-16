using AutoMapper;
using ECommerceGP.Bl.Dtos.UserDtos;
using ECommerceGP.DAL;
using Microsoft.AspNetCore.Identity;


namespace ECommerceGP.Bl.Managers.UserManager
{
    public class UserManager:IUserManager
    {
        private readonly IMapper _mapper;
         private readonly IUserRepo _userRepo;
       
        public UserManager(IUserRepo userRepo  ,IMapper mapper )
        {
            _mapper = mapper;
            _userRepo = userRepo;
        
        }

        public UserReadDtos? GetUsersOrders(int id)
        {
            var userOrders = _userRepo.GetShoppingHeaderByUserId(id);
            return _mapper.Map<UserReadDtos>(userOrders);
        }

    

       

      
    }
}
