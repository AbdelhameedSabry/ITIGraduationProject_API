namespace ECommerceGP.Bl.Dtos.ProductDtos
{
    public class ProductREsponseDtos
    {
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public ICollection<productChildReadDto> Products { get; set; } = new HashSet<productChildReadDto>();
    }
}
