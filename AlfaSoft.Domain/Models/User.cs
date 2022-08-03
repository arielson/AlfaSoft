using System.ComponentModel.DataAnnotations;

namespace AlfaSoft.Domain.Models
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
