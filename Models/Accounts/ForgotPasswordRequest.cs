using System.ComponentModel.DataAnnotations;

namespace Entropia_CS_React.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}