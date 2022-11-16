using ECommerceGP.Bl;
using ECommerceGP.Bl.Dtos.UserDtos;
using ECommerceGP.Bl.Managers.UserManager;
using ECommerceGP.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly UserManager<User> usermanager;
        private readonly IConfiguration configuration;

        public UsersController(IUserManager userManager, UserManager<User> usermanager, IConfiguration configuration)
        {
                _userManager = userManager;
            this.usermanager = usermanager;
            this.configuration = configuration;
        }

        //Get Orders By UserId
        [HttpGet]
        [Route("{id:int}")]

        public ActionResult GetUsersOrder(int id)
        {
            var orders =_userManager.GetUsersOrders(id);
            return Ok(orders);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> register(UserRegisterDTO input)
        {
            var NewUser = new User
            {
                UserName = input.UserName,
                Email = input.Email,
                address = input.address,
                PhoneNumber = input.PhoneNumber
            };

            var creationResult = await usermanager.CreateAsync(NewUser, input.password);

            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);

            }
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier,NewUser.Id.ToString()),
               new Claim(ClaimTypes.Role,"Client")
            };

            var claimsResult = await usermanager.AddClaimsAsync(NewUser, claims);
            if (!claimsResult.Succeeded)
            {
                return BadRequest(claimsResult.Errors);
            }
            return Ok();
        }

        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult<TokenDTO>> Login (LoginCredentialsDTO loginInput)
        {
            var user = await usermanager.FindByNameAsync(loginInput.username);
            if(user == null)
            {
                return BadRequest(new { message = "user not found" });

            }
            var Islocked = await usermanager.IsLockedOutAsync(user);
            if (Islocked)
            {
                return BadRequest(new { message = "You  are Locked Out" });
            }

            if ( !await usermanager.CheckPasswordAsync(user,loginInput.password))
            {
                await usermanager.AccessFailedAsync(user);
                return Unauthorized();
            }
            var userclaims = await usermanager.GetClaimsAsync(user);

            var KeyString = configuration.GetValue<string>("SecretKey");
            var KeyInBytes = Encoding.ASCII.GetBytes(KeyString);
            var Key = new SymmetricSecurityKey(KeyInBytes);

            var signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(
                claims: userclaims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(30),
                notBefore:DateTime.Now

                );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);
            return Ok(new TokenDTO
            {
                Token = tokenString 
            });
        }
        [HttpGet]
        [Authorize]
        [Route("CurrentUser")]
        public async Task<ActionResult> GetCurrentUser()
        {
            var CurrentUser = await usermanager.GetUserAsync(User);
            return Ok(
                new
                {
                    Id = CurrentUser.Id,
                    UserName = CurrentUser.UserName
                }
                );
        }
    }
}
