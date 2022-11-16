using ECommerceGP.Bl;
using ECommerceGP.Bl.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IcateogoryManeger categorymanager;

        public CategoriesController(IcateogoryManeger _categorymanager)
        {
            categorymanager = _categorymanager;
        }


        [HttpGet]
        public ActionResult<IEnumerable<cateogoryRead>> GetAllCategories()
        {

            return categorymanager.GetAllCategories();
        }
        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<CategoryWithProductsReadDTO?> GetGategoryWithProducts(int id)
        {
            var CategoryDTO  = categorymanager.GetCategoryWithProducts(id);
            if(CategoryDTO == null)
            {
                return NotFound();
            }
            return CategoryDTO;
        }

        [HttpPost]

        public ActionResult AddCategory ([FromForm]CateogoryWrite CWriteDTO)
        {
           //using var stream = new MemoryStream();
           // CWriteDTO.image.CopyTo(stream);
            categorymanager.AddCateogory(CWriteDTO);
            return Ok();
        } 
    }
}
