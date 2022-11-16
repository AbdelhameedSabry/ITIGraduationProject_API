using ECommerceGP.Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCardHeaderController : ControllerBase
    {
       private IShoppingCardHeaderManager _shoppingCardHeaderManager;
        public ShoppingCardHeaderController( IShoppingCardHeaderManager shoppingCardHeaderManager )
        {
            _shoppingCardHeaderManager = shoppingCardHeaderManager;
        }
       
        [HttpPost]
        [Route("CheckOut")]
        [Authorize(Policy = "user")]
        public ActionResult AddCardHeader(ShoppingCardHeaderWriteDto shoppingCardHeaderWriteDto)
        {
            _shoppingCardHeaderManager.CreateShoppingCardHeader( shoppingCardHeaderWriteDto );  
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetCardproductByShoppingCardId(int id)
        {
            var getdata= _shoppingCardHeaderManager.cardproductsByShoppingcardheaderId(id);
              return Ok(getdata);
        }
       
    }
}
