using ECommerceGP.DAL;

namespace ECommerceGP.DAL
{
    public class Generic<T> : IGeneric<T> where T : class 
    {
        private readonly ApplicationDbcontext _dbcontext;
        public Generic(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;  
        }
        public List<T> GetAll()
        {

            return _dbcontext.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
          
        }

        public void Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity); 
        }

        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }

        
    }
   
}
