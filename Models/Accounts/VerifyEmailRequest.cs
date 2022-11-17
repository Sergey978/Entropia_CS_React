using System.ComponentModel.DataAnnotations;

namespace Entropia_CS_React.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}