using ECommerceGP.Bl.Dtos.CategoryDtos;

namespace ECommerceGP.Bl
{
    public interface IcateogoryManeger
    {
        List<cateogoryRead> GetAllCategories();
        cateogoryRead GetCategory(int id);  
        void AddCateogory(CateogoryWrite cateogory);
        bool EditCateogory(CateogoryWrite cateogory);
        void Delete(int id);

        CategoryWithProductsReadDTO? GetCategoryWithProducts(int id);
    }
}
