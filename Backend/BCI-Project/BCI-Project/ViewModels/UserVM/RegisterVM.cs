using System.ComponentModel.DataAnnotations;

namespace BCI_Project.ViewModels.UserVM
{
    public class RegisterVM
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        public string PatientHistory { get; set; }
    }
}
