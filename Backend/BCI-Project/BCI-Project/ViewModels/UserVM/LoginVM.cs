using System.ComponentModel.DataAnnotations;

namespace BCI_Project.ViewModels.UserVM
{
    public class LoginVM
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
