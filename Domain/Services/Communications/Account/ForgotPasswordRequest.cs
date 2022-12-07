using System.ComponentModel.DataAnnotations;

namespace Entropia_CS_React.Domain.Services.Communications.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}