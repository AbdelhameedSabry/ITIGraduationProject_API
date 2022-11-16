using ECommerceGP.Bl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderManager _genderManager;
        public GendersController(IGenderManager genderManager)
        {
            _genderManager = genderManager; 
        }
        [HttpPost]
        public ActionResult AddGender(GenderDtosWrite genderdto)
        {
            _genderManager.AddGender(genderdto);
            return Ok();
            
        }
        [HttpGet]
        public ActionResult<IEnumerable<GenderDtosRead>> GetAllGender()
        {
            return _genderManager.GetAllGender();
        }

        //Delete Action is non-Essential
    }
}
