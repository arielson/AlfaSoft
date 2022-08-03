using System.ComponentModel.DataAnnotations;

namespace AlfaSoft.Domain.Models
{
    public class Contact : Base
    {
        [Required(ErrorMessage = "{0} required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Contact")]
        public string ContactValue { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "{0} invalid")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
