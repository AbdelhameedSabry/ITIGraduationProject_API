namespace ECommerceGP.Bl;

public class UserReadDtos
{
    public ICollection<ShoppingCardHeaderReadDto> shoppingcardheader { get; set; } = new HashSet<ShoppingCardHeaderReadDto>();
}
