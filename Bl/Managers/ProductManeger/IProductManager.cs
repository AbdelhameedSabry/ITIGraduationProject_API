using ECommerceGP.Bl.Dtos.ProductDtos;

namespace ECommerceGP.Bl
{
    public interface IProductManager
    {
        List<ProductsReadDTO>? GetAllProducts();
        ProductDetailsReadDtos? GetProductById(int id);
        void AddProduct(productDtoWrite product);
        bool EditeProduct(productDtoWrite product);
        void DeleteProduct(int id);
        IEnumerable<ProductsReadDTO> GetProductBySearch(string SearchWord);
        //ProductREsponseDtos? GetProductResponseByPageindex(int PageIndex);
    }
}
