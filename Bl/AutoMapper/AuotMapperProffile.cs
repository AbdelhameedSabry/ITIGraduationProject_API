using AutoMapper;
using ECommerceGP.Bl.Dtos.CategoryDtos;
using ECommerceGP.Bl.Dtos.ProductDtos;
using ECommerceGP.DAL;

namespace ECommerceGP.Bl
{
    public class AuotMapperProfile:Profile
    {
        public AuotMapperProfile()
        {
            CreateMap<GenderDtosWrite, Gender>();
            CreateMap<Gender, GenderDtosRead>();

            CreateMap<Product, ProductReadChildDTO>();
            CreateMap<Cateogory, CategoryWithProductsReadDTO>();

            CreateMap<Cateogory, cateogoryRead>();

            CreateMap<Product, ProductDetailsReadDtos>();
            CreateMap<Product, ProductsReadDTO>();

            CreateMap<productDtoWrite, Product>().ForMember(s => s.picture, op => op.Ignore());

            CreateMap<CateogoryWrite, Cateogory>().ForMember(src => src.image, opt => opt.Ignore());
            CreateMap<ShoppingCardHeaderWriteDto, ShoppingCardHeader>();
            CreateMap<CardProductChildWrite, CardProduct>();
            CreateMap<ShoppingCardHeader, ShoppingCardHeaderReadDto>();
            CreateMap<CardProduct,productChildReadDto>();
            CreateMap<User, UserReadDtos>();
            CreateMap<ShoppingCardHeader, UserShoppingCardHeaderChildReadDtos>();
            CreateMap<ResponseProduct,ProductREsponseDtos>();
           

        }
        
    }
}
