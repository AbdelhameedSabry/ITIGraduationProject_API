using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceGP.DAL
{
    public class Product
    { 
        public int Id { get; set; }

        [ForeignKey("Cateogory")]
        public int CateogoryId { get; set; }
        public Cateogory? Cateogory { get; set; }

        public string? ProductName { get; set; }
        public double price { get; set; }
        public string Description { get; set; } = "";

        public byte[] picture { get; set; }=new byte[0]; 

        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public Gender? Gender { get; set; }

        public  CardProduct? cardProduct { get; set; }
        
    }
}
