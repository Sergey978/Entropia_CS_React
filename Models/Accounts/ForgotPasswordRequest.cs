using System.ComponentModel.DataAnnotations;

namespace SignupVerTutor.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}