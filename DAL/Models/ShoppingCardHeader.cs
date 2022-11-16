using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceGP.DAL
{
    public class ShoppingCardHeader
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("User")]
        public int Userid { get; set; }
        public User? User { get; set; }
        public string? notes { get; set; }

        public int total { get; set; }

        public ICollection<CardProduct>cardproducts {get;set;}
        public ShoppingCardHeader()
        {
            cardproducts = new HashSet<CardProduct>();

        }
    }
}
