using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required, MinLength(6)]
        public string Username { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MinLength(6)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password)), MinLength(6)]
        public string ConfirmPassword { get; set; }
    }
}
