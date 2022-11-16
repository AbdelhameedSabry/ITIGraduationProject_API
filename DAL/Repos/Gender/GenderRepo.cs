using ECommerceGP.DAL;

namespace ECommerceGP.DAL
{
    public class GenderRepo:Generic<Gender>, IGenderRepo
    {
        private readonly ApplicationDbcontext _dbcontext;   
        public GenderRepo(ApplicationDbcontext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
