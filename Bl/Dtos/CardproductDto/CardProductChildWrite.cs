namespace ECommerceGP.Bl;

public class CardProductChildWrite
{
    //public int Id { get; set; }

    //[ForeignKey("product")]
    public int ProductId { get; set; }
    //public Product? product { get; set; }

    public int amount { get; set; }
    public double price { get; set; }

    public double total { get; set; }

    //[ForeignKey("ShoppingCardHeader")]
    public int HeaderId { get; set; }

    //public ShoppingCardHeader? ShoppingCardHeader { get; set; }

    //[ForeignKey("Size")]
    public int SizeId { get; set; }
    //public Size? Size { get; set; }

    //[ForeignKey("Color")]
    public int ColorId { get; set; }
    //public Color? Color { get; set; }
}
