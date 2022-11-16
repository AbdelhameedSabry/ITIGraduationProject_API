namespace ECommerceGP.Bl
{
    public class ProductDetailsReadDtos
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public double price { get; set; }
        public string Description { get; set; } = "";
        public byte[] picture { get; set; } = new byte[0];
    }
}
