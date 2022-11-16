using ECommerceGP.Bl;
using ECommerceGP.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ECommerceGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly IProductRepo _productRepo;
        
        public ProductsController(IProductManager productManager,IProductRepo productRepo)
        {
            this.productManager = productManager;
           _productRepo = productRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductsReadDTO>> GetAllProducts()
        {

            return productManager.GetAllProducts();

        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ProductDetailsReadDtos> GetProductById(int id)
        {

            var productDTO = productManager.GetProductById(id);
            if (productDTO == null)
            {
                return NotFound();
            }
            return productDTO;
        }


        //Add Product
        [HttpPost]
        public ActionResult AddProduct([FromForm] productDtoWrite product)
        {

            productManager.AddProduct(product);
            return Ok();
        }
        [HttpGet]
        
        [Route("{SearchKey}")]
        public ActionResult<IEnumerable<ProductsReadDTO>> SearchProductByString([FromQuery] string SearchKey)
        {
            var search = productManager.GetProductBySearch(SearchKey);
            return Ok(search);
        }
        [HttpGet("GetResultProduct")]
        //[Route("{CurrentPage:int}")]
        public ActionResult<ResponseProduct> GetResultProduct([FromQuery] int CurrentPage)
        {
            var resultPage = _productRepo.ProductPagenation(CurrentPage);
            return (resultPage);
        }

      
    }
}