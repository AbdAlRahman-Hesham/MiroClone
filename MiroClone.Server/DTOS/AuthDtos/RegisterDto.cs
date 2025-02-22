using System.ComponentModel.DataAnnotations;

namespace MiroClone.Server.DTOS.AuthDtos
{
    public class RegisterDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
