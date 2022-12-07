using System.ComponentModel.DataAnnotations;

namespace Entropia_CS_React.Domain.Services.Communications.Account
{
    public class AuthenticateRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}