using System.ComponentModel.DataAnnotations;

namespace ECommerceGP.Bl.Dtos.UserDtos
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";

        public string password { get; set; } = "";
        [Required]
        public string PhoneNumber { get; set; } = "";
        [Required]
        public string address { get; set; } = "";
    }
}
