namespace ECommerceGP.Bl
{
    public interface IShoppingCardHeaderManager
    {
        void CreateShoppingCardHeader(ShoppingCardHeaderWriteDto write);
        ShoppingCardHeaderReadDto cardproductsByShoppingcardheaderId(int id);
    }
}
