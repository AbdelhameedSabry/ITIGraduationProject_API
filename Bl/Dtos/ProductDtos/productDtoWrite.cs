namespace ECommerceGP.Bl
{
    public class productDtoWrite
    {
            public int CateogoryId { get; set; }
            public string? ProductName { get; set; }
            public double price { get; set; }
            public string Description { get; set; } = "";
            public int GenderId { get; set; }
            public IFormFile? picture { get; set; } 
        }
    }



