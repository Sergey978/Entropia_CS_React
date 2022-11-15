using System.ComponentModel.DataAnnotations;

namespace SignupVerTutor.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}