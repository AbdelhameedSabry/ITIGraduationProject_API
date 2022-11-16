namespace ECommerceGP.Bl
{
    public class ShoppingCardHeaderReadDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
       
        public int Userid { get; set; }
       
        public string? notes { get; set; }

        public int total { get; set; }

        public ICollection<productChildReadDto> cardproducts { get; set; } = new HashSet<productChildReadDto>();

    }
}
