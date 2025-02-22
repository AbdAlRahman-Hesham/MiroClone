using System.ComponentModel.DataAnnotations;

namespace MiroClone.Server.DTOS.AuthDtos
{
    public class SignInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
