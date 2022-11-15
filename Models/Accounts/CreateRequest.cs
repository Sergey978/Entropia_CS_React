using System.ComponentModel.DataAnnotations;
using SignupVerTutor.Entities;

namespace SignupVerTutor.Models.Accounts
{
    public class CreateRequest
    {
       

        [Required]
        [EnumDataType(typeof(Role))]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}