namespace ECommerceGP.DAL
{
    public class ResponseProduct
    {
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
