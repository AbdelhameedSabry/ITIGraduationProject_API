using ECommerceGP.Bl.Dtos.ProductDtos;
using ECommerceGP.DAL;

namespace ECommerceGP.Bl.Dtos.CategoryDtos
{
    public class CategoryWithProductsReadDTO
    {
        public int Id { get; set; }
        public string CateogoryName { get; set; } = "";

        public byte[] image { get; set; } = new byte[0];
        public ICollection<ProductReadChildDTO> Products { get; set; }=new HashSet<ProductReadChildDTO>();
    }
}
