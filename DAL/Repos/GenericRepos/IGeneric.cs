namespace ECommerceGP.DAL
{
    public interface IGeneric<T> where T : class 
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
        void SaveChanges();
    }
   
}
