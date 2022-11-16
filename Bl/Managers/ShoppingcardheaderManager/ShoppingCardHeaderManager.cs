using AutoMapper;
using ECommerceGP.DAL;

namespace ECommerceGP.Bl;

public class ShoppingCardHeaderManager : IShoppingCardHeaderManager
{
    private readonly IShoppingCardHeaderRepo _shoppingCardHeaderRepo;
    private readonly IMapper _mapper;
    public ShoppingCardHeaderManager(IShoppingCardHeaderRepo shoppingCardHeaderRepo,IMapper mapper)
    {
        _shoppingCardHeaderRepo = shoppingCardHeaderRepo;
        _mapper = mapper;
    }

    public ShoppingCardHeaderReadDto cardproductsByShoppingcardheaderId(int id)
    {
        var ComingData = _shoppingCardHeaderRepo.GetCardProductsByShoppingCardHeaderId(id);
        return _mapper.Map<ShoppingCardHeaderReadDto>(ComingData);
    }

    public void CreateShoppingCardHeader(ShoppingCardHeaderWriteDto write)
    {
        var AddShoppingCardHeader = _mapper.Map<ShoppingCardHeader>(write);
        _shoppingCardHeaderRepo.CreateCardproductAndCardHeader(AddShoppingCardHeader);
        _shoppingCardHeaderRepo.SaveChanges();
    }
   
}
