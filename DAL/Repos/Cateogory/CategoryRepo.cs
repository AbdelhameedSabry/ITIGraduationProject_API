using ECommerceGP.DAL;
using Microsoft.EntityFrameworkCore;

namespace ECommerceGP.DAL
{
    public class CategoryRepo:Generic<Cateogory> ,Icateogoryrepo
    {
        private readonly ApplicationDbcontext _dbcontext;
        public CategoryRepo(ApplicationDbcontext dbcontext):base(dbcontext) 
        {
            _dbcontext = dbcontext;  
        }

        public Cateogory? GetCateogoryWithProducts(int id)
        {
            return _dbcontext.cateogories.Include(a => a.Products).FirstOrDefault(a => a.Id == id);
        }
    }
}
