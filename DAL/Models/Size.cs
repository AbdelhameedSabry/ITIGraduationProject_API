namespace ECommerceGP.DAL
{
    public class Size
    {
        public int Id { get; set; }
        public string? SizeName { get; set; }

        public CardProduct? CardProduct { get; set; }

    }
}
