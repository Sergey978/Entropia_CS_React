using System.ComponentModel.DataAnnotations;

namespace Entropia_CS_React.Domain.Services.Communications.Account
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}