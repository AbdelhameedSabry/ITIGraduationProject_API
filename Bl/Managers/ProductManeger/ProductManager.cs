using AutoMapper;
using ECommerceGP.Bl.Dtos.ProductDtos;
using ECommerceGP.DAL;

namespace ECommerceGP.Bl
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo productRepo;
        private readonly IMapper mapper;

        public ProductManager(IProductRepo productRepo,IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }
        public void AddProduct(productDtoWrite products)
        {
            var imageToByte = new MemoryStream();
            products.picture.CopyTo(imageToByte);
            var productAdded = mapper.Map<Product>(products);
            productAdded.picture= imageToByte.ToArray();
            productRepo.Add(productAdded);
            productRepo.SaveChanges();

            
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditeProduct(productDtoWrite product)
        {
            throw new NotImplementedException();
        }

        public List<ProductsReadDTO> GetAllProducts()
        {
            var dbProducts = productRepo.GetAll();
            return mapper.Map<List<ProductsReadDTO>>(dbProducts);
        }

        public ProductDetailsReadDtos GetProductById(int id)
        {
            var dbProduct =productRepo.GetById(id); ;
            return mapper.Map<ProductDetailsReadDtos>(dbProduct);
        }

        public IEnumerable<ProductsReadDTO> GetProductBySearch(string SearchWord)
        {
            var ComingProductData = productRepo.GetProductBySearchString(SearchWord);
            return mapper.Map<IEnumerable<ProductsReadDTO>>(ComingProductData);
        }

        //public ProductREsponseDtos? GetProductResponseByPageindex(int PageIndex)
        //{
        //    var ResultProduct = productRepo.ProductPagenation(PageIndex);
        //    return mapper.Map<ProductREsponseDtos>(ResultProduct);
        //}
    }
}
