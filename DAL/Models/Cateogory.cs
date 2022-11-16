namespace ECommerceGP.DAL
{
    public class Cateogory
    {
        public int Id{ get; set; }
        public string? CateogoryName { get; set; }

        public byte[]? image { get; set; } 
        public ICollection<Product> Products { get; set; }

        public Cateogory() => Products = new HashSet<Product>();
    }
}
