using System.ComponentModel.DataAnnotations;

namespace Examination.BL.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
