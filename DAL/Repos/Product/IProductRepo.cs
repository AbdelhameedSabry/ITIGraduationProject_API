using ECommerceGP.DAL;

namespace ECommerceGP.DAL
{
    public interface IProductRepo:IGeneric<Product>
    {
        IEnumerable<Product> GetProductBySearchString(string SearchProduct);
        ResponseProduct? ProductPagenation(int CurrentPage);
    }
}
