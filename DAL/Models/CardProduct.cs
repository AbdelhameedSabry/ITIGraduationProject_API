using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceGP.DAL
{
    public class CardProduct
    {
        public int Id { get; set; }

        
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? product { get; set; }

        public int amount { get; set; }
        public double price { get; set; }

        public double total { get; set; }

        
        public int HeaderId { get; set; }
        [ForeignKey("HeaderId")]
        public ShoppingCardHeader? ShoppingCardHeader { get; set; }

        
        public int SizeId { get; set; }
        [ForeignKey("SizeId")]
        public  Size? Size { get; set; }

        
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color? Color { get; set; }

      
       
    }
}
