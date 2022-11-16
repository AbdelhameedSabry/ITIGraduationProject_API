namespace ECommerceGP.DAL
{
    public interface IShoppingCardHeaderRepo:IGeneric<ShoppingCardHeader>
    {
        void CreateCardproductAndCardHeader(ShoppingCardHeader cardHeaders);
        ShoppingCardHeader? GetCardProductsByShoppingCardHeaderId(int id);
    }
}
