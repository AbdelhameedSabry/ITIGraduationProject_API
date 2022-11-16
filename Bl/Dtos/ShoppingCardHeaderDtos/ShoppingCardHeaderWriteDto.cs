namespace ECommerceGP.Bl
{
    public class ShoppingCardHeaderWriteDto
    {

        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        
        public int Userid { get; set; }
        //public User? User { get; set; }
        public string? notes { get; set; }

        public int total { get; set; }
        public ICollection<CardProductChildWrite> cardproducts { get; set; } = new HashSet<CardProductChildWrite>();
    }
}
