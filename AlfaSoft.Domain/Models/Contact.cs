using System.ComponentModel.DataAnnotations;

namespace AlfaSoft.Domain.Models
{
    public class Contact : Base
    {
        [Required(ErrorMessage = "{0} required")]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Please enter a value bigger than {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(9, ErrorMessage = "Please enter a value equal to {1} characters")]
        [MaxLength(9)]
        [Display(Name = "Contact")]
        public string ContactValue { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "{0} invalid")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
