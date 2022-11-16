namespace ECommerceGP.DAL
{
    public class Gender
    {
        public int Id { get; set; }
        public string? GenderName { get; set; }
        public ICollection<Product> Products { get; set; }

        public Gender()
        {
            Products = new HashSet<Product>();
        }
    }
}
